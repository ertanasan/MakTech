-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_PRODUCT_SP
    @ProductPriceId    INT OUT,
    @PriceAmount       NUMERIC(22,6),
    @Product           INT,
    @Package           INT,
    @TopPriceAmount    NUMERIC(22,6),
    @PrintTopPriceFlag VARCHAR(1),
    @PackageVersion    INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_PRODUCT
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        PRICE_AMT,
        PRODUCT,
        PACKAGE,
        TOPPRICE_AMT,
        PRINTTOPPRICE_FL,
        PACKAGEVERSION
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @PriceAmount,
        @Product,
        @Package,
        @TopPriceAmount,
        @PrintTopPriceFlag,
        @PackageVersion
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
    SELECT @ProductPriceId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO PRC_PRODUCTLOG
    (
        PRODUCTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PRICE_AMT,
        PRODUCT,
        PACKAGE,
        TOPPRICE_AMT,
        PRINTTOPPRICE_FL,
        PACKAGEVERSION
    )
    VALUES
    (
        @ProductPriceId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PriceAmount,
        @Product,
        @Package,
        @TopPriceAmount,
        @PrintTopPriceFlag,
        @PackageVersion);
/*Section="End"*/
END;
