﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_SUPERGROUP3]
(
    /*Section="Columns"*/
    [SUPERGROUP3ID]  INT NOT NULL,
    [SUPERGROUP3_NM] VARCHAR(100) NOT NULL,
    [COMMENT_DSC]    VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRD_SUPERGROUP3_PK] PRIMARY KEY ([SUPERGROUP3ID])
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [PRD_SUPERGROUP3_X01] ON [PRD_SUPERGROUP3] ([SUPERGROUP3_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Super Group 3: Üst grup 2',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_SUPERGROUP3',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Super Group 3 Id: Identity column for PRD_SUPERGROUP3' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_SUPERGROUP3',
    @level2type=N'COLUMN',
    @level2name=N'SUPERGROUP3ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Super Group 3 Name: Name of super group 3.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_SUPERGROUP3',
    @level2type=N'COLUMN',
    @level2name=N'SUPERGROUP3_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for super group 3.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_SUPERGROUP3',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/
