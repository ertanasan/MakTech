-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_ATTRIBUTECHOICE_SP
    @AttributeChoiceId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           A.ATTRIBUTECHOICEID,
           A.ATTRIBUTE,
           A.CHOICE_NM,
           A.DISPLAYORDER_NO,
           A.PRIORITYPOINT_NO
      FROM HDK_ATTRIBUTECHOICE A (NOLOCK)
     WHERE A.ATTRIBUTECHOICEID = @AttributeChoiceId;

    /*Section="End"*/
END;
