﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_BANKSTATEMENT]
(
    /*Section="Columns"*/
    [BANKSTATEMENTID] BIGINT NOT NULL IDENTITY,
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
    [BANK]            INT NOT NULL,
    [DATE_DT]         DATETIME NOT NULL,
    [DESCRIPTION_DSC] VARCHAR(1000) NOT NULL,
    [TRANSACTION_AMT] NUMERIC(22,6) NOT NULL,
    [BALANCE_AMT]     NUMERIC(22,6) NOT NULL,
    [CHANNEL_DSC]     VARCHAR(100) NOT NULL,
    [INFO1_DSC]       VARCHAR(100) NULL,
    [INFO2_DSC]       VARCHAR(100) NULL,
    [INFO3_DSC]       VARCHAR(100) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [ACC_BANKSTATEMENT_PK] PRIMARY KEY ([BANKSTATEMENTID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [ACC_BANKSTATEMENT_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [ACC_BANKSTATEMENT_F08] FOREIGN KEY ([BANK]) REFERENCES [STR_BANK]([BANKID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [ACC_BANKSTATEMENT_X01] ON [ACC_BANKSTATEMENT] ([BANK])
GO

CREATE UNIQUE INDEX [ACC_BANKSTATEMENT_X02] ON [ACC_BANKSTATEMENT] ([BANK], [DATE_DT], [DESCRIPTION_DSC], [TRANSACTION_AMT], [BALANCE_AMT]) INCLUDE ([BANKSTATEMENTID])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Bank Statement: Bank Statement',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_BANKSTATEMENT',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Bank Statement Id: Identity column for ACC_BANKSTATEMENT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'BANKSTATEMENTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Bank: Bank' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'BANK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Date: Transaction Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'DATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Description: Comment for bank statement.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'DESCRIPTION_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transaction Amount: Transaction Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'TRANSACTION_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Balance: Balance' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'BALANCE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Channel: Comment for bank statement channel.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'CHANNEL_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Info 1: Comment for bank statement info 1.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'INFO1_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Info 2: Comment for bank statement info 2.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'INFO2_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Info 3: Comment for bank statement info 3.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_BANKSTATEMENT',
    @level2type=N'COLUMN',
    @level2name=N'INFO3_DSC'
GO

/*Section="End"*/
