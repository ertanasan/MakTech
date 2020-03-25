-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_INTAKESTATUSTYPE_SP
    @IntakeStatusTypeId   INT,
    @IntakeStatusTypeName VARCHAR(100)
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
        INTAKESTATUSTYPE_NM
    )
    SELECT
        INTAKESTATUSTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        INTAKESTATUSTYPE_NM
      FROM
        WHS_INTAKESTATUSTYPE I (NOLOCK)
     WHERE
        I.INTAKESTATUSTYPEID = @IntakeStatusTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_INTAKESTATUSTYPE
       SET
           INTAKESTATUSTYPE_NM = @IntakeStatusTypeName
     WHERE INTAKESTATUSTYPEID = @IntakeStatusTypeId;

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
