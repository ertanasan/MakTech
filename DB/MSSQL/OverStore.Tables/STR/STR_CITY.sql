﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_CITY]
(
    /*Section="Columns"*/
    [CITYID]        INT NOT NULL IDENTITY,
    [CITY_NM]       VARCHAR(100) NOT NULL,
    [PLATECODE_TXT] VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_CITY_PK] PRIMARY KEY ([CITYID]) 
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [STR_CITY_X01] ON [STR_CITY] ([CITY_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'City: City',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_CITY',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'City Id: Identity column for STR_CITY' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_CITY', 
    @level2type=N'COLUMN',
    @level2name=N'CITYID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'City Name: Name of city.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_CITY', 
    @level2type=N'COLUMN',
    @level2name=N'CITY_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Plate Code: Plate Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_CITY', 
    @level2type=N'COLUMN',
    @level2name=N'PLATECODE_TXT'
GO

/*Section="End"*/