-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_FINDFIRMTYPE_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           F.FIRMTYPEID,
           F.FIRMTYPE_NM      
      FROM ACC_FIRMTYPE F (NOLOCK)
     WHERE F.FIRMTYPE_NM = @Name;

/*Section="End"*/
END;
