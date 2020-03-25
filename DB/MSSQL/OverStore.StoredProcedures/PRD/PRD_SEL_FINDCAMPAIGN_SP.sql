-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDCAMPAIGN_SP
    @Name VARCHAR(100)
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
     WHERE C.NAME_NM = @Name;

/*Section="End"*/
END;
