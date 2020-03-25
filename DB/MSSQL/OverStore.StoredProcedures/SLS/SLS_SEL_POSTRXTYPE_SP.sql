-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_POSTRXTYPE_SP
    @PosTrxTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.POSTRXTYPEID,
           P.TRXTYPE_NM      
      FROM SLS_POSTRXTYPE P (NOLOCK)
     WHERE P.POSTRXTYPEID = @PosTrxTypeId;

    /*Section="End"*/
END;
