-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_LST_POSTRXTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.POSTRXTYPEID,
           P.TRXTYPE_NM
      FROM SLS_POSTRXTYPE P (NOLOCK)
     ORDER BY TRXTYPE_NM;

/*Section="End"*/
END;
