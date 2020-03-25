-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [HDK_REQUESTDEFLOG]
(
    /*Section="Columns"*/
    [REQUESTDEFID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [REQUESTDEF_NM] VARCHAR(100) NOT NULL,
    [REQUESTGROUP] INT NOT NULL,
    [PROCESS] INT NOT NULL,
    [MICROCODE_TXT] VARCHAR(100) NULL,
    [DISPLAYORDER_NO] INT NULL,
    [ACTIVE_FL] VARCHAR(1) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Request Definition Log: Talep Tanımları, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'HDK_REQUESTDEFLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Definition Id: Identity column for HDK_REQUESTDEF' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTDEFID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Definition Name: Name of request definition.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTDEF_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Group: Request Group Name' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTGROUP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process: Process' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'PROCESS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Micro Code: Micro Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'MICROCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Display Order: Display Order' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'DISPLAYORDER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Active Flag: Active Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'ACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTDEFLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
