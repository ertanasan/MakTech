-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_INVOICE_SP
    @SaleInvoiceId     BIGINT,
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
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_INVOICE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           EINVOICE_FL = @EInvoiceFlag,
           CUSTOMERID_LNO = @CustomerIdNumber,
           TITLE_DSC = @Title,
           EMAIL_TXT = @Email,
           SALE = @Sale,
           EINVOICECLIENT = @EInvoiceClient,
           ADDRESS_TXT = @Address,
           STATUS_CD = @StatusCode,
           MIKRO_FL = @MikroFlag,
           MIKRO_TM = @MikroTransferTime,
           PROCESSINSTANCE_LNO = @ProcessInstance,
           PHONENUMBER_TXT = @PhoneNumber
     WHERE INVOICEID = @SaleInvoiceId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
