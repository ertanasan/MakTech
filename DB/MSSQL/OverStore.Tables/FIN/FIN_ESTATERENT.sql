﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [FIN_ESTATERENT]
(
    /*Section="Columns"*/
    [ESTATERENTID]                  INT NOT NULL IDENTITY,
    [ORGANIZATION]                  INT NOT NULL,
    [DELETED_FL]                    VARCHAR NOT NULL,
    [CREATE_DT]                     DATETIME NOT NULL,
    [UPDATE_DT]                     DATETIME NULL,
    [CREATEUSER]                    INT NOT NULL,
    [UPDATEUSER]                    INT NULL,
    [CONTRACTDRAFTVERSION]          INT NULL,
    [CONTRACTFOLDER]                BIGINT NULL,
    [ESTATE_ADR]                    VARCHAR(1000) NULL,
    [RENTPURPOSE_TXT]               VARCHAR(1000) NULL,
    [START_DT]                      DATETIME NOT NULL,
    [END_DT]                        DATETIME NOT NULL,
    [ESTATE_NM]                     VARCHAR(100) NULL,
    [COMMENT_DSC]                   VARCHAR(1000) NULL,
    [BRANCH]                        INT NULL,
    [DEPOSIT_AMT]                   NUMERIC(22,6) NULL,
    [DEPOSITCURRENCY_TXT]           VARCHAR(3) NULL,
    [DEPOSITDETAIL_TXT]             VARCHAR(1000) NULL,
    [ADDDEPOSIT_AMT]                NUMERIC(22,6) NULL,
    [ADDDEPOSITCURRENCY_TXT]        VARCHAR(3) NULL,
    [AGENTFEE_AMT]                  NUMERIC(22,6) NULL,
    [AGENTFEECURRENCY_TXT]          VARCHAR(3) NULL,
    [AGENTFEEDETAIL_TXT]            VARCHAR(1000) NULL,
    [KEYMONEY_AMT]                  NUMERIC(22,6) NULL,
    [KEYMONEYCURRENCY_TXT]          VARCHAR(3) NOT NULL,
    [KEYMONEYDETAIL_TXT]            VARCHAR(1000) NULL,
    [NONREFUNDABLECOST_AMT]         NUMERIC(22,6) NULL,
    [NONREFUNDABLECOSTCURRENCY_TXT] VARCHAR(3) NULL,
    [NONREFUNDABLECOSTDETAIL_TXT]   VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [FIN_ESTATERENT_PK] PRIMARY KEY ([ESTATERENTID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [FIN_ESTATERENT_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [FIN_ESTATERENT_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [FIN_ESTATERENT_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [FIN_ESTATERENT_F04] FOREIGN KEY ([CONTRACTDRAFTVERSION]) REFERENCES [FIN_CONTRACTDRAFTVERSION]([CONTRACTDRAFTVERSIONID]),
    CONSTRAINT [FIN_ESTATERENT_F05] FOREIGN KEY ([CONTRACTFOLDER]) REFERENCES [DOC_FOLDER]([FOLDERID]),
    CONSTRAINT [FIN_ESTATERENT_F06] FOREIGN KEY ([BRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [FIN_ESTATERENT_X01] ON [FIN_ESTATERENT] ([CONTRACTDRAFTVERSION])
GO

CREATE INDEX [FIN_ESTATERENT_X02] ON [FIN_ESTATERENT] ([BRANCH])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Estate Rent: Store, WArehouse Rental Operations & Agreements',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FIN_ESTATERENT',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Estate Rent Id: Unique identifier for FIN_ESTATERENT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'ESTATERENTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contract Draft Version: userd contract draft from FIN_CONTRACTDRAFTVERSION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'CONTRACTDRAFTVERSION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contract Folder: folder id from DOC_FOLDER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'CONTRACTFOLDER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Estate Address: Estate Address' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'ESTATE_ADR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Rent Purpose: Rent Purpose' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'RENTPURPOSE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contract Start Date: Contract Start Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'START_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contract End Date: Contract End Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'END_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Estate Name: Name of estate rent.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'ESTATE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for estate rent.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Branch: relevant branch for the real estate' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'BRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deposit: Deposit for the estate' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'DEPOSIT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deposit Currency: Deposit currency' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'DEPOSITCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deposit Details: detail info for the deposit' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'DEPOSITDETAIL_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Deposit: Additional Deposit' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'ADDDEPOSIT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Deposit Currency: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'ADDDEPOSITCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Agent Fee: paid agent fee for the estate rent' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'AGENTFEE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Agent Fee Currency: currency of agent fee' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'AGENTFEECURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Agent Fee Detail: Explanations about agent fee' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'AGENTFEEDETAIL_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Key Money: amount paid to the previous hirer of the estate ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'KEYMONEY_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Key Money Currency: currency of key money' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'KEYMONEYCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Key Money Detail: explanations of key money payment' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'KEYMONEYDETAIL_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Nonrefundable Cost: nonrefundable payments for the rent other than rent itself, deposit, agent fee or key money.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'NONREFUNDABLECOST_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Nonrefundable Currency: currency for Nonrefundable payments' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'NONREFUNDABLECOSTCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Nonrefundable Cost Detail: explanations of the Nonrefundable  costs' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENT',
    @level2type=N'COLUMN',
    @level2name=N'NONREFUNDABLECOSTDETAIL_TXT'
GO

/*Section="End"*/
