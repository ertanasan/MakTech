-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_PROPERTY_SP
    @PropertyId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.STORE,
           P.PROPERTYTYPE,
           P.VALUE_TXT,
           P.PROPERTYID      
      FROM STR_PROPERTY P (NOLOCK)
     WHERE P.PROPERTYID = @PropertyId;

    /*Section="End"*/
END;
