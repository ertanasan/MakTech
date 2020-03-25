-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_ACCOUNTTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           A.ACCOUNTTYPEID,
           A.ACCOUNTTYPE_NM
      FROM STR_ACCOUNTTYPE A (NOLOCK)
     ORDER BY ACCOUNTTYPE_NM;

/*Section="End"*/
END;
