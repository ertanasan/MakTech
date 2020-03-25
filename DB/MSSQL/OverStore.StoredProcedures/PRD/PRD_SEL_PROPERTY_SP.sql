-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_PROPERTY_SP
    @ProductPropertyId INT
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
     WHERE P.PROPERTYID = @ProductPropertyId;

    /*Section="End"*/
END;
