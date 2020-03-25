-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_PRODUCTIONORDER_SP
    @ProductionOrderId BIGINT OUT,
    @Event             INT,
    @Organization      INT,
    @Production        INT,
    @Quantity          INT,
    @StatusCode        INT,
    @ProcessInstance   BIGINT,
    @CompletedQuantity INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_PRODUCTIONORDER
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        PRODUCTION,
        QUANTITY_QTY,
        STATUS_CD,
        PROCESSINSTANCE_LNO,
        COMPLETED_QTY
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
        @Production,
        @Quantity,
        @StatusCode,
        @ProcessInstance,
        @CompletedQuantity
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
    SELECT @ProductionOrderId = SCOPE_IDENTITY();
/*Section="End"*/
END;
