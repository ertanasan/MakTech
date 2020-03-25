-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_SHIPMENTSCHEDULE_SP
    @ShipmentScheduleId INT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Select
    SELECT
           S.SHIPMENTSCHEDULEID,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.SHIPMENTSCHEDULE_NM,
           S.STORE,
           S.SCHEDULE_TXT,
           S.COMMENT_DSC      
      FROM WHS_SHIPMENTSCHEDULE S (NOLOCK)
     WHERE S.SHIPMENTSCHEDULEID = @ShipmentScheduleId     
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
