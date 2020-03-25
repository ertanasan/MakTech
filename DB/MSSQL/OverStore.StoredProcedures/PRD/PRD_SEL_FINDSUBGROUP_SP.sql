-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDSUBGROUP_SP
    @SubgroupName VARCHAR(100)
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
     WHERE S.SUBGROUP_NM = @SubgroupName;

/*Section="End"*/
END;
