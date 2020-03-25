﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [HDK_PROCESSDEF]
(
    /*Section="Columns"*/
    [PROCESSDEFID]  INT NOT NULL IDENTITY,
    [PROCESSDEF_NM] VARCHAR(100) NOT NULL,
    [PROCESS_NO]    INT NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [HDK_PROCESSDEF_PK] PRIMARY KEY ([PROCESSDEFID])
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Process Definition: BPM Process List for HelpDesk Application',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'HDK_PROCESSDEF',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process Definition Id: Identity column for HDK_PROCESSDEF' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_PROCESSDEF',
    @level2type=N'COLUMN',
    @level2name=N'PROCESSDEFID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process Definition Name: Name of process definition.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_PROCESSDEF',
    @level2type=N'COLUMN',
    @level2name=N'PROCESSDEF_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process No: Process No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_PROCESSDEF',
    @level2type=N'COLUMN',
    @level2name=N'PROCESS_NO'
GO

/*Section="End"*/