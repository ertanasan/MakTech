-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_ATTRIBUTE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
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
     ORDER BY ATTRIBUTE_NM;

/*Section="End"*/
END;
