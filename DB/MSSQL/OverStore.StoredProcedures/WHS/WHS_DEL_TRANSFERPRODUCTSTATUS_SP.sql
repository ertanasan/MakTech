-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_TRANSFERPRODUCTSTATUS_SP
    @TransferProductStatusId INT
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
        PRODUCTSTATUS_NM    )    
    SELECT
        TRANSFERPRODUCTSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PRODUCTSTATUS_NM
      FROM
        WHS_TRANSFERPRODUCTSTATUS T (NOLOCK)
     WHERE
        T.TRANSFERPRODUCTSTATUSID = @TransferProductStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_TRANSFERPRODUCTSTATUS
     WHERE TRANSFERPRODUCTSTATUSID = @TransferProductStatusId;

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
