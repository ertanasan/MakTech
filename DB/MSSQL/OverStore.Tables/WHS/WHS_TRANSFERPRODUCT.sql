﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_TRANSFERPRODUCT]
(
    /*Section="Columns"*/
    [TRANSFERPRODUCTID]   BIGINT NOT NULL IDENTITY,
    [EVENT]               INT NOT NULL,
    [ORGANIZATION]        INT NOT NULL,
    [DELETED_FL]          VARCHAR NOT NULL,
    [CREATE_DT]           DATETIME NOT NULL,
    [UPDATE_DT]           DATETIME NULL,
    [CREATEUSER]          INT NOT NULL,
    [UPDATEUSER]          INT NULL,
    [CREATECHANNEL]       INT NOT NULL,
    [CREATEBRANCH]        INT NOT NULL,
    [CREATESCREEN]        INT NOT NULL,
    [SOURCESTORE]         INT NOT NULL,
    [DESTINATIONSTORE]    INT NOT NULL,
    [PROCESSINSTANCE_LNO] BIGINT NULL,
    [TRANSFERSTATUS]      INT NOT NULL,
    [WAYBILL_TXT]         VARCHAR(50) NULL,
    [RETURNDESTINATION]   INT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_TRANSFERPRODUCT_PK] PRIMARY KEY ([TRANSFERPRODUCTID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_TRANSFERPRODUCT_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F08] FOREIGN KEY ([SOURCESTORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F09] FOREIGN KEY ([DESTINATIONSTORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F10] FOREIGN KEY ([TRANSFERSTATUS]) REFERENCES [WHS_TRANSFERPRODUCTSTATUS]([TRANSFERPRODUCTSTATUSID]),
    CONSTRAINT [WHS_TRANSFERPRODUCT_F11] FOREIGN KEY ([RETURNDESTINATION]) REFERENCES [WHS_RETURNDESTINATION]([RETURNDESTINATIONID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [WHS_TRANSFERPRODUCT_X01] ON [WHS_TRANSFERPRODUCT] ([SOURCESTORE])
GO

CREATE INDEX [WHS_TRANSFERPRODUCT_X02] ON [WHS_TRANSFERPRODUCT] ([DESTINATIONSTORE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Transfer Product: Defination of product transfer  between at stores ',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_TRANSFERPRODUCT',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transfer Product Id: Identity column for WHS_TRANSFERPRODUCT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'TRANSFERPRODUCTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Source Store: StoreId from STR_STORE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'SOURCESTORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Destination Store: StoreId from STR_STORE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'DESTINATIONSTORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process Instance: ProcessInstanceId from BPM_PROCESSINSTANCE  (not a referance value)' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'PROCESSINSTANCE_LNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transfer Status: Status of Transfer Product' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'TRANSFERSTATUS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Waybill No: irsaliye numarası' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'WAYBILL_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Target Warehouse: reference from WHS_RETURNDESTINATION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_TRANSFERPRODUCT',
    @level2type=N'COLUMN',
    @level2name=N'RETURNDESTINATION'
GO

/*Section="End"*/
