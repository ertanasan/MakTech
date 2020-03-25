-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_GATHERING_SP
    @GatheringId BIGINT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_GATHERINGLOG
    (
        GATHERINGID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STOREORDER,
        GATHERINGUSER,
        GATHERINGSTART_TM,
        GATHERINGEND_TM,
        GATHERINGSTATUS,
        GATHERINGTYPE,
        PRIORITY_NO
	)
    SELECT
        GATHERINGID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STOREORDER,
        GATHERINGUSER,
        GATHERINGSTART_TM,
        GATHERINGEND_TM,
        GATHERINGSTATUS,
        GATHERINGTYPE,
        PRIORITY_NO
      FROM
        WHS_GATHERING G (NOLOCK)
     WHERE
        G.GATHERINGID = @GatheringId;
	
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
    UPDATE WHS_GATHERING
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE GATHERINGID = @GatheringId
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
