﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_PLAYER]
(
    /*Section="Columns"*/
    [PLAYERID]  INT NOT NULL IDENTITY,
    [PLAYER_NM] VARCHAR(100) NOT NULL,
    [BRANCH]    INT NULL,
	[USERID]	INT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [GAM_PLAYER_PK] PRIMARY KEY ([PLAYERID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [GAM_PLAYER_F01] FOREIGN KEY ([BRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]) 
);
GO

/*Section="Indexes"*/

CREATE INDEX [GAM_PLAYER_X01] ON [GAM_PLAYER] ([BRANCH])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Game Player: Player',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_PLAYER',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Player Id: Identity column for GAM_PLAYER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYER', 
    @level2type=N'COLUMN',
    @level2name=N'PLAYERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Player Name: Name of game player.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYER', 
    @level2type=N'COLUMN',
    @level2name=N'PLAYER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Branch: Branch' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_PLAYER', 
    @level2type=N'COLUMN',
    @level2name=N'BRANCH'
GO

/*Section="End"*/