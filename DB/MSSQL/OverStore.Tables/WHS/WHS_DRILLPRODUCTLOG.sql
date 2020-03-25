-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_DRILLPRODUCTLOG]
(
    /*Section="Columns"*/
    [DRILLPRODUCTID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [COUNTING_DT] DATETIME NOT NULL,
    [PRODUCT] INT NOT NULL,
    [STORE] INT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Drill Product Log: Drill Product, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_DRILLPRODUCTLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Drill Product Id: Identity column for WHS_DRILLPRODUCT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'DRILLPRODUCTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Counting Date: Counting Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'COUNTING_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product: Product' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: STR_STORE tablosundaki STOREID sütunuana referans.  Yanlız FK oluşturulmayacka; çünkü bu alana merkez depo için 999, tüm mağazalar için -1 kaydı atılabilecek.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_DRILLPRODUCTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
