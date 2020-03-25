-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_PROHIBITEDHOURSLOG]
(
    /*Section="Columns"*/
    [PROHIBITEDHOURSID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [ACTION] INT NOT NULL,
    [STORE_CD] INT NULL,
    [STARTHOUR_NO] INT NOT NULL,
    [ENDHOUR_NO] INT NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Prohibited Hours Log: Prohibited Hours, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_PROHIBITEDHOURSLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Prohibited Hours Id: Identity column for STR_PROHIBITEDHOURS' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'PROHIBITEDHOURSID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Action: Action' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'ACTION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Code: Store Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'STORE_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Start Hour: Start Hour' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'STARTHOUR_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'End Hour: End Hour' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'ENDHOUR_NO'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_PROHIBITEDHOURSLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
