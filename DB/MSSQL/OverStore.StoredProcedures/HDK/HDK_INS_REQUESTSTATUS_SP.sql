﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REQUESTSTATUS_SP
    @RequestStatusId INT,
    @StatusName      VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REQUESTSTATUS
    (
        REQUESTSTATUSID,
        STATUS_NM
    )
    VALUES
    (
        @RequestStatusId,
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO HDK_REQUESTSTATUSLOG
    (
        REQUESTSTATUSID,
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
        @RequestStatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StatusName);
/*Section="End"*/
END;
