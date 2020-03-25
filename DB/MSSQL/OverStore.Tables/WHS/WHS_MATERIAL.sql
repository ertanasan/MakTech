﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_MATERIAL]
(
    /*Section="Columns"*/
    [MATERIALID]       INT NOT NULL IDENTITY,
    [MATERIAL_NM]      VARCHAR(100) NOT NULL,
    [MIKRO_DSC]        VARCHAR(100) NULL,
    [UNIT_CD]          INT NOT NULL,
    [MATERIALCATEGORY] INT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_MATERIAL_PK] PRIMARY KEY ([MATERIALID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_MATERIAL_F01] FOREIGN KEY ([MATERIALCATEGORY]) REFERENCES [WHS_MATERIALCATEGORY]([MATERIALCATEGORYID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Material: Material',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_MATERIAL',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Material Id: Identity column for WHS_MATERIAL' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIAL', 
    @level2type=N'COLUMN',
    @level2name=N'MATERIALID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Material Name: Name of material.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIAL', 
    @level2type=N'COLUMN',
    @level2name=N'MATERIAL_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Code: Mikro Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIAL', 
    @level2type=N'COLUMN',
    @level2name=N'MIKRO_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Unit Code: Unit Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIAL', 
    @level2type=N'COLUMN',
    @level2name=N'UNIT_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Category: Category' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIAL', 
    @level2type=N'COLUMN',
    @level2name=N'MATERIALCATEGORY'
GO

/*Section="End"*/
