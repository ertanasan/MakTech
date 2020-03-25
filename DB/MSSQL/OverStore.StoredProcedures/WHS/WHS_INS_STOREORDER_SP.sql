-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_STOREORDER_SP
    @StoreOrderId BIGINT OUT,
    @Event        INT,
    @Organization INT,
    @Store        INT,
    @OrderCode    VARCHAR(100),
    @Status       INT,
    @OrderDate    DATETIME,
    @ShipmentDate DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_STOREORDER
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STORE,
        ORDERCODE_NM,
        STATUS,
        ORDER_DT,
        SHIPMENT_DT
    )
    VALUES
    (
        @Event,
        ISNULL(dbo.SYS_GETCURRENTORGANIZATION_FN(),1),
        'N',
        GETDATE(),
        ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1),
        ISNULL(dbo.SYS_GETCURRENTCHANNEL_FN(),1),
        ISNULL(dbo.SYS_GETCURRENTBRANCH_FN(),1),
        ISNULL(dbo.SYS_GETCURRENTSCREEN_FN(),1),
        @Store,
        @OrderCode,
        @Status,
        CAST(@OrderDate AS DATE),
        CAST(@ShipmentDate AS DATE)
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
    SELECT @StoreOrderId = SCOPE_IDENTITY();

	UPDATE WHS_STOREORDER SET ORDERCODE_NM = ORDERCODE_NM + '-' + CAST(@StoreOrderId AS VARCHAR(20)) WHERE STOREORDERID = @StoreOrderId;

	INSERT INTO WHS_STOREORDERHISTORY
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STOREORDER,
        HISTORY_TM,
        STATUS
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1),
        ISNULL(dbo.SYS_GETCURRENTCHANNEL_FN(),1),
        ISNULL(dbo.SYS_GETCURRENTBRANCH_FN(),1),
        ISNULL(dbo.SYS_GETCURRENTSCREEN_FN(),1),
        @StoreOrderId,
        GETDATE(),
        @Status
    );
/*Section="End"*/
END;
