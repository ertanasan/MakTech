-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_STOREORDERDETAIL_SP
    @StoreOrderDetailId BIGINT,
    @Event              INT,
    @Organization       INT,
    @Product            INT,
    @OrderQuantity      NUMERIC(12,6),
    @RevisedQuantity    NUMERIC(12,6),
    @ShippedQuantity    NUMERIC(12,6),
    @OrderUnitQuantity  NUMERIC(12,6),
    @StoreOrder         BIGINT,
    @IntakeQuantity     NUMERIC(12,6),
	@SuggestionQuantity NUMERIC(12,6)
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
    UPDATE WHS_STOREORDERDETAIL
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           PRODUCT = @Product,
           ORDER_QTY = @OrderQuantity,
           REVISED_QTY = @RevisedQuantity,
           SHIPPED_QTY = @ShippedQuantity,
           ORDERUNIT_QTY = @OrderUnitQuantity,
           STOREORDER = @StoreOrder,
           INTAKE_QTY = @IntakeQuantity,
		   SUGGESTION_QTY = @SuggestionQuantity
     WHERE STOREORDERDETAILID = @StoreOrderDetailId
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
