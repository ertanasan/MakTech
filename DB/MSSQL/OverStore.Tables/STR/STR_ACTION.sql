﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_ACTION]
(
    /*Section="Columns"*/
    [ACTIONID]  INT NOT NULL,
    [ACTION_NM] VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_ACTION_PK] PRIMARY KEY ([ACTIONID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Store Action: Store Action',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_ACTION',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Action Id: Identity column for STR_ACTION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_ACTION', 
    @level2type=N'COLUMN',
    @level2name=N'ACTIONID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Action Name: Name of store action.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_ACTION', 
    @level2type=N'COLUMN',
    @level2name=N'ACTION_NM'
GO

/*Section="End"*/
