-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_SCALEMODEL_SP
    @ScaleModelId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SCALEMODELID,
           S.BRAND,
           S.MODEL_NM,
           S.COMMENT_DSC      
      FROM STR_SCALEMODEL S (NOLOCK)
     WHERE S.SCALEMODELID = @ScaleModelId;

    /*Section="End"*/
END;
