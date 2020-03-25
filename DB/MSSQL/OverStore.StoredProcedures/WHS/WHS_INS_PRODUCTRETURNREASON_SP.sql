-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_PRODUCTRETURNREASON_SP
    @ProductReturnReasonId BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @ProductReturn         BIGINT,
    @ReturnReason          INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_PRODUCTRETURNREASON
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        PRODUCTRETURN,
        RETURNREASON
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
        @ProductReturn,
        @ReturnReason
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
    SELECT @ProductReturnReasonId = SCOPE_IDENTITY();
/*Section="End"*/
END;
