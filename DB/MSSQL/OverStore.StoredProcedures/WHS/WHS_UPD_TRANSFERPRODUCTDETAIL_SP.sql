-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_TRANSFERPRODUCTDETAIL_SP
    @TransferProductDetailId BIGINT,
    @Event                   INT,
    @Organization            INT,
    @Product                 INT,
    @TransferProduct         BIGINT,
    @ProductQuantity         NUMERIC(11,4)
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
    UPDATE WHS_TRANSFERPRODUCTDETAIL
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           PRODUCT = @Product,
           TRANSFERPRODUCT = @TransferProduct,
           QUANTITY_QTY = @ProductQuantity
     WHERE TRANSFERPRODUCTDETAILID = @TransferProductDetailId     
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
