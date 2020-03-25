-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_INTAKESTATUSTYPE_SP
    @IntakeStatusTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_INTAKESTATUSTYPELOG
    (
        INTAKESTATUSTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        INTAKESTATUSTYPE_NM    )    
    SELECT
        INTAKESTATUSTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        INTAKESTATUSTYPE_NM
      FROM
        WHS_INTAKESTATUSTYPE I (NOLOCK)
     WHERE
        I.INTAKESTATUSTYPEID = @IntakeStatusTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_INTAKESTATUSTYPE
     WHERE INTAKESTATUSTYPEID = @IntakeStatusTypeId;

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
