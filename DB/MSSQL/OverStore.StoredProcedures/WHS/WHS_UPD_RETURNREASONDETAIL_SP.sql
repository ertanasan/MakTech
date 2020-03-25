-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_RETURNREASONDETAIL_SP
    @ReturnReasonDetailId INT,
    @ReturnReason         INT,
    @ReasonDetailName     VARCHAR(100)
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
        DETAIL_NM
    )    
    SELECT
        RETURNREASONDETAILID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        RETURNREASON,
        DETAIL_NM
      FROM
        WHS_RETURNREASONDETAIL R (NOLOCK)
     WHERE
        R.RETURNREASONDETAILID = @ReturnReasonDetailId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_RETURNREASONDETAIL
       SET
           RETURNREASON = @ReturnReason,
           DETAIL_NM = @ReasonDetailName
     WHERE RETURNREASONDETAILID = @ReturnReasonDetailId;

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
