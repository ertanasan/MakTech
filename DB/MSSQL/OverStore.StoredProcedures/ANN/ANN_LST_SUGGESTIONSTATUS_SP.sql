-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_LST_SUGGESTIONSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUGGESTIONSTATUSID,
           S.STATUS_NM
      FROM ANN_SUGGESTIONSTATUS S (NOLOCK)
     ORDER BY STATUS_NM;

/*Section="End"*/
END;
