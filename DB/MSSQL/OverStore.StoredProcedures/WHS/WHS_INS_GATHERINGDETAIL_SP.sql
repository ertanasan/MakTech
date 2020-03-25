-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_GATHERINGDETAIL_SP
    @GatheringDetailId BIGINT OUT,
    @Event             INT,
    @Organization      INT,
    @StoreOrderDetail  BIGINT,
    @GatheringTime     DATETIME = NULL,
    @Gathering         BIGINT,
    @GatheredQuantity  NUMERIC(12,6),
    @PalletNo          INT,
    @ControlQuantity   NUMERIC(12,6),
    @ControlTime       DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_GATHERINGDETAIL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STOREORDERDETAIL,
        GATHERING_TM,
        GATHERING,
        GATHERED_QTY,
        PALLET_NO,
        CONTROL_QTY,
        CONTROL_TM
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
        @StoreOrderDetail,
        @GatheringTime,
        @Gathering,
        @GatheredQuantity,
        @PalletNo,
        @ControlQuantity,
        @ControlTime
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
    SELECT @GatheringDetailId = SCOPE_IDENTITY();
/*Section="End"*/
END;
