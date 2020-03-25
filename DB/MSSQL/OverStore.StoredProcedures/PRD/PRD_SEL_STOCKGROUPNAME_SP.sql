-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_STOCKGROUPNAME_SP
    @StockGroupNameId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.STOCKGROUPID,
           S.STOCKGROUP_NM,
           S.USAGETYPE_CD
      FROM PRD_STOCKGROUPNAME S (NOLOCK)
     WHERE S.STOCKGROUPID = @StockGroupNameId;

    /*Section="End"*/
END;
