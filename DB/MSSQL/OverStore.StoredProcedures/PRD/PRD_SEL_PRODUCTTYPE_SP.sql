-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_PRODUCTTYPE_SP
    @ProductTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PRODUCTTYPEID,
           P.PRODUCTTYPE_NM,
           P.FAMILY,
           P.COMMENT_DSC      
      FROM PRD_PRODUCTTYPE P (NOLOCK)
     WHERE P.PRODUCTTYPEID = @ProductTypeId;

    /*Section="End"*/
END;
