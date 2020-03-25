-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_GATHERINGPALLET_SP
    @GatheringPalletId     INT OUT,
    @Gathering             BIGINT,
    @PalletNo              INT,
    @ControlUser           INT OUT,
    @Control               DATETIME,
    @ControlEndTime        DATETIME,
    @GatheringPalletStatus INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_GATHERINGPALLET
    (
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        GATHERING,
        ORGANIZATION,
        PALLET_NO,
        CONTROLSTART_TM,
        CONTROLEND_TM,
        GATHERINGPALLETSTATUS
    )
    VALUES
    (
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Gathering,
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        @PalletNo,
        @Control,
        @ControlEndTime,
        @GatheringPalletStatus
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
    SELECT @GatheringPalletId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_GATHERINGPALLETLOG
    (
        GATHERINGPALLETID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GATHERING,
        PALLET_NO,
        CONTROLUSER,
        CONTROLSTART_TM,
        CONTROLEND_TM,
        GATHERINGPALLETSTATUS
    )
    VALUES
    (
        @GatheringPalletId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Gathering,
        @PalletNo,
        @ControlUser,
        @Control,
        @ControlEndTime,
        @GatheringPalletStatus);
/*Section="End"*/
END;
