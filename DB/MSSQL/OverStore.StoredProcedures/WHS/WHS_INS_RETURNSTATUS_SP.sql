-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_RETURNSTATUS_SP
    @ReturnStatusId INT OUT,
    @StatusName     VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_RETURNSTATUS
    (
        STATUS_NM
    )
    VALUES
    (
        @StatusName
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
    SELECT @ReturnStatusId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_RETURNSTATUSLOG
    (
        RETURNSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM
    )    
    VALUES
    (
        @ReturnStatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StatusName);
/*Section="End"*/
END;
