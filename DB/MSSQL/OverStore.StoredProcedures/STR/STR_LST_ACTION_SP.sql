-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_ACTION_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           A.ACTIONID,
           A.ACTION_NM
      FROM STR_ACTION A (NOLOCK)
     ORDER BY ACTION_NM;

/*Section="End"*/
END;
