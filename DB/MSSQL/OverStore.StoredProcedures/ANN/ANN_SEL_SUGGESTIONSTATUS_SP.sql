-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_SUGGESTIONSTATUS_SP
    @SuggestionStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUGGESTIONSTATUSID,
           S.STATUS_NM      
      FROM ANN_SUGGESTIONSTATUS S (NOLOCK)
     WHERE S.SUGGESTIONSTATUSID = @SuggestionStatusId;

    /*Section="End"*/
END;
