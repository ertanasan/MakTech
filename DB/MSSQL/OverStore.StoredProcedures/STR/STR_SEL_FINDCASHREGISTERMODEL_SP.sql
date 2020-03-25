-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_FINDCASHREGISTERMODEL_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           C.CASHREGISTERMODELID,
           C.BRAND,
           C.MODEL_NM,
           C.COMMENT_DSC      
      FROM STR_CASHREGISTERMODEL C (NOLOCK)
     WHERE C.MODEL_NM = @Name;

/*Section="End"*/
END;
