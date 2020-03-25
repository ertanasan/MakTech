-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_RETURNORDER_SP
    @ReturnOrderId   BIGINT OUT,
    @Event           INT,
    @Organization    INT,
    @Store           INT,
    @Status          INT,
    @ProcessInstance BIGINT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_RETURNORDER
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
        STATUS,
        PROCESSINSTANCE_LNO
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
        @Store,
        @Status,
        @ProcessInstance
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
    SELECT @ReturnOrderId = SCOPE_IDENTITY();
/*Section="End"*/
END;
