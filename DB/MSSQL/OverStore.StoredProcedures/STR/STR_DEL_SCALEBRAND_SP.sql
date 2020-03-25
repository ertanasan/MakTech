-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_SCALEBRAND_SP
    @ScaleBrandId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_SCALEBRANDLOG
    (
        SCALEBRANDID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BRAND_NM,
        COMMENT_DSC    )    
    SELECT
        SCALEBRANDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BRAND_NM,
        COMMENT_DSC
      FROM
        STR_SCALEBRAND S (NOLOCK)
     WHERE
        S.SCALEBRANDID = @ScaleBrandId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_SCALEBRAND
     WHERE SCALEBRANDID = @ScaleBrandId;

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
