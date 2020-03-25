-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_SUBGROUP_SP
    @Category INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUBGROUPID,
           S.SUBGROUP_NM,
           S.CATEGORY,
           S.COMMENT_DSC
      FROM PRD_SUBGROUP S (NOLOCK)
     WHERE (@Category IS NULL OR S.CATEGORY = @Category)
     ORDER BY SUBGROUP_NM;

/*Section="End"*/
END;
