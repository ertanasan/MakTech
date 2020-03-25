-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_FINDNOTIFICATIONTYPE_SP
    @NotificationTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           N.NOTIFICATIONTYPEID,
           N.NOTIFICATIONTYPE_NM,
           N.DESCRIPTION_DSC      
      FROM ANN_NOTIFICATIONTYPE N (NOLOCK)
     WHERE N.NOTIFICATIONTYPE_NM = @NotificationTypeName;

/*Section="End"*/
END;
