-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_FIRMTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           F.FIRMTYPEID,
           F.FIRMTYPE_NM
      FROM ACC_FIRMTYPE F (NOLOCK)
     ORDER BY FIRMTYPEID;

/*Section="End"*/
END;
