-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_LST_NOTIFICATIONTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           N.NOTIFICATIONTYPEID,
           N.NOTIFICATIONTYPE_NM,
           N.DESCRIPTION_DSC
      FROM ANN_NOTIFICATIONTYPE N (NOLOCK)
     ORDER BY NOTIFICATIONTYPE_NM;

/*Section="End"*/
END;
