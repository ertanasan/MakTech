-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_CAMPAIGN_SP
    @ProductCampaignId INT,
    @Name              VARCHAR(100),
    @ImagePath         VARCHAR(200),
    @Active            VARCHAR(1),
    @Comment           VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_CAMPAIGNLOG
    (
        CAMPAIGNID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        NAME_NM,
        IMAGEPATH_TXT,
        ACTIVE_FL,
        COMMENT_DSC
    )    
    SELECT
        CAMPAIGNID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        NAME_NM,
        IMAGEPATH_TXT,
        ACTIVE_FL,
        COMMENT_DSC
      FROM
        PRD_CAMPAIGN C (NOLOCK)
     WHERE
        C.CAMPAIGNID = @ProductCampaignId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_CAMPAIGN
       SET
           NAME_NM = @Name,
           IMAGEPATH_TXT = @ImagePath,
           ACTIVE_FL = @Active,
           COMMENT_DSC = @Comment
     WHERE CAMPAIGNID = @ProductCampaignId;

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
