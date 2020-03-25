-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_ATTRIBUTECHOICE_SP
    @Attribute INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           A.ATTRIBUTECHOICEID,
           A.ATTRIBUTE,
           A.CHOICE_NM,
           A.DISPLAYORDER_NO,
           A.PRIORITYPOINT_NO
      FROM HDK_ATTRIBUTECHOICE A (NOLOCK)
     WHERE (@Attribute IS NULL OR A.ATTRIBUTE = @Attribute)
     ORDER BY CHOICE_NM;

/*Section="End"*/
END;
