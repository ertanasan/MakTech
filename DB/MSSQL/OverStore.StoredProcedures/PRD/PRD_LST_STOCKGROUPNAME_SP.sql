-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_STOCKGROUPNAME_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.STOCKGROUPID,
           S.STOCKGROUP_NM,
           S.USAGETYPE_CD
      FROM PRD_STOCKGROUPNAME S (NOLOCK)
     ORDER BY STOCKGROUP_NM;

/*Section="End"*/
END;
