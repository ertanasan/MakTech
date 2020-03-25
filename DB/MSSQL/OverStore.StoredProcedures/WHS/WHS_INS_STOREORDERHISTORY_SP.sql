-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_STOREORDERHISTORY_SP
    @StoreOrderHistoryId BIGINT OUT,
    @Event               INT,
    @Organization        INT,
    @StoreOrder          BIGINT,
    @HistoryTime         DATETIME,
    @Status              INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_STOREORDERHISTORY
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
        HISTORY_TM,
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
        @StoreOrder,
        @HistoryTime,
        @Status
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
    SELECT @StoreOrderHistoryId = SCOPE_IDENTITY();
/*Section="End"*/
END;
