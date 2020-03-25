-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_MATERIALORDERDETAIL_SP
    @MaterialOrderDetailId BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @MaterialOrder         BIGINT,
    @Material              INT,
    @OrderQuantity         NUMERIC(22,6),
    @RevisedQuantity       NUMERIC(22,6),
    @ShippedQuantity       NUMERIC(22,6),
    @IntakeQuantity        NUMERIC(22,6),
    @Note                  VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_MATERIALORDERDETAIL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        MATERIALORDER,
        MATERIAL,
        ORDER_AMT,
        REVISED_AMT,
        SHIPPED_AMT,
        INTAKE_AMT,
        NOTE_TXT
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
        @MaterialOrder,
        @Material,
        @OrderQuantity,
        @RevisedQuantity,
        @ShippedQuantity,
        @IntakeQuantity,
        @Note
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
    SELECT @MaterialOrderDetailId = SCOPE_IDENTITY();
/*Section="End"*/
END;
