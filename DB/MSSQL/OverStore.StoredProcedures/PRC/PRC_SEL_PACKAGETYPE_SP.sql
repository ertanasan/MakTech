-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_PACKAGETYPE_SP
    @PackageTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PACKAGETYPEID,
           P.PACKAGETYPE_NM,
           P.COMMENT_DSC      
      FROM PRC_PACKAGETYPE P (NOLOCK)
     WHERE P.PACKAGETYPEID = @PackageTypeId;

    /*Section="End"*/
END;
