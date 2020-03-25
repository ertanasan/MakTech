-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_DEL_SUGGESTIONSTATUS_SP
    @SuggestionStatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ANN_SUGGESTIONSTATUSLOG
    (
        SUGGESTIONSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM    )    
    SELECT
        SUGGESTIONSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        ANN_SUGGESTIONSTATUS S (NOLOCK)
     WHERE
        S.SUGGESTIONSTATUSID = @SuggestionStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ANN_SUGGESTIONSTATUS
     WHERE SUGGESTIONSTATUSID = @SuggestionStatusId;

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
