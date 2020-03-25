-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_GATHERING_SP
    @GatheringId        BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_GATHERING
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STOREORDER,
        GATHERINGUSER,
        GATHERINGSTART_TM,
        GATHERINGEND_TM,
        GATHERINGSTATUS,
        GATHERINGTYPE,
        PRIORITY_NO
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StoreOrder,
        @GatheringUser,
        @GatheringStartTime,
        @GatheringEndTime,
        @GatheringStatus,
        @GatheringType,
        @Priority
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @GatheringId = SCOPE_IDENTITY();

	/*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @GatheringId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StoreOrder,
        @GatheringUser,
        @GatheringStartTime,
        @GatheringEndTime,
        @GatheringStatus,
        @GatheringType,
        @Priority
	);
/*Section="End"*/
END;
