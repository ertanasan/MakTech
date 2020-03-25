-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_STOREORDERSTATUS_SP
    @StoreOrderStatusId INT,
    @StatusName         VARCHAR(100),
    @Comment            VARCHAR(100)
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
        COMMENT_DSC
    )    
    SELECT
        STOREORDERSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM,
        COMMENT_DSC
      FROM
        WHS_STOREORDERSTATUS S (NOLOCK)
     WHERE
        S.STOREORDERSTATUSID = @StoreOrderStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_STOREORDERSTATUS
       SET
           STATUS_NM = @StatusName,
           COMMENT_DSC = @Comment
     WHERE STOREORDERSTATUSID = @StoreOrderStatusId;

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
