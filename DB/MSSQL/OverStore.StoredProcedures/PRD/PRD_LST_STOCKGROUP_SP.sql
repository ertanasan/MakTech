-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_STOCKGROUP_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.PRODUCTID,
           S.STOCKGROUP,
           S.STOCKGROUPID
      FROM PRD_STOCKGROUP S (NOLOCK)
     ORDER BY STOCKGROUP;

/*Section="End"*/
END;
