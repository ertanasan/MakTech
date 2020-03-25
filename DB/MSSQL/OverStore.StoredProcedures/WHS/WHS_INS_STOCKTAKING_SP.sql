-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_STOCKTAKING_SP
    @StockTakingId       BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_STOCKTAKING
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STORE,
        COUNTING_DT,
        PRODUCT,
        COUNTINGVALUE_AMT,
        ZONE,
        STOCKTAKINGSCHEDULE
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
        @Store,
        @CountingDate,
        @Product,
        @CountingValue,
        @Zone,
        @StockTakingSchedule
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
    SELECT @StockTakingId = SCOPE_IDENTITY();
/*Section="End"*/
END;
