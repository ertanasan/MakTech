-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_SUPPLIERTYPE_SP
    @SupplierTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_SUPPLIERTYPELOG
    (
        SUPPLIERTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUPPLIERTYPE_NM    )    
    SELECT
        SUPPLIERTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPPLIERTYPE_NM
      FROM
        WHS_SUPPLIERTYPE S (NOLOCK)
     WHERE
        S.SUPPLIERTYPEID = @SupplierTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_SUPPLIERTYPE
     WHERE SUPPLIERTYPEID = @SupplierTypeId;

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
