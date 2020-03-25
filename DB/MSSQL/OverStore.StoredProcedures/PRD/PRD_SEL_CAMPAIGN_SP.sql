-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_CAMPAIGN_SP
    @ProductCampaignId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CAMPAIGNID,
           C.NAME_NM,
           C.IMAGEPATH_TXT,
           C.ACTIVE_FL,
           C.COMMENT_DSC      
      FROM PRD_CAMPAIGN C (NOLOCK)
     WHERE C.CAMPAIGNID = @ProductCampaignId;

    /*Section="End"*/
END;
