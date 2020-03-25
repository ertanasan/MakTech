-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_PROMOTIONTYPE_SP
    @PromotionTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PROMOTIONTYPEID,
           P.PROMOTIONTYPE_NM,
           P.COMMENT_DSC      
      FROM PRC_PROMOTIONTYPE P (NOLOCK)
     WHERE P.PROMOTIONTYPEID = @PromotionTypeId;

    /*Section="End"*/
END;
