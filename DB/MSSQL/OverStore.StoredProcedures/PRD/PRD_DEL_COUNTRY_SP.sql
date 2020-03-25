-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_COUNTRY_SP
    @CountryId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_COUNTRYLOG
    (
        COUNTRYID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTRY_NM,
        COMMENT_DSC    )    
    SELECT
        COUNTRYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTRY_NM,
        COMMENT_DSC
      FROM
        PRD_COUNTRY C (NOLOCK)
     WHERE
        C.COUNTRYID = @CountryId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_COUNTRY
     WHERE COUNTRYID = @CountryId;

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
