﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_STORAGECONDITION]
(
    /*Section="Columns"*/
    [STORAGECONDITIONID] INT NOT NULL,
    [CONDITION_TXT]      VARCHAR(100) NOT NULL,
    [COMMENT_DSC]        VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRD_STORAGECONDITION_PK] PRIMARY KEY ([STORAGECONDITIONID])
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [PRD_STORAGECONDITION_X01] ON [PRD_STORAGECONDITION] ([CONDITION_TXT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Storage Condition: Saklama koşulları bilgisi bu tabloda tutulacaktır.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_STORAGECONDITION',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Storage Condition Id: Identity column for PRD_STORAGECONDITION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_STORAGECONDITION',
    @level2type=N'COLUMN',
    @level2name=N'STORAGECONDITIONID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Condition: Saklama koşulu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_STORAGECONDITION',
    @level2type=N'COLUMN',
    @level2name=N'CONDITION_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for storage condition.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_STORAGECONDITION',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/
