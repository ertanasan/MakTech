-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_PRODUCT_SP
    @ProductId        INT,
    @Code             VARCHAR(100),
    @Name             VARCHAR(100),
    @PurchaseVAT      NUMERIC(4,2),
    @SaleVAT          NUMERIC(4,2),
    @Subgroup         INT,
    @SuperGroup1      INT,
    @SuperGroup2      INT,
    @SuperGroup3      INT,
    @Unit             INT,
    @BarcodeType      INT,
    @SeasonType       INT,
    @OldCode          VARCHAR(100),
    @PrivateLabel     VARCHAR(1),
    @eTrade           VARCHAR(1),
    @GTIPCode         VARCHAR(100),
    @Photo            VARBINARY(MAX),
    @ShortName        VARCHAR(50),
    @Domestic         VARCHAR(1),
    @Country          INT,
    @Content          VARCHAR(1000),
    @Warning          INT,
    @StorageCondition INT,
    @ExpiresIn        INT,
    @ShelfLife        INT,
    @Comment          VARCHAR(1000),
    @Campaign         INT,
    @Weight           NUMERIC(22,6),
    @WeightUnit       INT,
    @Active           VARCHAR(1),
    @LoadOrder        VARCHAR(20),
    @Parent           INT,
    @InitialPrice     NUMERIC(22,6)
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
        INITIALPRICE_AMT
    )
    SELECT
        PRODUCTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
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
        INITIALPRICE_AMT
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_PRODUCT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           CODE_NM = @Code,
           NAME_NM = @Name,
           PURCHASEVAT_RT = @PurchaseVAT,
           SALEVAT_RT = @SaleVAT,
           SUBGROUP = @Subgroup,
           SUPERGROUP1 = @SuperGroup1,
           SUPERGROUP2 = @SuperGroup2,
           SUPERGROUP3 = @SuperGroup3,
           UNIT = @Unit,
           BARCODETYPE = @BarcodeType,
           SEASONTYPE = @SeasonType,
           OLDCODE_NM = @OldCode,
           PRIVATELABEL_FL = @PrivateLabel,
           ETRADE_FL = @eTrade,
           GTIPCODE_TXT = @GTIPCode,
           PHOTO_IMG = @Photo,
           SHORTNAME_NM = @ShortName,
           DOMESTIC_FL = @Domestic,
           COUNTRY = @Country,
           CONTENT_TXT = @Content,
           WARNING = @Warning,
           STORAGECONDITION = @StorageCondition,
           EXPIRESIN_CNT = @ExpiresIn,
           SHELFLIFE_CNT = @ShelfLife,
           COMMENT_DSC = @Comment,
           CAMPAIGN = @Campaign,
           WEIGHT_AMT = @Weight,
           WEIGHTUNIT = @WeightUnit,
           ACTIVE_FL = @Active,
           LOADORDER_TXT = @LoadOrder,
           PARENT = @Parent,
           INITIALPRICE_AMT = @InitialPrice
     WHERE PRODUCTID = @ProductId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
