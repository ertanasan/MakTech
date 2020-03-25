-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_SEARCHPACKAGE_SP
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
    -- WHERE (@ParentPackage IS NULL OR P.PARENTPACKAGE = @ParentPackage);

/*Section="End"*/
END;
