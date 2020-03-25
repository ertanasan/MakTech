-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_ACTION_SP
    @StoreActionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           A.ACTIONID,
           A.ACTION_NM      
      FROM STR_ACTION A (NOLOCK)
     WHERE A.ACTIONID = @StoreActionId;

    /*Section="End"*/
END;
