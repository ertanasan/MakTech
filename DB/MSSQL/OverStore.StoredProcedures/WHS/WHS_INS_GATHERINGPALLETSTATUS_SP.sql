-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_GATHERINGPALLETSTATUS_SP
    @StatusId INT,
    @Name     VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_GATHERINGPALLETSTATUS
    (
        GATHERINGPALLETSTATUSID,
        STATUS_NM
    )
    VALUES
    (
        @StatusId,
        @Name
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_GATHERINGPALLETSTATUSLOG
    (
        GATHERINGPALLETSTATUSID,
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
        @StatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name);
/*Section="End"*/
END;
