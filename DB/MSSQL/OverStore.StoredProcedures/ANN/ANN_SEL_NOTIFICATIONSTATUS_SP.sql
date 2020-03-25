-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_NOTIFICATIONSTATUS_SP
    @NotificationStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           N.NOTIFICATIONSTATUSID,
           N.NOTIFICATIONSTATUS_NM,
           N.DESCRIPTION_DSC      
      FROM ANN_NOTIFICATIONSTATUS N (NOLOCK)
     WHERE N.NOTIFICATIONSTATUSID = @NotificationStatusId;

    /*Section="End"*/
END;
