-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_PROCESSDEF_SP
    @ProcessDefinitionId   INT,
    @ProcessDefinitionName VARCHAR(100),
    @ProcessNo             INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_PROCESSDEFLOG
    (
        PROCESSDEFID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROCESSDEF_NM,
        PROCESS_NO
    )
    SELECT
        PROCESSDEFID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROCESSDEF_NM,
        PROCESS_NO
      FROM
        HDK_PROCESSDEF P (NOLOCK)
     WHERE
        P.PROCESSDEFID = @ProcessDefinitionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_PROCESSDEF
       SET
           PROCESSDEF_NM = @ProcessDefinitionName,
           PROCESS_NO = @ProcessNo
     WHERE PROCESSDEFID = @ProcessDefinitionId;

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
