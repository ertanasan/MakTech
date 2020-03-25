﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_SEASONTYPE]
(
    /*Section="Columns"*/
    [SEASONTYPEID]  INT NOT NULL,
    [SEASONTYPE_NM] VARCHAR(100) NOT NULL,
    [COMMENT_DSC]   VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRD_SEASONTYPE_PK] PRIMARY KEY ([SEASONTYPEID])
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [PRD_SEASONTYPE_X01] ON [PRD_SEASONTYPE] ([SEASONTYPE_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Season Type: Sezonlar',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_SEASONTYPE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Season Type Id: Identity column for PRD_SEASONTYPE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_SEASONTYPE',
    @level2type=N'COLUMN',
    @level2name=N'SEASONTYPEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Season Type Name: Name of season type.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_SEASONTYPE',
    @level2type=N'COLUMN',
    @level2name=N'SEASONTYPE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for season type.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_SEASONTYPE',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/