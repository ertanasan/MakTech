-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_RETURNREASON_SP
    @ReturnReasonId INT
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
        PARENT    )
    SELECT
        RETURNREASONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REASON_NM,
        PARENT
      FROM
        WHS_RETURNREASON R (NOLOCK)
     WHERE
        R.RETURNREASONID = @ReturnReasonId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_RETURNREASON
     WHERE RETURNREASONID = @ReturnReasonId;

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
