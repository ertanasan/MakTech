-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_COUNTRY_SP
    @CountryId   INT,
    @CountryName VARCHAR(100),
    @Comment     VARCHAR(1000)
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
        COMMENT_DSC
    )
    SELECT
        COUNTRYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTRY_NM,
        COMMENT_DSC
      FROM
        PRD_COUNTRY C (NOLOCK)
     WHERE
        C.COUNTRYID = @CountryId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_COUNTRY
       SET
           COUNTRY_NM = @CountryName,
           COMMENT_DSC = @Comment
     WHERE COUNTRYID = @CountryId;

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
