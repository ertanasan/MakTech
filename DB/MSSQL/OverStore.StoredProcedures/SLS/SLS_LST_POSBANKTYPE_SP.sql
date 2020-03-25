-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_LST_POSBANKTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.POSBANKTYPEID,
           P.BANKTYPE_NM
      FROM SLS_POSBANKTYPE P (NOLOCK)
     ORDER BY BANKTYPE_NM;

/*Section="End"*/
END;
