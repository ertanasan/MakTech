-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [HDK_REQUESTGROUPLOG]
(
    /*Section="Columns"*/
    [REQUESTGROUPID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [REQUESTGROUP_NM] VARCHAR(100) NOT NULL,
    [DISPLAYORDER_NO] INT NULL,
    [ACTIVE_FL] VARCHAR(1) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Request Group Log: Talep Grupları, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'HDK_REQUESTGROUPLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Group Id: Identity column for HDK_REQUESTGROUP' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTGROUPID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Group Name: Name of request group.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTGROUP_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Display Order: Display Order' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'DISPLAYORDER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Active Flag: Active Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'ACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_REQUESTGROUPLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
