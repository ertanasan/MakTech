-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_INTAKESTATUS_SP
    @IntakeStatusId     BIGINT OUT,
    @Event              INT,
    @Organization       INT,
    @StoreOrderDetail   BIGINT,
    @IntakeStatusType   INT,
    @Description        VARCHAR(1000),
    @IsTransferred      VARCHAR(1),
    @MikroTransferTime  DATETIME,
    @QuantityDifference NUMERIC(10,2)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_INTAKESTATUS
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
        INTAKESTATUSTYPE,
        DESCRIPTION_DSC,
        MIKROTRANSFER_FL,
        MIKROTRANSFER_TM,
        QUANTITYDIF_QTY
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
        @IntakeStatusType,
        @Description,
        @IsTransferred,
        @MikroTransferTime,
        @QuantityDifference
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
    SELECT @IntakeStatusId = SCOPE_IDENTITY();
/*Section="End"*/
END;
