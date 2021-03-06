﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_FIXTURE]
(
    /*Section="Columns"*/
    [FIXTUREID]         INT NOT NULL IDENTITY,
    [ORGANIZATION]      INT NOT NULL,
    [DELETED_FL]        VARCHAR NOT NULL,
    [CREATE_DT]         DATETIME NOT NULL,
    [UPDATE_DT]         DATETIME NULL,
    [CREATEUSER]        INT NOT NULL,
    [UPDATEUSER]        INT NULL,
    [FIXTURE]           INT NOT NULL,
    [PURCHASE_DT]       DATETIME NULL,
    [SERIALNO_TXT]      VARCHAR(100) NULL,
    [ENDOFGUARANTEE_DT] DATETIME NULL,
    [SUPPLIER]          INT NULL,
    [STORE]             INT NOT NULL,
    [STOREFIXTURE_NM]   VARCHAR(100) NOT NULL,
    [BRAND]             INT NULL,
    [MODEL]             INT NULL,
    [QUANTITY_QTY]      INT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_FIXTURE_PK] PRIMARY KEY ([FIXTUREID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [STR_FIXTURE_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [STR_FIXTURE_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_FIXTURE_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_FIXTURE_F04] FOREIGN KEY ([FIXTURE]) REFERENCES [PRD_FIXTURE]([FIXTUREID]),
    CONSTRAINT [STR_FIXTURE_F05] FOREIGN KEY ([SUPPLIER]) REFERENCES [WHS_SUPPLIER]([SUPPLIERID]),
    CONSTRAINT [STR_FIXTURE_F06] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [STR_FIXTURE_F07] FOREIGN KEY ([BRAND]) REFERENCES [PRD_FIXTUREBRAND]([FIXTUREBRANDID]),
    CONSTRAINT [STR_FIXTURE_F08] FOREIGN KEY ([MODEL]) REFERENCES [PRD_FIXTUREMODEL]([FIXTUREMODELID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [STR_FIXTURE_X01] ON [STR_FIXTURE] ([SUPPLIER])
GO

CREATE INDEX [STR_FIXTURE_X02] ON [STR_FIXTURE] ([STORE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Store Fixture: Mağaza Demirbaş Listesi',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_FIXTURE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Fixture Id: Identity column for STR_FIXTURE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'FIXTUREID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Fixture: Product Fixture' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'FIXTURE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Purchase Date: Purchase Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'PURCHASE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Serial No: Serial No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'SERIALNO_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'End Of Guarantee Date: End Of Guarantee Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'ENDOFGUARANTEE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Supplier: Supplier' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'SUPPLIER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Fixture Name: Name of store fixture.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'STOREFIXTURE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Brand: Brand' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'BRAND'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Model: Model' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'MODEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Quantity: Quantity' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_FIXTURE',
    @level2type=N'COLUMN',
    @level2name=N'QUANTITY_QTY'
GO

/*Section="End"*/
