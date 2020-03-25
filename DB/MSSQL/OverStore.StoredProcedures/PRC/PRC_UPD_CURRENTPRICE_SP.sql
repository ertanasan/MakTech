-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_UPD_CURRENTPRICE_SP
    @CurrentPricesId INT,
    @StoreID         INT,
    @ProductCodeName VARCHAR(100),
    @ProductName     VARCHAR(100),
    @Barcode         VARCHAR(30),
    @ProductUnit     INT,
    @SalePrice       NUMERIC(22,6),
    @SaleVAT         NUMERIC(4,2),
    @VersionTime     DATETIME,
    @GroupCode       INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRC_CURRENTPRICELOG
    (
        CURRENTPRICEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STORE,
        PRODUCTCODE_NM,
        PRODUCT_NM,
        BARCODE_TXT,
        PRODUCTUNIT_NO,
        SALEPRICE_AMT,
        SALEVAT_RT,
        VERSION_TM,
        GROUP_CD
    )
    SELECT
        CURRENTPRICEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE,
        PRODUCTCODE_NM,
        PRODUCT_NM,
        BARCODE_TXT,
        PRODUCTUNIT_NO,
        SALEPRICE_AMT,
        SALEVAT_RT,
        VERSION_TM,
        GROUP_CD
      FROM
        PRC_CURRENTPRICE C (NOLOCK)
     WHERE
        C.CURRENTPRICEID = @CurrentPricesId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRC_CURRENTPRICE
       SET
           STORE = @StoreID,
           PRODUCTCODE_NM = @ProductCodeName,
           PRODUCT_NM = @ProductName,
           BARCODE_TXT = @Barcode,
           PRODUCTUNIT_NO = @ProductUnit,
           SALEPRICE_AMT = @SalePrice,
           SALEVAT_RT = @SaleVAT,
           VERSION_TM = @VersionTime,
           GROUP_CD = @GroupCode
     WHERE CURRENTPRICEID = @CurrentPricesId;

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
