-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_TRANSFERPRODUCT_SP
    @TransferProductId BIGINT OUT,
    @Event             INT,
    @Organization      INT,
    @SourceStore       INT,
    @DestinationStore  INT,
    @ProcessInstance   BIGINT,
    @TransferStatus    INT,
    @WaybillNo         VARCHAR(50),
    @TargetWarehouse   INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_TRANSFERPRODUCT
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        SOURCESTORE,
        DESTINATIONSTORE,
        PROCESSINSTANCE_LNO,
        TRANSFERSTATUS,
        WAYBILL_TXT,
        RETURNDESTINATION
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
        @SourceStore,
        @DestinationStore,
        @ProcessInstance,
        @TransferStatus,
        @WaybillNo,
        @TargetWarehouse
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
    SELECT @TransferProductId = SCOPE_IDENTITY();
/*Section="End"*/
END;
