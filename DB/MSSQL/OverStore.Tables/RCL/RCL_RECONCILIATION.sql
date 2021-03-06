﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [RCL_RECONCILIATION]
(
    /*Section="Columns"*/
    [RECONCILIATIONID]       BIGINT NOT NULL IDENTITY,
    [EVENT]                  INT NOT NULL,
    [ORGANIZATION]           INT NOT NULL,
    [DELETED_FL]             VARCHAR NOT NULL,
    [CREATE_DT]              DATETIME NOT NULL,
    [UPDATE_DT]              DATETIME NULL,
    [CREATEUSER]             INT NOT NULL,
    [UPDATEUSER]             INT NULL,
    [CREATECHANNEL]          INT NOT NULL,
    [CREATEBRANCH]           INT NOT NULL,
    [CREATESCREEN]           INT NOT NULL,
    [TRANSACTION_DT]         DATETIME NOT NULL,
    [STORE]                  INT NOT NULL,
    [PREVIOUSDAYADVANCE_AMT] NUMERIC(22,6) NOT NULL,
    [SALETOTAL_AMT]          NUMERIC(22,6) NOT NULL,
    [CASHTOTAL_AMT]          NUMERIC(22,6) NOT NULL,
    [CARDTOTAL_AMT]          NUMERIC(22,6) NOT NULL,
    [TOBANK_AMT]             NUMERIC(22,6) NOT NULL,
    [DIFFERENCE_AMT]         NUMERIC(22,6) NOT NULL,
    [DIFFERENCE_DSC]         VARCHAR(1000) NULL,
    [COMPLETED_AMT]          NUMERIC(22,6) NOT NULL,
    [EODADVANCE_AMT]         NUMERIC(22,6) NOT NULL,
    [RECONCILIATED_FL]       VARCHAR(1) NULL,
    [APPROVED_FL]            VARCHAR(1) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [RCL_RECONCILIATION_PK] PRIMARY KEY ([RECONCILIATIONID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [RCL_RECONCILIATION_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [RCL_RECONCILIATION_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [RCL_RECONCILIATION_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [RCL_RECONCILIATION_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [RCL_RECONCILIATION_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [RCL_RECONCILIATION_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [RCL_RECONCILIATION_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [RCL_RECONCILIATION_F08] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [RCL_RECONCILIATION_X01] ON [RCL_RECONCILIATION] ([STORE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Store Reconciliation: Mağaza mutabakat tablosudur.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'RCL_RECONCILIATION',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Reconciliation Id: Identity column for RCL_RECONCILIATION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'RECONCILIATIONID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transaction Date: Mutabakat tarihi' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'TRANSACTION_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store ID: Mağaza kodu' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Previous Day Amount: Önceki gün avansı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'PREVIOUSDAYADVANCE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale Total: Satışlar toplamı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'SALETOTAL_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cash Total: Avans dahil kasa sayım toplamıdır.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CASHTOTAL_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Card Total: Kart toplamı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'CARDTOTAL_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'To Bank: Bankaya gidecek miktar' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'TOBANK_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Difference: Eksi ya da artı fark' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'DIFFERENCE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Difference Explanation: Comment for store reconciliation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'DIFFERENCE_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Completed: Tamamlanan kasa farkı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'COMPLETED_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Eod Advance: Gün sonu avansı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'EODADVANCE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Reconciliated: Başarılı mutabakat yapıldıysa bu işaret Y yapılacak.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'RECONCILIATED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Approved: Muhasbe onayladı mı?' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'RCL_RECONCILIATION',
    @level2type=N'COLUMN',
    @level2name=N'APPROVED_FL'
GO

/*Section="End"*/
