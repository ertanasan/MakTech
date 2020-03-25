-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_DEL_DIFFREASON_SP
    @DiffReasonId INT
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
        SHORT_FL    )    
    SELECT
        DIFFREASONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REASON_NM,
        SHORT_FL
      FROM
        RCL_DIFFREASON D (NOLOCK)
     WHERE
        D.DIFFREASONID = @DiffReasonId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM RCL_DIFFREASON
     WHERE DIFFREASONID = @DiffReasonId;

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
