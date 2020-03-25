-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_FIXTURE_SP
    @FixtureId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_FIXTURELOG
    (
        FIXTUREID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIXTURE_NM    )    
    SELECT
        FIXTUREID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIXTURE_NM
      FROM
        PRD_FIXTURE F (NOLOCK)
     WHERE
        F.FIXTUREID = @FixtureId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_FIXTURE
     WHERE FIXTUREID = @FixtureId;

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
