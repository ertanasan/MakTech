﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_TRANSFERPRODUCTDETAIL]
(
    /*Section="Columns"*/
    [TRANSFERPRODUCTDETAILID] BIGINT NOT NULL IDENTITY,
    [EVENT]                   INT NOT NULL,
    [ORGANIZATION]            INT NOT NULL,
    [DELETED_FL]              VARCHAR NOT NULL,
    [CREATE_DT]               DATETIME NOT NULL,
    [UPDATE_DT]               DATETIME NULL,
    [CREATEUSER]              INT NOT NULL,
    [UPDATEUSER]              INT NULL,
    [CREATECHANNEL]           INT NOT NULL,
    [CREATEBRANCH]            INT NOT NULL,
    [CREATESCREEN]            INT NOT NULL,
    [PRODUCT]                 INT NOT NULL,
    [TRANSFERPRODUCT]         BIGINT NOT NULL,
    [QUANTITY_QTY]            NUMERIC(11,4) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_PK] PRIMARY KEY ([TRANSFERPRODUCTDETAILID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F08] FOREIGN KEY ([PRODUCT]) REFERENCES [PRD_PRODUCT]([PRODUCTID]),
    CONSTRAINT [WHS_TRANSFERPRODUCTDETAIL_F09] FOREIGN KEY ([TRANSFERPRODUCT]) REFERENCES [WHS_TRANSFERPRODUCT]([TRANSFERPRODUCTID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [WHS_TRANSFERPRODUCTDETAIL_X01] ON [WHS_TRANSFERPRODUCTDETAIL] ([PRODUCT])
GO

CREATE INDEX [WHS_TRANSFERPRODUCTDETAIL_X02] ON [WHS_TRANSFERPRODUCTDETAIL] ([TRANSFERPRODUCT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Transfer Product Detail: Detail table of STR_TRANSFERPRODUCT',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transfer Product Detail Id: Identity column for STR_TRANSFERPRODUCTDETAIL' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'TRANSFERPRODUCTDETAILID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product: productId from PRD_PRODUCT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transfer Product: TransferProductId from WHS_TRANSFERPRODUCT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'TRANSFERPRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Quantity: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCTDETAIL',
    @level2type=N'COLUMN',
    @level2name=N'QUANTITY_QTY'
GO

/*Section="End"*/
