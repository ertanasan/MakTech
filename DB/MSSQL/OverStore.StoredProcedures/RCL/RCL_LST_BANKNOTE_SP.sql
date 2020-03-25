-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_BANKNOTE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           B.BANKNOTEID,
           B.BANKNOTE_AMT,
           B.COIN_FL
      FROM RCL_BANKNOTE B (NOLOCK)
     ORDER BY BANKNOTE_AMT;

/*Section="End"*/
END;
