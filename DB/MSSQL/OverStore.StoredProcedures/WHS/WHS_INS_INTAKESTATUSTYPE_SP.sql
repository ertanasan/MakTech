-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_INTAKESTATUSTYPE_SP
    @IntakeStatusTypeId   INT,
    @IntakeStatusTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_INTAKESTATUSTYPE
    (
        INTAKESTATUSTYPEID,
        INTAKESTATUSTYPE_NM
    )
    VALUES
    (
        @IntakeStatusTypeId,
        @IntakeStatusTypeName
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

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @IntakeStatusTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @IntakeStatusTypeName);
/*Section="End"*/
END;
