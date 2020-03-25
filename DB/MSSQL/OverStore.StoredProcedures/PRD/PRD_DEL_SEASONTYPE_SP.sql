-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_SEASONTYPE_SP
    @SeasonTypeId INT
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
        COMMENT_DSC    )    
    SELECT
        SEASONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SEASONTYPE_NM,
        COMMENT_DSC
      FROM
        PRD_SEASONTYPE S (NOLOCK)
     WHERE
        S.SEASONTYPEID = @SeasonTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_SEASONTYPE
     WHERE SEASONTYPEID = @SeasonTypeId;

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
