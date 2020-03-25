-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_DIFFREASON_SP
    @DiffReasonId INT OUT,
    @ReasonName   VARCHAR(100),
    @ShortFlag    VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_DIFFREASON
    (
        REASON_NM,
        SHORT_FL
    )
    VALUES
    (
        @ReasonName,
        @ShortFlag
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
    SELECT @DiffReasonId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @DiffReasonId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ReasonName,
        @ShortFlag);
/*Section="End"*/
END;
