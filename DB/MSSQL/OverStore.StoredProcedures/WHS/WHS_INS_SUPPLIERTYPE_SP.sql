-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_SUPPLIERTYPE_SP
    @SupplierTypeId   INT,
    @SupplierTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_SUPPLIERTYPE
    (
        SUPPLIERTYPEID,
        SUPPLIERTYPE_NM
    )
    VALUES
    (
        @SupplierTypeId,
        @SupplierTypeName
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
    VALUES
    (
        @SupplierTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @SupplierTypeName);
/*Section="End"*/
END;
