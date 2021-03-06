﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_COUNTRY]
(
    /*Section="Columns"*/
    [COUNTRYID]   INT NOT NULL,
    [COUNTRY_NM]  VARCHAR(100) NOT NULL,
    [COMMENT_DSC] VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRD_COUNTRY_PK] PRIMARY KEY ([COUNTRYID])
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [PRD_COUNTRY_X01] ON [PRD_COUNTRY] ([COUNTRY_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Country: Ülkeler listesi',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_COUNTRY',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Country Id: Identity column for PRD_COUNTRY' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_COUNTRY',
    @level2type=N'COLUMN',
    @level2name=N'COUNTRYID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'CountryName: Name of country' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_COUNTRY',
    @level2type=N'COLUMN',
    @level2name=N'COUNTRY_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for country.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_COUNTRY',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/
