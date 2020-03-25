-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_PRODUCTLOG]
(
    /*Section="Columns"*/
    [PRODUCTID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [CODE_NM] VARCHAR(100) NOT NULL,
    [NAME_NM] VARCHAR(100) NOT NULL,
    [PURCHASEVAT_RT] NUMERIC(4,2) NULL,
    [SALEVAT_RT] NUMERIC(4,2) NOT NULL,
    [SUBGROUP] INT NULL,
    [SUPERGROUP1] INT NULL,
    [SUPERGROUP2] INT NULL,
    [SUPERGROUP3] INT NULL,
    [UNIT] INT NOT NULL,
    [BARCODETYPE] INT NULL,
    [SEASONTYPE] INT NULL,
    [OLDCODE_NM] VARCHAR(100) NULL,
    [PRIVATELABEL_FL] VARCHAR(1) NULL,
    [ETRADE_FL] VARCHAR(1) NULL,
    [GTIPCODE_TXT] VARCHAR(100) NULL,
    [PHOTO_IMG] VARBINARY(MAX) NULL,
    [SHORTNAME_NM] VARCHAR(50) NULL,
    [DOMESTIC_FL] VARCHAR(1) NULL,
    [COUNTRY] INT NULL,
    [CONTENT_TXT] VARCHAR(1000) NULL,
    [WARNING] INT NULL,
    [STORAGECONDITION] INT NULL,
    [EXPIRESIN_CNT] INT NULL,
    [SHELFLIFE_CNT] INT NULL,
    [COMMENT_DSC] VARCHAR(1000) NULL,
    [CAMPAIGN] INT NULL,
    [WEIGHT_AMT] NUMERIC(22,6) NULL,
    [WEIGHTUNIT] INT NULL,
    [ACTIVE_FL] VARCHAR(1) NULL,
    [LOADORDER_TXT] VARCHAR(20) NULL,
    [PARENT] INT NULL,
    [INITIALPRICE_AMT] NUMERIC(22,6) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Product Log: Ürün tanımlarını saklar, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_PRODUCTLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Id: Identity column for PRD_PRODUCT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Code: Mikro : Kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'CODE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Name: Mikro : İsmi' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'NAME_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Purchase VAT: Alış KDV oranı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PURCHASEVAT_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale VAT: Satış KDV oranı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SALEVAT_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Subgroup: Alt grup' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SUBGROUP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Super Group 1: Üst grup 1' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SUPERGROUP1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Super Group 2: Üst grup 2' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SUPERGROUP2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Super Group 3: Üst grup 3' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SUPERGROUP3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Unit: Birim' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'UNIT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode Type: Mikro: Barkod Tipi' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'BARCODETYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Season Type: Sezon bilgisidir' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SEASONTYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Old Code: Eski ürün kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'OLDCODE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Private Label: Private Label' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIVATELABEL_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'eTrade: Elektronik ticarete açık mı?' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'ETRADE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'GTIP Code: GTIP kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'GTIPCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Photo: Photo' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PHOTO_IMG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Short Name: Etiket için kısa ad.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SHORTNAME_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Domestic: Yerli logo kullanımı içindir.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'DOMESTIC_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Country: Menşei' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'COUNTRY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Content: Ürün içeriği' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'CONTENT_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Warning: Ürün uyarısı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'WARNING'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Storage Condition: Saklama koşulları' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'STORAGECONDITION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Expires In: Tartımdan sonraki SKT, gün sayısı olarak.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'EXPIRESIN_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Shelf Life: Raf ömrü, gün sayısı olarak.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'SHELFLIFE_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for product.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Campaign: Kampanya kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'CAMPAIGN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Weight: Gramaj veya hacim bilgisini gram ve mililitre cinsinden tutar' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'WEIGHT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Weight Unit: Gram ya da Mililitre' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'WEIGHTUNIT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Active: Aktif mi delist mi?' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'ACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Load Order: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOADORDER_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Parent: Üst barkod grubuna bağlı olan ürünler için kullanılacaktır.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PARENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Initial Price: the initial price of a recently created product. Will be used only one time ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'INITIALPRICE_AMT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
