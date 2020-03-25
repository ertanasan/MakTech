-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_CAMPAIGN_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CAMPAIGNID,
           C.NAME_NM,
           C.IMAGEPATH_TXT,
           C.ACTIVE_FL,
           C.COMMENT_DSC
      FROM PRD_CAMPAIGN C (NOLOCK)
     ORDER BY NAME_NM;

/*Section="End"*/
END;
