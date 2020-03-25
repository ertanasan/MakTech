-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_LST_SUGGESTIONTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUGGESTIONTYPEID,
           S.SUGGESTIONTYPE_NM
      FROM ANN_SUGGESTIONTYPE S (NOLOCK)
     ORDER BY SUGGESTIONTYPE_NM;

/*Section="End"*/
END;
