-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_UNIT_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           U.UNITID,
           U.UNIT_NM,
           U.COMMENT_DSC
      FROM PRD_UNIT U (NOLOCK)
     ORDER BY UNIT_NM;

/*Section="End"*/
END;
