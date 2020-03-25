-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_STORAGECONDITION_SP
    @StorageConditionId INT,
    @Condition          VARCHAR(100),
    @Comment            VARCHAR(1000)
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
        COMMENT_DSC
    )
    SELECT
        STORAGECONDITIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CONDITION_TXT,
        COMMENT_DSC
      FROM
        PRD_STORAGECONDITION S (NOLOCK)
     WHERE
        S.STORAGECONDITIONID = @StorageConditionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_STORAGECONDITION
       SET
           CONDITION_TXT = @Condition,
           COMMENT_DSC = @Comment
     WHERE STORAGECONDITIONID = @StorageConditionId;

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
