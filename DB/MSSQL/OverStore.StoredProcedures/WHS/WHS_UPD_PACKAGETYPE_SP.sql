-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_PACKAGETYPE_SP
    @ShipmentPackageTypeId INT,
    @PackageTypeName       VARCHAR(100)
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
        PACKAGETYPE_NM
    )    
    SELECT
        PACKAGETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PACKAGETYPE_NM
      FROM
        WHS_PACKAGETYPE P (NOLOCK)
     WHERE
        P.PACKAGETYPEID = @ShipmentPackageTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_PACKAGETYPE
       SET
           PACKAGETYPE_NM = @PackageTypeName
     WHERE PACKAGETYPEID = @ShipmentPackageTypeId;

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
