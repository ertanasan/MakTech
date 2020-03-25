-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_STOREORDERDETAIL_SP
    @StoreOrderDetailId BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_STOREORDERDETAIL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        PRODUCT,
        ORDER_QTY,
        REVISED_QTY,
        SHIPPED_QTY,
        ORDERUNIT_QTY,
        STOREORDER,
        INTAKE_QTY,
		SUGGESTION_QTY
    )
    VALUES
    (
        1047, -- @Event,
        1, --@Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Product,
        @OrderQuantity,
        @RevisedQuantity,
        @ShippedQuantity,
        @OrderUnitQuantity,
        @StoreOrder,
        @IntakeQuantity,
		@SuggestionQuantity
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
    SELECT @StoreOrderDetailId = SCOPE_IDENTITY();
/*Section="End"*/
END;
