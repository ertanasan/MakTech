-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_SCALEBRAND_SP
    @ScaleBrandId INT,
    @Name         VARCHAR(100),
    @Description  VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        SCALEBRANDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BRAND_NM,
        COMMENT_DSC
      FROM
        STR_SCALEBRAND S (NOLOCK)
     WHERE
        S.SCALEBRANDID = @ScaleBrandId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_SCALEBRAND
       SET
           BRAND_NM = @Name,
           COMMENT_DSC = @Description
     WHERE SCALEBRANDID = @ScaleBrandId;

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
