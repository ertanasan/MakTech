-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_ORDERSTATUSHISTORY_SP
    @OrderStatusHistoryId BIGINT OUT,
    @Event                INT,
    @Organization         INT,
    @ReturnOrder          BIGINT,
    @Status               INT,
    @OperationCode        INT,
    @Comment              VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_ORDERSTATUSHISTORY
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        RETURNORDER,
        STATUS,
        OPERATION_CD,
        COMMENT_TXT
    )
    VALUES
    (
        1,
        1,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ReturnOrder,
        @Status,
        @OperationCode,
        @Comment
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
    SELECT @OrderStatusHistoryId = SCOPE_IDENTITY();
/*Section="End"*/
END;
