-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_STOREORDERSTATUS_SP
    @StoreOrderStatusId INT,
    @StatusName         VARCHAR(100),
    @Comment            VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_STOREORDERSTATUS
    (
        STOREORDERSTATUSID,
        STATUS_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @StoreOrderStatusId,
        @StatusName,
        @Comment
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
    VALUES
    (
        @StoreOrderStatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StatusName,
        @Comment);
/*Section="End"*/
END;
