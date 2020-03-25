-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_RETURNREASON_SP
    @ReturnReasonId INT OUT,
    @ReasonName     VARCHAR(100),
    @Parent         INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_RETURNREASON
    (
        REASON_NM,
        PARENT
    )
    VALUES
    (
        @ReasonName,
        @Parent
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
    SELECT @ReturnReasonId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_RETURNREASONLOG
    (
        RETURNREASONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        REASON_NM,
        PARENT
    )
    VALUES
    (
        @ReturnReasonId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ReasonName,
        @Parent);
/*Section="End"*/
END;
