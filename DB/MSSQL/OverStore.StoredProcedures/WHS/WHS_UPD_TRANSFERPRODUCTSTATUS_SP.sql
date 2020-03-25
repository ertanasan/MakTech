-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_TRANSFERPRODUCTSTATUS_SP
    @TransferProductStatusId INT,
    @ProductStatusName       INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        TRANSFERPRODUCTSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PRODUCTSTATUS_NM
      FROM
        WHS_TRANSFERPRODUCTSTATUS T (NOLOCK)
     WHERE
        T.TRANSFERPRODUCTSTATUSID = @TransferProductStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_TRANSFERPRODUCTSTATUS
       SET
           PRODUCTSTATUS_NM = @ProductStatusName
     WHERE TRANSFERPRODUCTSTATUSID = @TransferProductStatusId;

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
