-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_SALECUSTOMER_SP
    @SaleCustomerId        BIGINT,
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
    UPDATE SLS_SALECUSTOMER
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SALE = @Sale,
           EINVOICE_FL = @EInvoiceFlag,
           CUSTOMER_NM = @CustomerName,
           ADDRESS_TXT = @Address,
           TAXCENTER_NM = @TaxCenterName,
           IDENTITYNO_TXT = @TaxIdentityNo,
           EMAIL_TXT = @Email,
           PHONENUMBER_TXT = @PhoneNumber,
           FISCALSERIAL_TXT = @FiscalSerial,
           EINVOICEZET_NO = @EInvoiceZetNumber,
           EINVOICERECEIPT_NO = @EInvoiceReceiptNumber
     WHERE SALECUSTOMERID = @SaleCustomerId     
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
