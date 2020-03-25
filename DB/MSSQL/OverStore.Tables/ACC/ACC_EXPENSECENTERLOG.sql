-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_EXPENSECENTERLOG]
(
    /*Section="Columns"*/
    [EXPENSECENTERID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [EXPENSECENTER_NM] VARCHAR(100) NOT NULL,
    [EXPENSECENTERCODE_TXT] VARCHAR(50) NOT NULL,
    [CENTERGROUP_NO] INT NOT NULL,
    [REGIONMANAGER] INT NULL,
    [STORE] INT NULL,
    [ACTIVE_FL] VARCHAR(1) NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Expense Center Log: Expense Center, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_EXPENSECENTERLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Expense Center Id: Identity column for ACC_EXPENSECENTER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'EXPENSECENTERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Expense Center Name: Name of expense center.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'EXPENSECENTER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Expense Center Code: Expense Center Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'EXPENSECENTERCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Expense Center Group: Expense Center Group 1: HQ, 2: REGION 3: STORE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CENTERGROUP_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Region Manager: Region Manager' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'REGIONMANAGER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Active Flag: Active Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'ACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXPENSECENTERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
