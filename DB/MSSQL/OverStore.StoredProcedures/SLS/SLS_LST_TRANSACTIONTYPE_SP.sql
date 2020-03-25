-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_LST_TRANSACTIONTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           T.TRANSACTIONTYPEID,
           T.TRANSACTION_NM
      FROM SLS_TRANSACTIONTYPE T (NOLOCK)
     ORDER BY TRANSACTION_NM;

/*Section="End"*/
END;
