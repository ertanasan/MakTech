-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_PACKAGETYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PACKAGETYPEID,
           P.PACKAGETYPE_NM
      FROM WHS_PACKAGETYPE P (NOLOCK)
     ORDER BY PACKAGETYPE_NM;

/*Section="End"*/
END;
