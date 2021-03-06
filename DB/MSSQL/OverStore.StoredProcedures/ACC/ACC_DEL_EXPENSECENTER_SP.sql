﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_EXPENSECENTER_SP
    @ExpenseCenterId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_EXPENSECENTERLOG
    (
        EXPENSECENTERID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        EXPENSECENTER_NM,
        EXPENSECENTERCODE_TXT,
        CENTERGROUP_NO,
        REGIONMANAGER,
        STORE,
        ACTIVE_FL    )    
    SELECT
        EXPENSECENTERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EXPENSECENTER_NM,
        EXPENSECENTERCODE_TXT,
        CENTERGROUP_NO,
        REGIONMANAGER,
        STORE,
        ACTIVE_FL
      FROM
        ACC_EXPENSECENTER E (NOLOCK)
     WHERE
        E.EXPENSECENTERID = @ExpenseCenterId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ACC_EXPENSECENTER
     WHERE EXPENSECENTERID = @ExpenseCenterId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
