﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_FAKEORDER]
(
    /*Section="Columns"*/
    [FAKEORDERID]   BIGINT NOT NULL IDENTITY,
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
    [ORDER_DT]      DATETIME NOT NULL,
    [STORE]         INT NOT NULL,
    [PRODUCT]       INT NOT NULL,
    [SENT_AMT]      NUMERIC(10,3) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_FAKEORDER_PK] PRIMARY KEY ([FAKEORDERID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_FAKEORDER_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [WHS_FAKEORDER_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [WHS_FAKEORDER_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_FAKEORDER_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_FAKEORDER_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [WHS_FAKEORDER_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [WHS_FAKEORDER_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [WHS_FAKEORDER_F08] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [WHS_FAKEORDER_F09] FOREIGN KEY ([PRODUCT]) REFERENCES [PRD_PRODUCT]([PRODUCTID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [WHS_FAKEORDER_X01] ON [WHS_FAKEORDER] ([STORE])
GO

CREATE INDEX [WHS_FAKEORDER_X02] ON [WHS_FAKEORDER] ([PRODUCT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fake Order: Table to keep products to test stores if they check ordered products properly.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_FAKEORDER',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Fake Order Id: Identity column for WHS_FAKEORDER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'FAKEORDERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Order Date: Order Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORDER_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Product: Product' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sent Amount: Sent Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_FAKEORDER',
    @level2type=N'COLUMN',
    @level2name=N'SENT_AMT'
GO

/*Section="End"*/