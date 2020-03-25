-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_RETURNREASONDETAIL_SP
    @ReturnReasonDetailId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_RETURNREASONDETAILLOG
    (
        RETURNREASONDETAILID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        RETURNREASON,
        DETAIL_NM    )    
    SELECT
        RETURNREASONDETAILID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        RETURNREASON,
        DETAIL_NM
      FROM
        WHS_RETURNREASONDETAIL R (NOLOCK)
     WHERE
        R.RETURNREASONDETAILID = @ReturnReasonDetailId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_RETURNREASONDETAIL
     WHERE RETURNREASONDETAILID = @ReturnReasonDetailId;

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
