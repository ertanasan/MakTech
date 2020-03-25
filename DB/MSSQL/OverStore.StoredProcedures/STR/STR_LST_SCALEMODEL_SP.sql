-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_SCALEMODEL_SP
    @Brand INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SCALEMODELID,
           S.BRAND,
           S.MODEL_NM,
           S.COMMENT_DSC
      FROM STR_SCALEMODEL S (NOLOCK)
     WHERE (@Brand IS NULL OR S.BRAND = @Brand)
     ORDER BY MODEL_NM;

/*Section="End"*/
END;
