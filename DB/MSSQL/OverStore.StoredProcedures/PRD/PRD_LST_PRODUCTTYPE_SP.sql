-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_PRODUCTTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PRODUCTTYPEID,
           P.PRODUCTTYPE_NM,
           P.FAMILY,
           P.COMMENT_DSC
      FROM PRD_PRODUCTTYPE P (NOLOCK)
     ORDER BY PRODUCTTYPE_NM;

/*Section="End"*/
END;
