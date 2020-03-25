-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_GATHERING_SP
    @GatheringId        BIGINT,
    @Event              INT,
    @Organization       INT,
    @StoreOrder         BIGINT,
    @GatheringUser      INT,
    @GatheringStartTime DATETIME,
    @GatheringEndTime   DATETIME,
    @GatheringStatus    INT,
    @GatheringType      INT,
    @Priority           INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_GATHERINGLOG
    (
        GATHERINGID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STOREORDER,
        GATHERINGUSER,
        GATHERINGSTART_TM,
        GATHERINGEND_TM,
        GATHERINGSTATUS,
        GATHERINGTYPE,
        PRIORITY_NO
	)
    SELECT
        GATHERINGID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STOREORDER,
        GATHERINGUSER,
        GATHERINGSTART_TM,
        GATHERINGEND_TM,
        GATHERINGSTATUS,
        GATHERINGTYPE,
        PRIORITY_NO
      FROM
        WHS_GATHERING G (NOLOCK)
     WHERE
        G.GATHERINGID = @GatheringId;
	
	/*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_GATHERING
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STOREORDER = @StoreOrder,
           GATHERINGUSER = @GatheringUser,
           GATHERINGSTART_TM = @GatheringStartTime,
           GATHERINGEND_TM = @GatheringEndTime,
           GATHERINGSTATUS = @GatheringStatus,
           GATHERINGTYPE = @GatheringType,
           PRIORITY_NO = @Priority
     WHERE GATHERINGID = @GatheringId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
