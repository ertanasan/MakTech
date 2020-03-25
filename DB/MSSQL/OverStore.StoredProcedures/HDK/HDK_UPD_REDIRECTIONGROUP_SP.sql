-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_REDIRECTIONGROUP_SP
    @RedirectionGroupId INT,
    @GroupName          VARCHAR(100),
    @RequestDefinition  INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_REDIRECTIONGROUPLOG
    (
        REDIRECTIONGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GROUP_NM,
        REQUESTDEFINITION
    )    
    SELECT
        REDIRECTIONGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GROUP_NM,
        REQUESTDEFINITION
      FROM
        HDK_REDIRECTIONGROUP R (NOLOCK)
     WHERE
        R.REDIRECTIONGROUPID = @RedirectionGroupId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_REDIRECTIONGROUP
       SET
           GROUP_NM = @GroupName,
           REQUESTDEFINITION = @RequestDefinition
     WHERE REDIRECTIONGROUPID = @RedirectionGroupId;

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
