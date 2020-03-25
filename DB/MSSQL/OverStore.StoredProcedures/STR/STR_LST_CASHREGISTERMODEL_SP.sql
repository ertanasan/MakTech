-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_CASHREGISTERMODEL_SP
    @Brand INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CASHREGISTERMODELID,
           C.BRAND,
           C.MODEL_NM,
           C.COMMENT_DSC
      FROM STR_CASHREGISTERMODEL C (NOLOCK)
     WHERE (@Brand IS NULL OR C.BRAND = @Brand)
     ORDER BY MODEL_NM;

/*Section="End"*/
END;
