-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_PROPERTY_SP
    @Product INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PROPERTYID,
           P.PROPERTYTYPE,
           P.PRODUCT,
           P.VALUE_TXT
      FROM PRD_PROPERTY P (NOLOCK)
     WHERE (@Product IS NULL OR P.PRODUCT = @Product)
     ORDER BY PROPERTYID;

/*Section="End"*/
END;
