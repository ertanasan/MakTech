﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_MATERIALORDER]
(
    /*Section="Columns"*/
    [MATERIALORDERID]     BIGINT NOT NULL IDENTITY,
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
    [ORDER_NM]            VARCHAR(100) NOT NULL,
    [ORDER_DT]            DATETIME NOT NULL,
    [ORDERSTATUS_CD]      INT NOT NULL,
    [STORE]               INT NOT NULL,
    [PROCESSINSTANCE_LNO] BIGINT NULL,
    [MIKROSTATUS_CD]      INT NULL,
    [MIKROREF_TXT]        VARCHAR(100) NULL,
    [MIKRO_TM]            DATETIME NULL,
    [MIKROUSER]           INT NULL,
    [MATERIAL]            INT NOT NULL,
    [MATERIALINFO]        INT NULL,
    [ORDER_AMT]           NUMERIC(10,3) NOT NULL,
    [REVISED_AMT]         NUMERIC(10,3) NOT NULL,
    [SHIPPED_AMT]         NUMERIC(10,3) NOT NULL,
    [INTAKE_AMT]          NUMERIC(10,3) NOT NULL,
    [NOTE_TXT]            VARCHAR(1000) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_MATERIALORDER_PK] PRIMARY KEY ([MATERIALORDERID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_MATERIALORDER_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [WHS_MATERIALORDER_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [WHS_MATERIALORDER_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_MATERIALORDER_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_MATERIALORDER_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [WHS_MATERIALORDER_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [WHS_MATERIALORDER_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [WHS_MATERIALORDER_F08] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [WHS_MATERIALORDER_F09] FOREIGN KEY ([MIKROUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_MATERIALORDER_F10] FOREIGN KEY ([MATERIAL]) REFERENCES [WHS_MATERIAL]([MATERIALID]),
    CONSTRAINT [WHS_MATERIALORDER_F11] FOREIGN KEY ([MATERIALINFO]) REFERENCES [WHS_MATERIALINFO]([MATERIALINFOID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [WHS_MATERIALORDER_X01] ON [WHS_MATERIALORDER] ([STORE])
GO

CREATE INDEX [WHS_MATERIALORDER_X02] ON [WHS_MATERIALORDER] ([MIKROUSER])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Material Order: Material Order',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_MATERIALORDER',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Material Order Id: Identity column for WHS_MATERIALORDER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MATERIALORDERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Order Name: Name of material order.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORDER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Order Date: Order Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORDER_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Order Status Code: Order Status Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORDERSTATUS_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process Instance Number: Process Instance Number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'PROCESSINSTANCE_LNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Status Code: Mikro Status Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MIKROSTATUS_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Reference: Mikro Reference' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MIKROREF_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Time: Mikro Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MIKRO_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro User: Mikro User' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MIKROUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Material: Material' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MATERIAL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'MaterialInfo: MaterialInfo' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'MATERIALINFO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Order Quantity: Order Quantity' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'ORDER_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Revised Quantity: Revised Quantity' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'REVISED_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Shipped Quantity: Shipped Quantity' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'SHIPPED_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Intake Quantity: Intake Quantity' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'INTAKE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Note: Note' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_MATERIALORDER',
    @level2type=N'COLUMN',
    @level2name=N'NOTE_TXT'
GO

/*Section="End"*/