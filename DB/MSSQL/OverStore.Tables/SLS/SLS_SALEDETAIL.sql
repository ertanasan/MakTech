﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [SLS_SALEDETAIL]
(
    /*Section="Columns"*/
    [SALEDETAILID]    BIGINT NOT NULL IDENTITY,
    [EVENT]           INT NOT NULL,
    [ORGANIZATION]    INT NOT NULL,
    [DELETED_FL]      VARCHAR NOT NULL,
    [CREATE_DT]       DATETIME NOT NULL,
    [UPDATE_DT]       DATETIME NULL,
    [CREATEUSER]      INT NOT NULL,
    [UPDATEUSER]      INT NULL,
    [CREATECHANNEL]   INT NOT NULL,
    [CREATEBRANCH]    INT NOT NULL,
    [CREATESCREEN]    INT NOT NULL,
    [SALE]            BIGINT NOT NULL,
    [TRANSACTION_TXT] VARCHAR(100) NOT NULL,
    [TRANSACTION_DT]  DATETIME NOT NULL,
    [BARCODE_TXT]     VARCHAR(100) NOT NULL,
    [PRODUCT]         INT NOT NULL,
    [PRODUCTCODE_NM]  VARCHAR(100) NOT NULL,
    [STORE]           INT NOT NULL,
    [PRICE]           NUMERIC(22,6) NOT NULL,
    [VAT_RT]          NUMERIC(4,2) NOT NULL,
    [QUANTITY_QTY]    INT NOT NULL,
    [UNIT]            INT NOT NULL,
    [CANCEL_FL]       VARCHAR(1) NOT NULL,
    [UNITPRICE_AMT]   NUMERIC(22,6) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [SLS_SALEDETAIL_PK] PRIMARY KEY ([SALEDETAILID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [SLS_SALEDETAIL_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [SLS_SALEDETAIL_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [SLS_SALEDETAIL_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [SLS_SALEDETAIL_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [SLS_SALEDETAIL_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [SLS_SALEDETAIL_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [SLS_SALEDETAIL_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [SLS_SALEDETAIL_F08] FOREIGN KEY ([SALE]) REFERENCES [SLS_SALE]([SALEID]),
    CONSTRAINT [SLS_SALEDETAIL_F09] FOREIGN KEY ([PRODUCT]) REFERENCES [PRD_PRODUCT]([PRODUCTID]),
    CONSTRAINT [SLS_SALEDETAIL_F10] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [SLS_SALEDETAIL_F11] FOREIGN KEY ([UNIT]) REFERENCES [PRD_UNIT]([UNITID])
);
GO

/*Section="Indexes"*/

CREATE NONCLUSTERED INDEX [SLS_SALEDETAIL_X01] ON [dbo].[SLS_SALEDETAIL]
(
	[SALE] ASC
)
GO

CREATE NONCLUSTERED INDEX [SLS_SALEDETAIL_X02] ON [dbo].[SLS_SALEDETAIL]
(
	[PRODUCT] ASC
)
GO

CREATE NONCLUSTERED INDEX [SLS_SALEDETAIL_X03] ON [dbo].[SLS_SALEDETAIL]
(
	[STORE] ASC
)
INCLUDE ( 	[SALE],
	[PRODUCT],
	[PRICE],
	[QUANTITY_QTY],
	[UNIT],
	[DELETED_FL],
	[CANCEL_FL],
	[TRANSACTION_DT])
GO

CREATE NONCLUSTERED INDEX [SLS_SALEDETAIL_X04] ON [dbo].[SLS_SALEDETAIL]
(
	[TRANSACTION_DT] ASC
)
INCLUDE ( 	[SALE],
	[PRODUCT],
	[STORE],
	[PRICE],
	[UNIT],
	[QUANTITY_QTY],
	[VAT_RT],
	[CANCEL_FL],
	[DELETED_FL],
	[UNITPRICE_AMT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Sale Detail: Satış detaylarını saklar',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SLS_SALEDETAIL',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale Detail Id: Identity column for SLS_SALEDETAIL' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'SALEDETAILID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale ID: Sale ID' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'SALE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transaction ID: İşlem kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'TRANSACTION_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transaction Date: Transaction Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'TRANSACTION_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode: Barkod' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'BARCODE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product ID: Master tablodaki  ürün IDsidir.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Code: Ürün kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTCODE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store Information' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Price: Ürün birim fiyatı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'PRICE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'VAT Rate: KDV oranı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'VAT_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Quantity: Miktar' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'QUANTITY_QTY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Unit: Birim' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'UNIT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cancel Flag: Cancel Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CANCEL_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Unit Price: Unit Price' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'UNITPRICE_AMT'
GO

/*Section="End"*/
