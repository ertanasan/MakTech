-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDPROPERTYTYPE_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           P.PROPERTYTYPEID,
           P.PROPERTYTYPE_NM,
           P.COMMENT_DSC      
      FROM PRD_PROPERTYTYPE P (NOLOCK)
     WHERE P.PROPERTYTYPE_NM = @Name;

/*Section="End"*/
END;
