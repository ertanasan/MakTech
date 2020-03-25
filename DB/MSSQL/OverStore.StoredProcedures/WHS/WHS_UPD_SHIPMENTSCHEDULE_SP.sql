/*Section="Main"*/
CREATE PROCEDURE [dbo].[WHS_UPD_SHIPMENTSCHEDULE_SP]
    @ShipmentScheduleId   INT,
    @ShipmentScheduleName VARCHAR(100),
    @Store                INT,
    @ScheduleDetail       VARCHAR(1000),
    @Comment              VARCHAR(200)
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
	  SELECT  SS.SHIPMENTSCHEDULEID,	GETDATE(),  dbo.SYS_GETCURRENTUSER_FN(),  'UPD',  dbo.SYS_GETCURRENTCHANNEL_FN(),  
			  dbo.SYS_GETCURRENTBRANCH_FN(),  dbo.SYS_GETCURRENTSCREEN_FN(),  SS.SHIPMENTSCHEDULE_NM,
			  SS.STORE, SS.SCHEDULE_TXT, SS.COMMENT_DSC
	     FROM WHS_SHIPMENTSCHEDULE SS (NOLOCK)  
        WHERE SS.SHIPMENTSCHEDULEID = @ShipmentScheduleId; 

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_SHIPMENTSCHEDULE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SHIPMENTSCHEDULE_NM = @ShipmentScheduleName,
           STORE = @Store,
           SCHEDULE_TXT = @ScheduleDetail,
           COMMENT_DSC = @Comment
     WHERE SHIPMENTSCHEDULEID = @ShipmentScheduleId

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
