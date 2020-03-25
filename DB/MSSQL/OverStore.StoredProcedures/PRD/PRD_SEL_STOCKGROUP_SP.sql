-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_STOCKGROUP_SP
    @StockGroupId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.PRODUCTID,
           S.STOCKGROUP,
           S.STOCKGROUPID
      FROM PRD_STOCKGROUP S (NOLOCK)
     WHERE S.STOCKGROUPID = @StockGroupId;

    /*Section="End"*/
END;
