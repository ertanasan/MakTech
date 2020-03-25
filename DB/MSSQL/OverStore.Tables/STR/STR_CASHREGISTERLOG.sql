-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_CASHREGISTERLOG]
(
    /*Section="Columns"*/
    [CASHREGISTERID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [CASHREGISTER_NM] VARCHAR(100) NOT NULL,
    [STORE] INT NOT NULL,
    [CASHREGISTERMODEL] INT NOT NULL,
    [PRICEFILEPATH_TXT] VARCHAR(200) NULL,
    [SALEFILEPATH1_TXT] VARCHAR(1000) NULL,
    [SALEFILEPATH2_TXT] VARCHAR(1000) NULL,
    [SALEFILEPATH3_TXT] VARCHAR(1000) NULL,
    [CURRENTPRICEVERSION] INT NULL,
    [CURRENTPRICELOAD_TM] DATETIME NULL,
    [PRIVATEPRICEVERSION] INT NULL,
    [PRIVATEPRICELOAD_TM] DATETIME NULL,
    [CREATEPRICEFILE_FL] VARCHAR(1) NULL,
    [IPADDRESS_TXT] VARCHAR(20) NULL,
    [STATUS_FL] VARCHAR(1) NULL,
    [STATUS_TXT] VARCHAR(100) NULL,
    [GIBDEVICENO_TXT] VARCHAR(20) NULL,
    [SERIALNO_TXT] VARCHAR(100) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Store Cash Register Log: Definitions of cash register machines at stores., logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_CASHREGISTERLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Cash Register Id: Identity column for STR_CASHREGISTER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHREGISTERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Name: Name of store cash register.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHREGISTER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cash Register Model: Cash Register Model' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHREGISTERMODEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Price File Path: Price File Path' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRICEFILEPATH_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale File Path 1: Sale File Path' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'SALEFILEPATH1_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale File Path 2: Sale File Path' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'SALEFILEPATH2_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale File Path 3: Sale File Path' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'SALEFILEPATH3_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Price Version: Current Price Version' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICEVERSION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Price Load Time: Current Price Version Load Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICELOAD_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Private Price Version: Private Price Version' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIVATEPRICEVERSION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Private Price Load Time: Private Price Version Load Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIVATEPRICELOAD_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Price File Flag: This column is used to create price file for the cash register once. ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CREATEPRICEFILE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'IpAddress: IpAddress' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'IPADDRESS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status: Status Text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'STATUS_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status Text: Status Text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'STATUS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gib Device No: Gelir İdaresi Başkanlığına bildirilen Odeme Kaydedici Cihaz (OKS) sicil no' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'GIBDEVICENO_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Serial No: Serial No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'SERIALNO_TXT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHREGISTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
