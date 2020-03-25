-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_CONSIGNMENTGOODPURCHASE_SP
    @ConsignmentGoodPurchaseId BIGINT,
    @Event                     INT,
    @Organization              INT,
    @Store                     INT,
    @Product                   INT,
    @Supplier                  INT,
    @Quantity                  NUMERIC(9,2)
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
    UPDATE WHS_CONSIGNMENTGOODPURCHASE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           PRODUCT = @Product,
           SUPPLIER = @Supplier,
           QUANTITY_QTY = @Quantity
     WHERE CONSIGNMENTGOODPURCHASEID = @ConsignmentGoodPurchaseId     
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
