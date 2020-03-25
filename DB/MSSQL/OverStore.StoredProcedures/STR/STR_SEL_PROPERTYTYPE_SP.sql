-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_PROPERTYTYPE_SP
    @StorePropertyId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PROPERTYTYPEID,
           P.PROPERTYTYPE_NM
      FROM STR_PROPERTYTYPE P (NOLOCK)
     WHERE P.PROPERTYTYPEID = @StorePropertyId;

    /*Section="End"*/
END;
