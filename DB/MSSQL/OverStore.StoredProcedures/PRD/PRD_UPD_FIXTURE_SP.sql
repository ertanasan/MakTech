-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_FIXTURE_SP
    @FixtureId   INT,
    @FixtureName VARCHAR(100)
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
        FIXTURE_NM
    )    
    SELECT
        FIXTUREID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIXTURE_NM
      FROM
        PRD_FIXTURE F (NOLOCK)
     WHERE
        F.FIXTUREID = @FixtureId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_FIXTURE
       SET
           FIXTURE_NM = @FixtureName
     WHERE FIXTUREID = @FixtureId;

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
