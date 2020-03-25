-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_ATTRIBUTE_SP
    @RequestAttributeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           A.ATTRIBUTEID,
           A.ATTRIBUTE_NM,
           A.REQUESTGROUP,
           A.REQUESTDEFINITION,
           A.ATTRIBUTETYPE,
           A.EDITABLE_FL,
           A.REQUIRED_FL,
           A.DISPLAYORDER_NO
      FROM HDK_ATTRIBUTE A (NOLOCK)
     WHERE A.ATTRIBUTEID = @RequestAttributeId;

    /*Section="End"*/
END;
