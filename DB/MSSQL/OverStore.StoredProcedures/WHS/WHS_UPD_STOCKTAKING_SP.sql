CREATE PROCEDURE WHS_UPD_STOCKTAKING_SP
    @StockTakingId       BIGINT,
    @Event               INT,
    @Organization        INT,
    @Store               INT,
    @CountingDate        DATETIME,
    @Product             INT,
    @CountingValue       NUMERIC(10,3),
    @Zone                INT,
    @StockTakingSchedule BIGINT
AS
BEGIN
    INSERT INTO WHS_STOCKTAKINGLOG
    (STOCKTAKINGID, LOG_DT, LOGUSER, LOGOPERATION_CD, LOGCHANNEL, LOGBRANCH, LOGSCREEN, STORE, COUNTING_DT, PRODUCT, COUNTINGVALUE_AMT, ZONE, STOCKTAKINGSCHEDULE)
    SELECT STOCKTAKINGID, GETDATE(), dbo.SYS_GETCURRENTUSER_FN(), 'UPD', dbo.SYS_GETCURRENTCHANNEL_FN(), dbo.SYS_GETCURRENTBRANCH_FN(), dbo.SYS_GETCURRENTSCREEN_FN(),
           STORE, COUNTING_DT, PRODUCT, COUNTINGVALUE_AMT, ZONE, STOCKTAKINGSCHEDULE
      FROM WHS_STOCKTAKING (NOLOCK)
     WHERE STOCKTAKINGID = @StockTakingId

    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    SET NOCOUNT OFF;
    UPDATE WHS_STOCKTAKING
       SET UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           COUNTING_DT = @CountingDate,
           PRODUCT = @Product,
           COUNTINGVALUE_AMT = @CountingValue,
           ZONE = @Zone,
           STOCKTAKINGSCHEDULE = @StockTakingSchedule
     WHERE STOCKTAKINGID = @StockTakingId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

END;