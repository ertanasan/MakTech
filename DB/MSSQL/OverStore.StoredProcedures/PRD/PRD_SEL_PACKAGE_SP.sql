-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_PACKAGE_SP
    @PackageId INT
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
     WHERE P.PACKAGEID = @PackageId;

    /*Section="End"*/
END;
