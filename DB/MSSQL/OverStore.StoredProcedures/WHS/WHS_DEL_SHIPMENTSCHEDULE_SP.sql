﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE [dbo].[WHS_DEL_SHIPMENTSCHEDULE_SP]
    @ShipmentScheduleId INT
AS
BEGIN
	
	INSERT INTO WHS_SHIPMENTSCHEDULELOG	
	  (SHIPMENTSCHEDULEID 
		, LOG_DT 
		, LOGUSER 
		, LOGOPERATION_CD
		, LOGCHANNEL 
		, LOGBRANCH 
		, LOGSCREEN 
		, SHIPMENTSCHEDULE_NM
		, STORE 
		, SCHEDULE_TXT 
		, COMMENT_DSC)
	  SELECT  SS.SHIPMENTSCHEDULEID,	GETDATE(),  dbo.SYS_GETCURRENTUSER_FN(),  'DEL',  dbo.SYS_GETCURRENTCHANNEL_FN(),  
			  dbo.SYS_GETCURRENTBRANCH_FN(),  dbo.SYS_GETCURRENTSCREEN_FN(),  SS.SHIPMENTSCHEDULE_NM,
			  SS.STORE, SS.SCHEDULE_TXT, SS.COMMENT_DSC
	     FROM WHS_SHIPMENTSCHEDULE SS (NOLOCK)  
        WHERE SS.SHIPMENTSCHEDULEID = @ShipmentScheduleId; 

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE WHS_SHIPMENTSCHEDULE
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE SHIPMENTSCHEDULEID = @ShipmentScheduleId

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
