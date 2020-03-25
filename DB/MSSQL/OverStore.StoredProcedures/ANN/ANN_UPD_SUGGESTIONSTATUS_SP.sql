-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_SUGGESTIONSTATUS_SP
    @SuggestionStatusId INT,
    @StatusName         VARCHAR(100)
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
        STATUS_NM
    )    
    SELECT
        SUGGESTIONSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM
      FROM
        ANN_SUGGESTIONSTATUS S (NOLOCK)
     WHERE
        S.SUGGESTIONSTATUSID = @SuggestionStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ANN_SUGGESTIONSTATUS
       SET
           STATUS_NM = @StatusName
     WHERE SUGGESTIONSTATUSID = @SuggestionStatusId;

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
