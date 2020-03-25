-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_REGIONMANAGERSLOG]
(
    /*Section="Columns"*/
    [REGIONMANAGERSID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [MANAGER_NM] VARCHAR(100) NOT NULL,
    [TELNO_TXT] VARCHAR(100) NULL,
    [EMAIL_TXT] VARCHAR(100) NULL,
    [USERID] INT NULL,
    [EXPENSEACCCODE_TXT] VARCHAR(100) NULL,
    [MIKROPROJECTCODE_TXT] VARCHAR(50) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Region Managers Log: Region Managers, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_REGIONMANAGERSLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Region Managers Id: Identity column for STR_REGIONMANAGERS' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'REGIONMANAGERSID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Region Manager Name: Name of region managers.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'MANAGER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'TelNo: TelNo' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'TELNO_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Email: Email' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'EMAIL_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Region User: Region User' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'USERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Expense Account Code: Expense Account Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'EXPENSEACCCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Project Code: Mikro Project Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'MIKROPROJECTCODE_TXT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_REGIONMANAGERSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
