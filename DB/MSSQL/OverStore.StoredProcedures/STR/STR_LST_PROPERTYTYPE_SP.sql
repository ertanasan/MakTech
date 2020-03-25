-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_PROPERTYTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PROPERTYTYPEID,
           P.PROPERTYTYPE_NM
      FROM STR_PROPERTYTYPE P (NOLOCK)
     ORDER BY P.PROPERTYTYPE_NM;

/*Section="End"*/
END;
