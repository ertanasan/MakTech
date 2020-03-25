-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_ATTRIBUTETYPE_SP
    @AttributeTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           A.ATTRIBUTETYPEID,
           A.ATTRIBUTETYPE_NM      
      FROM HDK_ATTRIBUTETYPE A (NOLOCK)
     WHERE A.ATTRIBUTETYPEID = @AttributeTypeId;

    /*Section="End"*/
END;
