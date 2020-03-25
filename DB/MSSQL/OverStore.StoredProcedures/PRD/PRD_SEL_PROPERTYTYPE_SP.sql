-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_PROPERTYTYPE_SP
    @PropertyTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PROPERTYTYPEID,
           P.PROPERTYTYPE_NM,
           P.COMMENT_DSC      
      FROM PRD_PROPERTYTYPE P (NOLOCK)
     WHERE P.PROPERTYTYPEID = @PropertyTypeId;

    /*Section="End"*/
END;
