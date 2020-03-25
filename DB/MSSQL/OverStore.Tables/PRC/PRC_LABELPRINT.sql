﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRC_LABELPRINT]
(
    /*Section="Columns"*/
    [LABELPRINTID]  BIGINT NOT NULL IDENTITY,
    [EVENT]         INT NOT NULL,
    [ORGANIZATION]  INT NOT NULL,
    [DELETED_FL]    VARCHAR NOT NULL,
    [CREATE_DT]     DATETIME NOT NULL,
    [UPDATE_DT]     DATETIME NULL,
    [CREATEUSER]    INT NOT NULL,
    [UPDATEUSER]    INT NULL,
    [CREATECHANNEL] INT NOT NULL,
    [CREATEBRANCH]  INT NOT NULL,
    [CREATESCREEN]  INT NOT NULL,
    [PRODUCT]       INT NOT NULL,
    [CURRENTPRICE]  INT NOT NULL,
    [LABELSIZE_TXT] VARCHAR(10) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRC_LABELPRINT_PK] PRIMARY KEY ([LABELPRINTID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [PRC_LABELPRINT_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [PRC_LABELPRINT_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [PRC_LABELPRINT_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRC_LABELPRINT_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRC_LABELPRINT_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [PRC_LABELPRINT_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [PRC_LABELPRINT_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [PRC_LABELPRINT_F08] FOREIGN KEY ([PRODUCT]) REFERENCES [PRD_PRODUCT]([PRODUCTID]),
    CONSTRAINT [PRC_LABELPRINT_F09] FOREIGN KEY ([CURRENTPRICE]) REFERENCES [PRC_CURRENTPRICE]([CURRENTPRICEID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [PRC_LABELPRINT_X01] ON [PRC_LABELPRINT] ([PRODUCT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Price Label Print: Print Label Print',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRC_LABELPRINT',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Label Print Id: Identity column for PRC_PRICELABEL' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'LABELPRINTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product: Product' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Current Price: Current price id for the product while printing' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'CURRENTPRICE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Label Size: label size' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_LABELPRINT',
    @level2type=N'COLUMN',
    @level2name=N'LABELSIZE_TXT'
GO

/*Section="End"*/
