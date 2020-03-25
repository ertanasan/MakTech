-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDPACKAGE_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           P.PACKAGEID,
           P.PACKAGE_NM,
           P.PARENTPACKAGE,
           P.AMOUNT_AMT,
           P.COMMENT_DSC
      FROM PRD_PACKAGE P (NOLOCK)
     WHERE P.PACKAGE_NM = @Name;

/*Section="End"*/
END;
