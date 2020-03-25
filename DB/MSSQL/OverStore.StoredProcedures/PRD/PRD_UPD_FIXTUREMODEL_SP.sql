-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_FIXTUREMODEL_SP
    @FixtureModelId INT,
    @Brand          INT,
    @ModelName      VARCHAR(100)
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
        MODEL_NM
    )    
    SELECT
        FIXTUREMODELID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BRAND,
        MODEL_NM
      FROM
        PRD_FIXTUREMODEL F (NOLOCK)
     WHERE
        F.FIXTUREMODELID = @FixtureModelId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_FIXTUREMODEL
       SET
           BRAND = @Brand,
           MODEL_NM = @ModelName
     WHERE FIXTUREMODELID = @FixtureModelId;

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
