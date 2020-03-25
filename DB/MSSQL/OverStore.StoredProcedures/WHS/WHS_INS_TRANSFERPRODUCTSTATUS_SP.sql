-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_TRANSFERPRODUCTSTATUS_SP
    @TransferProductStatusId INT,
    @ProductStatusName       INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_TRANSFERPRODUCTSTATUS
    (
        TRANSFERPRODUCTSTATUSID,
        PRODUCTSTATUS_NM
    )
    VALUES
    (
        @TransferProductStatusId,
        @ProductStatusName
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
    INSERT INTO WHS_TRANSFERPRODUCTSTATUSLOG
    (
        TRANSFERPRODUCTSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PRODUCTSTATUS_NM
    )    
    VALUES
    (
        @TransferProductStatusId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ProductStatusName);
/*Section="End"*/
END;
