-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_LST_PROMOTIONTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PROMOTIONTYPEID,
           P.PROMOTIONTYPE_NM,
           P.COMMENT_DSC
      FROM PRC_PROMOTIONTYPE P (NOLOCK)
     ORDER BY PROMOTIONTYPE_NM;

/*Section="End"*/
END;
