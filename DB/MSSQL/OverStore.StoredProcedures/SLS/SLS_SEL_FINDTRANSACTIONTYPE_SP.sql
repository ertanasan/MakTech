-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_FINDTRANSACTIONTYPE_SP
    @TransactionName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           T.TRANSACTIONTYPEID,
           T.TRANSACTION_NM      
      FROM SLS_TRANSACTIONTYPE T (NOLOCK)
     WHERE T.TRANSACTION_NM = @TransactionName;

/*Section="End"*/
END;
