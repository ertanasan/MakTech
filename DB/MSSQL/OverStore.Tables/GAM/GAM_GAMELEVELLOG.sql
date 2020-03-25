-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_GAMELEVELLOG]
(
    /*Section="Columns"*/
    [GAMELEVELID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [GAME] INT NOT NULL,
    [LEVEL_NM] VARCHAR(100) NOT NULL,
    [QUESTION_CNT] INT NOT NULL,
    [MINDIFFLEVEL_CD] INT NOT NULL,
    [MAXDIFFLEVEL_CD] INT NOT NULL,
    [DURATION_CNT] INT NOT NULL,
    [ERRTOLERANCE_CNT] INT NULL,
    [POINTOFRIGHTANSWER_NO] INT NOT NULL,
    [LEVEL_CD] INT NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Game Level Log: Game Level, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_GAMELEVELLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Level Id: Identity column for GAM_GAMELEVEL' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'GAMELEVELID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game: Game' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'GAME'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Level Name: Name of game level.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LEVEL_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Question Count: Question Count' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'QUESTION_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Min Difficulty Level: Min Difficulty Level' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'MINDIFFLEVEL_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Max Difficulty Level: Max Difficulty Level' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'MAXDIFFLEVEL_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Duration: Duration' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'DURATION_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Level Error Tolerance: Level Error Tolerance' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'ERRTOLERANCE_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Point of Right Answer: Point of Right Answer' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'POINTOFRIGHTANSWER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Level Code: Level Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LEVEL_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAMELEVELLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
