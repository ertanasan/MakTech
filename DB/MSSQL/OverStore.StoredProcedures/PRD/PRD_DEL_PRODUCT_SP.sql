-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_PRODUCT_SP
    @ProductId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_PRODUCTLOG
    (
        PRODUCTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CODE_NM,
        NAME_NM,
        PURCHASEVAT_RT,
        SALEVAT_RT,
        SUBGROUP,
        SUPERGROUP1,
        SUPERGROUP2,
        SUPERGROUP3,
        UNIT,
        BARCODETYPE,
        SEASONTYPE,
        OLDCODE_NM,
        PRIVATELABEL_FL,
        ETRADE_FL,
        GTIPCODE_TXT,
        PHOTO_IMG,
        SHORTNAME_NM,
        DOMESTIC_FL,
        COUNTRY,
        CONTENT_TXT,
        WARNING,
        STORAGECONDITION,
        EXPIRESIN_CNT,
        SHELFLIFE_CNT,
        COMMENT_DSC,
        CAMPAIGN,
        WEIGHT_AMT,
        WEIGHTUNIT,
        ACTIVE_FL,
        LOADORDER_TXT,
        PARENT,
        INITIALPRICE_AMT    )
    SELECT
        P.PRODUCTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        P.CODE_NM,
        P.NAME_NM,
        P.PURCHASEVAT_RT,
        P.SALEVAT_RT,
        P.SUBGROUP,
        P.SUPERGROUP1,
        P.SUPERGROUP2,
        P.SUPERGROUP3,
        P.UNIT,
        P.BARCODETYPE,
        P.SEASONTYPE,
        P.OLDCODE_NM,
        P.PRIVATELABEL_FL,
        P.ETRADE_FL,
        P.GTIPCODE_TXT,
        P.PHOTO_IMG,
        P.SHORTNAME_NM,
        P.DOMESTIC_FL,
        P.COUNTRY,
        P.CONTENT_TXT,
        P.WARNING,
        P.STORAGECONDITION,
        P.EXPIRESIN_CNT,
        P.SHELFLIFE_CNT,
        P.COMMENT_DSC,
        P.CAMPAIGN,
        P.WEIGHT_AMT,
        P.WEIGHTUNIT,
        P.ACTIVE_FL,
        P.LOADORDER_TXT,
        P.PARENT,
        P.INITIALPRICE_AMT
      FROM
        PRD_PRODUCT P (NOLOCK)
     WHERE
        P.PRODUCTID = @ProductId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE PRD_PRODUCT 
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE PRODUCTID = @ProductId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
