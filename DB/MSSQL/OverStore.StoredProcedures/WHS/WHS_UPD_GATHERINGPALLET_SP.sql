-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_GATHERINGPALLET_SP
    @GatheringPalletId     INT,
    @Gathering             BIGINT,
    @PalletNo              INT,
    @ControlUser           INT,
    @Control               DATETIME,
    @ControlEndTime        DATETIME,
    @GatheringPalletStatus INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        GATHERINGPALLETID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GATHERING,
        PALLET_NO,
        CONTROLUSER,
        CONTROLSTART_TM,
        CONTROLEND_TM,
        GATHERINGPALLETSTATUS
      FROM
        WHS_GATHERINGPALLET G (NOLOCK)
     WHERE
        G.GATHERINGPALLETID = @GatheringPalletId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_GATHERINGPALLET
       SET
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           UPDATE_DT = GETDATE(),
           GATHERING = @Gathering,
           PALLET_NO = @PalletNo,
		   CONTROLUSER = CASE @GatheringPalletStatus WHEN 1 THEN NULL ELSE dbo.SYS_GETCURRENTUSER_FN() END,
           CONTROLSTART_TM = CASE @GatheringPalletStatus WHEN 1 THEN NULL WHEN 9 THEN CONTROLSTART_TM ELSE GETDATE() END,
           CONTROLEND_TM = CASE WHEN @GatheringPalletStatus = 9 THEN GETDATE() ELSE NULL END,
           GATHERINGPALLETSTATUS = @GatheringPalletStatus
     WHERE GATHERINGPALLETID = @GatheringPalletId
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