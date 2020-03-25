-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_SCALELOG]
(
    /*Section="Columns"*/
    [SCALEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [SCALE_NM] VARCHAR(100) NOT NULL,
    [STORE] INT NOT NULL,
    [SCALEMODEL] INT NOT NULL,
    [PRICEFILEPATH_TXT] VARCHAR(200) NULL,
    [CURRENTPRICEVERSION] INT NULL,
    [CURRENTPRICELOAD_TM] DATETIME NULL,
    [PRIVATEPRICEVERSION] INT NULL,
    [PRIVATEPRICELOAD_TM] DATETIME NULL,
    [CREATEPRICEFILE_FL] VARCHAR(1) NULL,
    [IPADDRESS_TXT] VARCHAR(20) NULL,
    [STATUS_FL] VARCHAR(1) NULL,
    [STATUS_TXT] VARCHAR(100) NULL,
    [SEALVALID_DT] DATETIME NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Store Scales Log: Definition of scales at stores., logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_SCALELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Scales Id: Identity column for STR_SCALE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'SCALEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Name: Name of store scales.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'SCALE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Scale Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Scale Model: Store Scale Model' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'SCALEMODEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Price File Path: Price File Path' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRICEFILEPATH_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Price Version: Current Price Version' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICEVERSION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Price Load Time: Current Price Version Load Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICELOAD_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Private Price Version: Private Price Version' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIVATEPRICEVERSION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Private Price Load Time: Private Price Version Load Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIVATEPRICELOAD_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Price File Flag: It is used to create price file for scale for once. ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'CREATEPRICEFILE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'IpAdress: IpAdress' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'IPADDRESS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status: Status' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'STATUS_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status Text: Status Text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'STATUS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Seal Valid Date: Seal Valid Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'SEALVALID_DT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_SCALELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
