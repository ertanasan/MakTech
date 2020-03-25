-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_FIXTUREBRAND_SP
    @FixtureBrandId INT,
    @Fixture        INT,
    @BrandName      VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_FIXTUREBRANDLOG
    (
        FIXTUREBRANDID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIXTURE,
        BRAND_NM
    )    
    SELECT
        FIXTUREBRANDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIXTURE,
        BRAND_NM
      FROM
        PRD_FIXTUREBRAND F (NOLOCK)
     WHERE
        F.FIXTUREBRANDID = @FixtureBrandId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_FIXTUREBRAND
       SET
           FIXTURE = @Fixture,
           BRAND_NM = @BrandName
     WHERE FIXTUREBRANDID = @FixtureBrandId;

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
