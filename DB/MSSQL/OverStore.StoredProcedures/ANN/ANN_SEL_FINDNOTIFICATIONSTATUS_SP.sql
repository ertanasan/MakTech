-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_FINDNOTIFICATIONSTATUS_SP
    @NotificationStatusName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           N.NOTIFICATIONSTATUSID,
           N.NOTIFICATIONSTATUS_NM,
           N.DESCRIPTION_DSC      
      FROM ANN_NOTIFICATIONSTATUS N (NOLOCK)
     WHERE N.NOTIFICATIONSTATUS_NM = @NotificationStatusName;

/*Section="End"*/
END;
