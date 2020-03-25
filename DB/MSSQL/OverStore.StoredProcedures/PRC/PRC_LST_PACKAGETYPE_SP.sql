-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_LST_PACKAGETYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PACKAGETYPEID,
           P.PACKAGETYPE_NM,
           P.COMMENT_DSC
      FROM PRC_PACKAGETYPE P (NOLOCK)
     ORDER BY PACKAGETYPEID;

/*Section="End"*/
END;
