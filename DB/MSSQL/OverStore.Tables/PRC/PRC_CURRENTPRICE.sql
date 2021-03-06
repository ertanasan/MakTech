﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRC_CURRENTPRICE]
(
    /*Section="Columns"*/
    [CURRENTPRICEID] INT NOT NULL IDENTITY,
    [STORE]          INT NOT NULL,
    [PRODUCTCODE_NM] VARCHAR(100) NOT NULL,
    [PRODUCT_NM]     VARCHAR(100) NOT NULL,
    [BARCODE_TXT]    VARCHAR(30) NOT NULL,
    [PRODUCTUNIT_NO] INT NOT NULL,
    [SALEPRICE_AMT]  NUMERIC(22,6) NOT NULL,
    [SALEVAT_RT]     NUMERIC(4,2) NOT NULL,
    [VERSION_TM]     DATETIME NOT NULL,
    [GROUP_CD]       INT NOT NULL,
	[PACKAGE]		 INT,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRC_CURRENTPRICE_PK] PRIMARY KEY ([CURRENTPRICEID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [PRC_CURRENTPRICE_F01] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [PRC_CURRENTPRICE_X01] ON [PRC_CURRENTPRICE] ([STORE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Current Prices: Current Prices',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRC_CURRENTPRICE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Prices Id: Identity column for PRC_CURRENTPRICE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store ID: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Code Name: Product Code Name' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTCODE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Name: Product Name' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode: Barcode' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'BARCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Unit: Product Unit 1-KG, 2-AD' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTUNIT_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale Price: Sale Price' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'SALEPRICE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale VAT: Sale VAT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'SALEVAT_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Version Time: Version Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'VERSION_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Group Code: Group Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_CURRENTPRICE',
    @level2type=N'COLUMN',
    @level2name=N'GROUP_CD'
GO

/*Section="End"*/
