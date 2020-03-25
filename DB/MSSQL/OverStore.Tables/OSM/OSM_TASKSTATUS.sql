﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [OSM_TASKSTATUS]
(
    /*Section="Columns"*/
    [TASKSTATUSID] INT NOT NULL,
    [STATUS_NM]    VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [OSM_TASKSTATUS_PK] PRIMARY KEY ([TASKSTATUSID]) 
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [OSM_TASKSTATUS_X01] ON [OSM_TASKSTATUS] ([STATUS_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'OverStoreTaskStatus: Status Name',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'OSM_TASKSTATUS',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'OverStoreTaskStatus Id: Identity column for OSM_TASKSTATUS' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_TASKSTATUS', 
    @level2type=N'COLUMN',
    @level2name=N'TASKSTATUSID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status: Name of overstoretaskstatus.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_TASKSTATUS', 
    @level2type=N'COLUMN',
    @level2name=N'STATUS_NM'
GO

/*Section="End"*/