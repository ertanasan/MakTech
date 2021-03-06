﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [SLS_SALEZET]
(
    /*Section="Columns"*/
    [SALEZETID]        BIGINT NOT NULL IDENTITY,
    [EVENT]            INT NOT NULL,
    [ORGANIZATION]     INT NOT NULL,
    [DELETED_FL]       VARCHAR NOT NULL,
    [CREATE_DT]        DATETIME NOT NULL,
    [UPDATE_DT]        DATETIME NULL,
    [CREATEUSER]       INT NOT NULL,
    [UPDATEUSER]       INT NULL,
    [CREATECHANNEL]    INT NOT NULL,
    [CREATEBRANCH]     INT NOT NULL,
    [CREATESCREEN]     INT NOT NULL,
    [STORE]            INT NOT NULL,
    [TRANSACTION_DT]   DATETIME NOT NULL,
    [ZET_NO]           INT NULL,
    [RECEIPT_CNT]      INT NULL,
    [RECEIPTTOTAL_AMT] NUMERIC(22,6) NULL,
    [REFUND_CNT]       INT NULL,
    [REFUND_AMT]       NUMERIC(22,6) NULL,
    [CASH_AMT]         NUMERIC(22,6) NULL,
    [CARD_AMT]         NUMERIC(22,6) NULL,
    [CASHREGISTER]     INT NOT NULL,
    [SLPTOTAL_AMT]     NUMERIC(22,6) NULL,
    [SLP_CNT]          INT NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [SLS_SALEZET_PK] PRIMARY KEY ([SALEZETID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [SLS_SALEZET_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [SLS_SALEZET_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [SLS_SALEZET_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [SLS_SALEZET_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [SLS_SALEZET_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [SLS_SALEZET_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [SLS_SALEZET_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [SLS_SALEZET_F08] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [SLS_SALEZET_F09] FOREIGN KEY ([CASHREGISTER]) REFERENCES [STR_CASHREGISTER]([CASHREGISTERID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [SLS_SALEZET_X01] ON [SLS_SALEZET] ([STORE])
GO

CREATE INDEX [SLS_SALEZET_X02] ON [SLS_SALEZET] ([CASHREGISTER])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Sale Daily Summary: Sale Daily Summary',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SLS_SALEZET',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale Daily Summary Id: Identity column for SLS_SALEZET' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'SALEZETID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store ID: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transaction Date: Transaction Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'TRANSACTION_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Zet No: Zet No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'ZET_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Receipt Count: Receipt Count' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'RECEIPT_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Receipt Total: Receipt Total' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'RECEIPTTOTAL_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Refund Count: Refund Count' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'REFUND_CNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Refund Amount: Refund Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'REFUND_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cash Amount: Cash Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CASH_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Card Amount: Card Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CARD_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cash Register: Cash Register' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'CASHREGISTER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'SlpTotal: Z satırı faturalı satış toplamı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'SLPTOTAL_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'SlpCount: Z satırı faturalı satır sayısı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'SLS_SALEZET',
    @level2type=N'COLUMN',
    @level2name=N'SLP_CNT'
GO

/*Section="End"*/
