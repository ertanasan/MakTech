-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDPROPERTY_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           P.PROPERTYID,
           P.PROPERTYTYPE,
           P.PRODUCT,
           P.VALUE_TXT
      FROM PRD_PROPERTY P (NOLOCK)

/*Section="End"*/
END;
