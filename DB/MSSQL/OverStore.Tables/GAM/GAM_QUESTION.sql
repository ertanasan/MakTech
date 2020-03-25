﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_QUESTION]
(
    /*Section="Columns"*/
    [QUESTIONID]   INT NOT NULL IDENTITY,
    [QUESTION_TXT] VARCHAR(4000) NOT NULL,
    [DIFFLEVEL_CD] INT NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [GAM_QUESTION_PK] PRIMARY KEY ([QUESTIONID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Game Question: Game Question',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_QUESTION',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Question Id: Identity column for GAM_QUESTION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_QUESTION', 
    @level2type=N'COLUMN',
    @level2name=N'QUESTIONID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Question Text: Question Text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_QUESTION', 
    @level2type=N'COLUMN',
    @level2name=N'QUESTION_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'DifficultyLevel: Difficulty Level 1:easiest .. ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_QUESTION', 
    @level2type=N'COLUMN',
    @level2name=N'DIFFLEVEL_CD'
GO

/*Section="End"*/