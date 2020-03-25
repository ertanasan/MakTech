-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_FIRMTYPE_SP
    @FirmTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           F.FIRMTYPEID,
           F.FIRMTYPE_NM      
      FROM ACC_FIRMTYPE F (NOLOCK)
     WHERE F.FIRMTYPEID = @FirmTypeId;

    /*Section="End"*/
END;
