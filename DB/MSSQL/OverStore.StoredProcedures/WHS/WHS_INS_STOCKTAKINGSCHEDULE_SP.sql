
CREATE PROCEDURE WHS_INS_STOCKTAKINGSCHEDULE_SP  
    @StockTakingScheduleId BIGINT OUT,  
    @Event                 INT,  
    @Organization          INT,  
    @ScheduleName          VARCHAR(100),  
    @Store                 INT,  
    @CountingType          INT,  
    @PlannedDate           DATETIME,  
    @ActualDate            DATETIME,  
    @CountingStatus        INT  
AS  
BEGIN  
    /*Section="Insert"*/  
    SET NOCOUNT OFF  
    -- Insert record  
    INSERT INTO WHS_STOCKTAKINGSCHEDULE  
    (  
        EVENT,  
        ORGANIZATION,  
        DELETED_FL,  
        CREATE_DT,  
        CREATEUSER,  
        CREATECHANNEL,  
        CREATEBRANCH,  
        CREATESCREEN,  
        SCHEDULE_NM,  
        STORE,  
        COUNTINGTYPE,  
        PLANNED_DT,  
        ACTUAL_DT,  
        STATUS  
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
        @ScheduleName,  
        @Store,  
        @CountingType,  
        CAST(@PlannedDate AS date),  
        CAST(@ActualDate AS date),  
        @CountingStatus  
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
    SELECT @StockTakingScheduleId = SCOPE_IDENTITY();  
/*Section="End"*/  
END;  
