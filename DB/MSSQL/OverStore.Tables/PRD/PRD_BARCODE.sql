﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_BARCODE]
(
    /*Section="Columns"*/
    [BARCODEID]    INT NOT NULL IDENTITY,
    [ORGANIZATION] INT NOT NULL,
    [DELETED_FL]   VARCHAR NOT NULL,
    [CREATE_DT]    DATETIME NOT NULL,
    [UPDATE_DT]    DATETIME NULL,
    [CREATEUSER]   INT NOT NULL,
    [UPDATEUSER]   INT NULL,
    [PRODUCT]      INT NOT NULL,
    [BARCODETYPE]  INT NOT NULL,
    [BARCODE_TXT]  VARCHAR(1000) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRD_BARCODE_PK] PRIMARY KEY ([BARCODEID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [PRD_BARCODE_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [PRD_BARCODE_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRD_BARCODE_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRD_BARCODE_F04] FOREIGN KEY ([PRODUCT]) REFERENCES [PRD_PRODUCT]([PRODUCTID]),
    CONSTRAINT [PRD_BARCODE_F05] FOREIGN KEY ([BARCODETYPE]) REFERENCES [PRD_BARCODETYPE]([BARCODETYPEID])
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [PRD_BARCODE_X01] ON [PRD_BARCODE] ([BARCODE_TXT], [ORGANIZATION])
GO

CREATE INDEX [PRD_BARCODE_X02] ON [PRD_BARCODE] ([PRODUCT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Product Barcode: Product Barcode',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_BARCODE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product Barcode Id: Identity column for PRD_BARCODE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'BARCODEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product: Product' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode Type: Perakende, raf, koli vs... barkodları tutar' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'BARCODETYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode Text: Barcode Text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODE',
    @level2type=N'COLUMN',
    @level2name=N'BARCODE_TXT'
GO

/*Section="End"*/