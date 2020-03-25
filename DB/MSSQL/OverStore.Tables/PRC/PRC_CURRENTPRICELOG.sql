-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRC_CURRENTPRICELOG]
(
    /*Section="Columns"*/
    [CURRENTPRICEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [STORE] INT NOT NULL,
    [PRODUCTCODE_NM] VARCHAR(100) NOT NULL,
    [PRODUCT_NM] VARCHAR(100) NOT NULL,
    [BARCODE_TXT] VARCHAR(30) NOT NULL,
    [PRODUCTUNIT_NO] INT NOT NULL,
    [SALEPRICE_AMT] NUMERIC(22,6) NOT NULL,
    [SALEVAT_RT] NUMERIC(4,2) NOT NULL,
    [VERSION_TM] DATETIME NOT NULL,
    [GROUP_CD] INT NOT NULL,
	[PACKAGE] INT
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Current Prices Log: Current Prices, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRC_CURRENTPRICELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Prices Id: Identity column for PRC_CURRENTPRICE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store ID: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Code Name: Product Code Name' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTCODE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Name: Product Name' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode: Barcode' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'BARCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Unit: Product Unit 1-KG, 2-AD' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTUNIT_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale Price: Sale Price' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'SALEPRICE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale VAT: Sale VAT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'SALEVAT_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Version Time: Version Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'VERSION_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Group Code: Group Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'GROUP_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
