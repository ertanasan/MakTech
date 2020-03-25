-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_PACKAGETYPE_SP
    @ShipmentPackageTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_PACKAGETYPELOG
    (
        PACKAGETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PACKAGETYPE_NM    )    
    SELECT
        PACKAGETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PACKAGETYPE_NM
      FROM
        WHS_PACKAGETYPE P (NOLOCK)
     WHERE
        P.PACKAGETYPEID = @ShipmentPackageTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_PACKAGETYPE
     WHERE PACKAGETYPEID = @ShipmentPackageTypeId;

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
