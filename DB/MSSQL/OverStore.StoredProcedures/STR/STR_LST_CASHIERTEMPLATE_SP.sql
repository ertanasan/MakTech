-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_CASHIERTEMPLATE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CASHIERTEMPLATEID,
           C.CASHIERTEMPLATE_NM
      FROM STR_CASHIERTEMPLATE C (NOLOCK);

/*Section="End"*/
END;
