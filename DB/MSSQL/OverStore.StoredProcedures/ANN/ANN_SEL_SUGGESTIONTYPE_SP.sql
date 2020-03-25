-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_SUGGESTIONTYPE_SP
    @SuggestionTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUGGESTIONTYPEID,
           S.SUGGESTIONTYPE_NM      
      FROM ANN_SUGGESTIONTYPE S (NOLOCK)
     WHERE S.SUGGESTIONTYPEID = @SuggestionTypeId;

    /*Section="End"*/
END;
