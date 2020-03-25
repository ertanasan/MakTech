-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_STOREORDERSTATUS_SP
    @StoreOrderStatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_STOREORDERSTATUSLOG
    (
        STOREORDERSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM,
        COMMENT_DSC    )    
    SELECT
        STOREORDERSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM,
        COMMENT_DSC
      FROM
        WHS_STOREORDERSTATUS S (NOLOCK)
     WHERE
        S.STOREORDERSTATUSID = @StoreOrderStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_STOREORDERSTATUS
     WHERE STOREORDERSTATUSID = @StoreOrderStatusId;

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
