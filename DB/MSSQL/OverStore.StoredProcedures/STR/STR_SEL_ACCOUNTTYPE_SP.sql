-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_ACCOUNTTYPE_SP
    @StoreAccountTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           A.ACCOUNTTYPEID,
           A.ACCOUNTTYPE_NM      
      FROM STR_ACCOUNTTYPE A (NOLOCK)
     WHERE A.ACCOUNTTYPEID = @StoreAccountTypeId;

    /*Section="End"*/
END;
