-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_PLAYERLOG]
(
    /*Section="Columns"*/
    [PLAYERID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [PLAYER_NM] VARCHAR(100) NOT NULL,
    [BRANCH] INT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Game Player Log: Player, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_PLAYERLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Player Id: Identity column for GAM_PLAYER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'PLAYERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Player Name: Name of game player.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'PLAYER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Branch: Branch' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'BRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYERLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
