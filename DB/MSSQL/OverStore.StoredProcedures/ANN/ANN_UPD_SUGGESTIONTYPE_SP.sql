-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_SUGGESTIONTYPE_SP
    @SuggestionTypeId   INT,
    @SuggestionTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ANN_SUGGESTIONTYPELOG
    (
        SUGGESTIONTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUGGESTIONTYPE_NM
    )    
    SELECT
        SUGGESTIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUGGESTIONTYPE_NM
      FROM
        ANN_SUGGESTIONTYPE S (NOLOCK)
     WHERE
        S.SUGGESTIONTYPEID = @SuggestionTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ANN_SUGGESTIONTYPE
       SET
           SUGGESTIONTYPE_NM = @SuggestionTypeName
     WHERE SUGGESTIONTYPEID = @SuggestionTypeId;

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
