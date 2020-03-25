-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_GATHERINGPALLET_SP
    @GatheringPalletId INT
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
        GATHERINGPALLETSTATUS    )
    SELECT
        GATHERINGPALLETID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE WHS_GATHERINGPALLET
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE GATHERINGPALLETID = @GatheringPalletId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
