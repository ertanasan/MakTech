-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_FIXTUREBRAND_SP
    @FixtureBrandId INT
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
        BRAND_NM    )    
    SELECT
        FIXTUREBRANDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIXTURE,
        BRAND_NM
      FROM
        PRD_FIXTUREBRAND F (NOLOCK)
     WHERE
        F.FIXTUREBRANDID = @FixtureBrandId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_FIXTUREBRAND
     WHERE FIXTUREBRANDID = @FixtureBrandId;

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
