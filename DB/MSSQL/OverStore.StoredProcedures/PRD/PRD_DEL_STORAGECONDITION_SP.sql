-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_STORAGECONDITION_SP
    @StorageConditionId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_STORAGECONDITIONLOG
    (
        STORAGECONDITIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CONDITION_TXT,
        COMMENT_DSC    )
    SELECT
        STORAGECONDITIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CONDITION_TXT,
        COMMENT_DSC
      FROM
        PRD_STORAGECONDITION S (NOLOCK)
     WHERE
        S.STORAGECONDITIONID = @StorageConditionId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_STORAGECONDITION
     WHERE STORAGECONDITIONID = @StorageConditionId;

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
