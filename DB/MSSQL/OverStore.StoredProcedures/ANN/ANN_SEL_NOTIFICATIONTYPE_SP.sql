-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_NOTIFICATIONTYPE_SP
    @NotificationTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           N.NOTIFICATIONTYPEID,
           N.NOTIFICATIONTYPE_NM,
           N.DESCRIPTION_DSC      
      FROM ANN_NOTIFICATIONTYPE N (NOLOCK)
     WHERE N.NOTIFICATIONTYPEID = @NotificationTypeId;

    /*Section="End"*/
END;
