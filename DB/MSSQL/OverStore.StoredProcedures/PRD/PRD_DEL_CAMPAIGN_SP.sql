-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_CAMPAIGN_SP
    @ProductCampaignId INT
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
        COMMENT_DSC    )    
    SELECT
        CAMPAIGNID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_CAMPAIGN
     WHERE CAMPAIGNID = @ProductCampaignId;

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
