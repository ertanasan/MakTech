-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_INVOICE_SP
    @SaleInvoiceId     BIGINT OUT,
    @Event             INT,
    @Organization      INT,
    @EInvoiceFlag      VARCHAR(1),
    @CustomerIdNumber  BIGINT,
    @Title             VARCHAR(1000),
    @Email             VARCHAR(200),
    @Sale              BIGINT,
    @EInvoiceClient    INT,
    @Address           VARCHAR(1000),
    @StatusCode        INT,
    @MikroFlag         VARCHAR(1),
    @MikroTransferTime DATETIME,
    @ProcessInstance   BIGINT,
    @PhoneNumber       VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_INVOICE
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        EINVOICE_FL,
        CUSTOMERID_LNO,
        TITLE_DSC,
        EMAIL_TXT,
        SALE,
        EINVOICECLIENT,
        ADDRESS_TXT,
        STATUS_CD,
        MIKRO_FL,
        MIKRO_TM,
        PROCESSINSTANCE_LNO,
        PHONENUMBER_TXT
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @EInvoiceFlag,
        @CustomerIdNumber,
        @Title,
        @Email,
        @Sale,
        @EInvoiceClient,
        @Address,
        @StatusCode,
        @MikroFlag,
        @MikroTransferTime,
        @ProcessInstance,
        @PhoneNumber
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @SaleInvoiceId = SCOPE_IDENTITY();
/*Section="End"*/
END;
