-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_CURRENTPRICE_SP
    @CurrentPricesId INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_CURRENTPRICE
    (
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
    VALUES
    (
        @StoreID,
        @ProductCodeName,
        @ProductName,
        @Barcode,
        @ProductUnit,
        @SalePrice,
        @SaleVAT,
        @VersionTime,
        @GroupCode
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
    SELECT @CurrentPricesId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @CurrentPricesId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StoreID,
        @ProductCodeName,
        @ProductName,
        @Barcode,
        @ProductUnit,
        @SalePrice,
        @SaleVAT,
        @VersionTime,
        @GroupCode);
/*Section="End"*/
END;
