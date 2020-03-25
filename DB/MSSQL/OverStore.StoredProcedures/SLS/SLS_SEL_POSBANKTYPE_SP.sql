-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_POSBANKTYPE_SP
    @PosBankTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.POSBANKTYPEID,
           P.BANKTYPE_NM      
      FROM SLS_POSBANKTYPE P (NOLOCK)
     WHERE P.POSBANKTYPEID = @PosBankTypeId;

    /*Section="End"*/
END;
