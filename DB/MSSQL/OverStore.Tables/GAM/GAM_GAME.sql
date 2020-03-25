﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_GAME]
(
    /*Section="Columns"*/
    [GAMEID]           INT NOT NULL IDENTITY,
    [GAME_NM]          VARCHAR(100) NOT NULL,
    [ERRTOLERANCE_CNT] INT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [GAM_GAME_PK] PRIMARY KEY ([GAMEID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Game: Game',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_GAME',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Id: Identity column for GAM_GAME' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAME', 
    @level2type=N'COLUMN',
    @level2name=N'GAMEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Name: Name of game.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAME', 
    @level2type=N'COLUMN',
    @level2name=N'GAME_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Error Tolerance: Error Tolerance' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_GAME', 
    @level2type=N'COLUMN',
    @level2name=N'ERRTOLERANCE_CNT'
GO

/*Section="End"*/