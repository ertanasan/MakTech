CREATE PROCEDURE [dbo].[PRD_INS_PRODUCT_SP]      
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
         
  DECLARE @NewProductID INT;      
       
 IF @ProductId = 0      
 BEGIN      
  SELECT @NewProductID = MAX(P.PRODUCTID) + 1 FROM PRD_PRODUCT P (NOLOCK);      
 END      
 ELSE      
 BEGIN      
  SET @NewProductID = @ProductId;      
 END         
         
    /*Section="Insert"*/      
    SET NOCOUNT OFF      
    -- Insert record      
    INSERT INTO PRD_PRODUCT      
    (      
        PRODUCTID,      
        ORGANIZATION,      
        DELETED_FL,      
        CREATE_DT,      
        CREATEUSER,      
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
    VALUES      
    (      
        @NewProductID,      
        dbo.SYS_GETCURRENTORGANIZATION_FN(),      
        'N',      
        GETDATE(),      
        dbo.SYS_GETCURRENTUSER_FN(),      
        @Code,      
        @Name,      
        @PurchaseVAT,      
        @SaleVAT,      
        @Subgroup,      
        @SuperGroup1,      
        @SuperGroup2,      
        @SuperGroup3,      
        @Unit,      
        @BarcodeType,      
        @SeasonType,      
        @OldCode,      
        @PrivateLabel,      
        @eTrade,      
        @GTIPCode,      
        @Photo,      
        @ShortName,      
        @Domestic,      
        @Country,      
        @Content,      
        @Warning,      
        @StorageCondition,      
        @ExpiresIn,      
        @ShelfLife,      
        @Comment,      
        @Campaign,      
        @Weight,      
        @WeightUnit,      
        @Active,      
        @LoadOrder,      
        @Parent,    
  @InitialPrice    
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
    VALUES      
    (      
        @NewProductID,      
        GETDATE(),      
        dbo.SYS_GETCURRENTUSER_FN(),      
        'INS',      
        dbo.SYS_GETCURRENTCHANNEL_FN(),      
        dbo.SYS_GETCURRENTBRANCH_FN(),      
        dbo.SYS_GETCURRENTSCREEN_FN(),      
        @Code,      
        @Name,      
        @PurchaseVAT,      
        @SaleVAT,      
        @Subgroup,      
        @SuperGroup1,      
        @SuperGroup2,      
        @SuperGroup3,      
        @Unit,      
        @BarcodeType,      
        @SeasonType,      
        @OldCode,      
        @PrivateLabel,      
        @eTrade,      
        @GTIPCode,      
        @Photo,      
        @ShortName,      
        @Domestic,      
        @Country,      
        @Content,      
        @Warning,      
        @StorageCondition,      
        @ExpiresIn,      
        @ShelfLife,      
        @Comment,      
        @Campaign,      
        @Weight,      
        @WeightUnit,      
        @Active,      
        @LoadOrder,      
        @Parent,    
		@InitialPrice    
  );      
    
/*Section="Assign ToshibaID"*/  
  Declare @toshibaValueTxt varchar(100) = CAST((SELECT MAX(VALUE_TXT * 1) + 1 FROM PRD_PROPERTY WHERE PROPERTYTYPE = 3) as varchar(100))    
  INSERT INTO PRD_PROPERTY VALUES(3, @NewProductID, @toshibaValueTxt)   
    
/*Section="End"*/      
END; 

