-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_FINDPOSBANKTYPE_SP
    @BankType VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           P.POSBANKTYPEID,
           P.BANKTYPE_NM      
      FROM SLS_POSBANKTYPE P (NOLOCK)
     WHERE P.BANKTYPE_NM = @BankType;

/*Section="End"*/
END;
