-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_PROPERTYTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PROPERTYTYPEID,
           P.PROPERTYTYPE_NM,
           P.COMMENT_DSC
      FROM PRD_PROPERTYTYPE P (NOLOCK)
     ORDER BY PROPERTYTYPE_NM;

/*Section="End"*/
END;
