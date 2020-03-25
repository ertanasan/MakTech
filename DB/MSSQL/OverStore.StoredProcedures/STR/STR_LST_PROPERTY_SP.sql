-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE [dbo].[STR_LST_PROPERTY_SP]
@Store INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.STORE,
           P.PROPERTYTYPE,
           P.VALUE_TXT,
           P.PROPERTYID
      FROM STR_PROPERTY P (NOLOCK)
	  WHERE (@Store IS NULL OR P.STORE = @Store)
     ORDER BY STORE;

/*Section="End"*/
END;