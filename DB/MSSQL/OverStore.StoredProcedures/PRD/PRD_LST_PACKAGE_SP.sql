-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_PACKAGE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PACKAGEID,
           P.PACKAGE_NM,
           P.PARENTPACKAGE,
           P.AMOUNT_AMT,
           P.COMMENT_DSC
      FROM PRD_PACKAGE P (NOLOCK)
     ORDER BY PACKAGE_NM;

/*Section="End"*/
END;
