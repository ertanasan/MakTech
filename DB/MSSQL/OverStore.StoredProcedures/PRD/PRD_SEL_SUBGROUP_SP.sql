-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_SUBGROUP_SP
    @SubgroupID INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUBGROUPID,
           S.SUBGROUP_NM,
           S.CATEGORY,
           S.COMMENT_DSC      
      FROM PRD_SUBGROUP S (NOLOCK)
     WHERE S.SUBGROUPID = @SubgroupID;

    /*Section="End"*/
END;
