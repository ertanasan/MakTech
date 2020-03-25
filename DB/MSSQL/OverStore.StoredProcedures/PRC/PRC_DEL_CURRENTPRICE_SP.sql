-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_DEL_CURRENTPRICE_SP
    @CurrentPricesId INT
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
        GROUP_CD    )
    SELECT
        CURRENTPRICEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRC_CURRENTPRICE
     WHERE CURRENTPRICEID = @CurrentPricesId;

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
