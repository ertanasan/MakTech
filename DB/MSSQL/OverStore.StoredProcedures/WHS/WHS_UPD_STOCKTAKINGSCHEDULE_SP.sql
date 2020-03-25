CREATE PROCEDURE [dbo].[WHS_UPD_STOCKTAKINGSCHEDULE_SP]
    @StockTakingScheduleId BIGINT,
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
    UPDATE WHS_STOCKTAKINGSCHEDULE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SCHEDULE_NM = @ScheduleName,
           STORE = @Store,
           COUNTINGTYPE = @CountingType,
           PLANNED_DT = CAST(@PlannedDate AS DATE),
           ACTUAL_DT = CAST(@ActualDate AS DATE),
           STATUS = @CountingStatus
     WHERE STOCKTAKINGSCHEDULEID = @StockTakingScheduleId     
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