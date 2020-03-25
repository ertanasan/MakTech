-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_UNIT_SP
    @UnitId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           U.UNITID,
           U.UNIT_NM,
           U.COMMENT_DSC      
      FROM PRD_UNIT U (NOLOCK)
     WHERE U.UNITID = @UnitId;

    /*Section="End"*/
END;
