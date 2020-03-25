-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_FIXTUREMODEL_SP
    @FixtureModelId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_FIXTUREMODELLOG
    (
        FIXTUREMODELID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BRAND,
        MODEL_NM    )    
    SELECT
        FIXTUREMODELID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BRAND,
        MODEL_NM
      FROM
        PRD_FIXTUREMODEL F (NOLOCK)
     WHERE
        F.FIXTUREMODELID = @FixtureModelId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_FIXTUREMODEL
     WHERE FIXTUREMODELID = @FixtureModelId;

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
