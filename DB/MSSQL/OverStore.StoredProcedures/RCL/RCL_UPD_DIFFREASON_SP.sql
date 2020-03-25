-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_DIFFREASON_SP
    @DiffReasonId INT,
    @ReasonName   VARCHAR(100),
    @ShortFlag    VARCHAR(1)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO RCL_DIFFREASONLOG
    (
        DIFFREASONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        REASON_NM,
        SHORT_FL
    )    
    SELECT
        DIFFREASONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REASON_NM,
        SHORT_FL
      FROM
        RCL_DIFFREASON D (NOLOCK)
     WHERE
        D.DIFFREASONID = @DiffReasonId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_DIFFREASON
       SET
           REASON_NM = @ReasonName,
           SHORT_FL = @ShortFlag
     WHERE DIFFREASONID = @DiffReasonId;

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
