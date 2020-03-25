-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_TRANSACTIONTYPE_SP
    @TransactionTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           T.TRANSACTIONTYPEID,
           T.TRANSACTION_NM      
      FROM SLS_TRANSACTIONTYPE T (NOLOCK)
     WHERE T.TRANSACTIONTYPEID = @TransactionTypeId;

    /*Section="End"*/
END;
