-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_SEASONTYPE_SP
    @SeasonTypeId   INT,
    @SeasonTypeName VARCHAR(100),
    @Comment        VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_SEASONTYPELOG
    (
        SEASONTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SEASONTYPE_NM,
        COMMENT_DSC
    )
    SELECT
        SEASONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SEASONTYPE_NM,
        COMMENT_DSC
      FROM
        PRD_SEASONTYPE S (NOLOCK)
     WHERE
        S.SEASONTYPEID = @SeasonTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_SEASONTYPE
       SET
           SEASONTYPE_NM = @SeasonTypeName,
           COMMENT_DSC = @Comment
     WHERE SEASONTYPEID = @SeasonTypeId;

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
