-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_BANKNOTE_SP
    @BanknoteId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           B.BANKNOTEID,
           B.BANKNOTE_AMT,
           B.COIN_FL      
      FROM RCL_BANKNOTE B (NOLOCK)
     WHERE B.BANKNOTEID = @BanknoteId;

    /*Section="End"*/
END;
