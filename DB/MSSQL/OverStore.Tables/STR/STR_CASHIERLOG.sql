-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_CASHIERLOG]
(
    /*Section="Columns"*/
    [CASHIERID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [STORE] INT NOT NULL,
    [CASHIER_NM] VARCHAR(30) NOT NULL,
    [CASHIERTEMPLATE] INT NOT NULL,
    [CASHIERTITLE] INT NOT NULL,
    [PASSWORD_NO] INT NOT NULL,
    [ISCASHIER_FL] VARCHAR(1) NOT NULL,
    [ISACTIVE_FL] VARCHAR(1) NOT NULL,
    [ISSALESMAN_FL] VARCHAR(1) NOT NULL,
    [WORKINGTYPE_CD] VARCHAR(1) NULL,
    [NOTE_TXT] VARCHAR(1000) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cashier Log: Kasiyer, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_CASHIERLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier  Id: Unique identifier for {table}.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHIERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Mağaza No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Name: Name of cashier .' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHIER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Template Number: Cashier Template Number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHIERTEMPLATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Title Number: Cashier title number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'CASHIERTITLE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Password: Password' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'PASSWORD_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier  Flag: Is Working On Cash Register' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'ISCASHIER_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Is Active: States that cashier is an active worker.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'ISACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Salesman: Is Salesman' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'ISSALESMAN_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Working Type: Working Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'WORKINGTYPE_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Note: Note' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'NOTE_TXT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
