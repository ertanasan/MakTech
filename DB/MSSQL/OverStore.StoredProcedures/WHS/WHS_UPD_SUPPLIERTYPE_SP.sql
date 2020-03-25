-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_SUPPLIERTYPE_SP
    @SupplierTypeId   INT,
    @SupplierTypeName VARCHAR(100)
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
        SUPPLIERTYPE_NM
    )    
    SELECT
        SUPPLIERTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPPLIERTYPE_NM
      FROM
        WHS_SUPPLIERTYPE S (NOLOCK)
     WHERE
        S.SUPPLIERTYPEID = @SupplierTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_SUPPLIERTYPE
       SET
           SUPPLIERTYPE_NM = @SupplierTypeName
     WHERE SUPPLIERTYPEID = @SupplierTypeId;

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
