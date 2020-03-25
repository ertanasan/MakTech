-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRC_PRODUCTLOG]
(
    /*Section="Columns"*/
    [PRODUCTID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [PRICE_AMT] NUMERIC(22,6) NOT NULL,
    [PRODUCT] INT NOT NULL,
    [PACKAGE] INT NOT NULL,
    [TOPPRICE_AMT] NUMERIC(22,6) NULL,
    [PRINTTOPPRICE_FL] VARCHAR(1) NULL,
    [PACKAGEVERSION] INT NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Product Price Log: Product Price, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRC_PRODUCTLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Price Id: Identity column for PRC_PRODUCT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Price Amount: Price Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRICE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product: Product' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package: Package' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PACKAGE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Top Price Amount: Top Price Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'TOPPRICE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Print Top Price Flag: Print Top Price Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRINTTOPPRICE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package Version: Package Version' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PACKAGEVERSION'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
