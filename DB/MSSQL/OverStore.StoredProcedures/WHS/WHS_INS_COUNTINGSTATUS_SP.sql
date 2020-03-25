-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_COUNTINGSTATUS_SP
    @CountingStatusId   INT OUT,
    @CountingStatusName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_COUNTINGSTATUS
    (
        COUNTINGSTATUS_NM
    )
    VALUES
    (
        @CountingStatusName
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
    SELECT @CountingStatusId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_COUNTINGSTATUSLOG
    (
        COUNTINGSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTINGSTATUS_NM
    )    
    VALUES
    (
        @CountingStatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @CountingStatusName);
/*Section="End"*/
END;
