-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_RETURNREASON_SP
    @ReturnReasonId INT,
    @ReasonName     VARCHAR(100),
    @Parent         INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_RETURNREASONLOG
    (
        RETURNREASONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        REASON_NM,
        PARENT
    )
    SELECT
        RETURNREASONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REASON_NM,
        PARENT
      FROM
        WHS_RETURNREASON R (NOLOCK)
     WHERE
        R.RETURNREASONID = @ReturnReasonId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_RETURNREASON
       SET
           REASON_NM = @ReasonName,
           PARENT = @Parent
     WHERE RETURNREASONID = @ReturnReasonId;

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
