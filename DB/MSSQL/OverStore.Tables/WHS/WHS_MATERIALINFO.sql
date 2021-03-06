﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_MATERIALINFO]
(
    /*Section="Columns"*/
    [MATERIALINFOID] INT NOT NULL IDENTITY,
    [MATERIAL]       INT NOT NULL,
    [INFOSHORT_NM]   VARCHAR(100) NOT NULL,
    [INFO_NM]        VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_MATERIALINFO_PK] PRIMARY KEY ([MATERIALINFOID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_MATERIALINFO_F01] FOREIGN KEY ([MATERIAL]) REFERENCES [WHS_MATERIAL]([MATERIALID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Material Info: Material Info',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_MATERIALINFO',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Material Info Id: Identity column for WHS_MATERIALINFO' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALINFO', 
    @level2type=N'COLUMN',
    @level2name=N'MATERIALINFOID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Material: Material' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALINFO', 
    @level2type=N'COLUMN',
    @level2name=N'MATERIAL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Short Name: Name of material info.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALINFO', 
    @level2type=N'COLUMN',
    @level2name=N'INFOSHORT_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Info Name: Name of material info.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALINFO', 
    @level2type=N'COLUMN',
    @level2name=N'INFO_NM'
GO

/*Section="End"*/
