-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_SALECUSTOMER_SP
    @SaleCustomerId        BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @Sale                  BIGINT,
    @EInvoiceFlag          VARCHAR(1),
    @CustomerName          VARCHAR(100),
    @Address               VARCHAR(1000),
    @TaxCenterName         VARCHAR(100),
    @TaxIdentityNo         VARCHAR(50),
    @Email                 VARCHAR(100),
    @PhoneNumber           VARCHAR(50),
    @FiscalSerial          VARCHAR(100),
    @EInvoiceZetNumber     INT,
    @EInvoiceReceiptNumber INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SLS_SALECUSTOMER
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        SALE,
        EINVOICE_FL,
        CUSTOMER_NM,
        ADDRESS_TXT,
        TAXCENTER_NM,
        IDENTITYNO_TXT,
        EMAIL_TXT,
        PHONENUMBER_TXT,
        FISCALSERIAL_TXT,
        EINVOICEZET_NO,
        EINVOICERECEIPT_NO
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
        @Sale,
        @EInvoiceFlag,
        ISNULL(@CustomerName, 'Bilgi verilmedi'),
        @Address,
        @TaxCenterName,
        @TaxIdentityNo,
        @Email,
        @PhoneNumber,
        @FiscalSerial,
        @EInvoiceZetNumber,
        @EInvoiceReceiptNumber
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
    SELECT @SaleCustomerId = SCOPE_IDENTITY();
/*Section="End"*/
END;