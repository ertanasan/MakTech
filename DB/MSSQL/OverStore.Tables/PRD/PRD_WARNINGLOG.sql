-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_WARNINGLOG]
(
    /*Section="Columns"*/
    [WARNINGID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [WARNING_TXT] VARCHAR(1000) NOT NULL,
    [COMMENT_DSC] VARCHAR(1000) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Warning Log: Ürün uyarıları, etiket için, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_WARNINGLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Warning Id: Identity column for PRD_WARNING' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'WARNINGID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Warning Text: Ürün uyarısı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'WARNING_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for warning.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_WARNINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
