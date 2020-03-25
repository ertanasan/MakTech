﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_INVOICE]
(
    /*Section="Columns"*/
    [INVOICEID]           BIGINT NOT NULL IDENTITY,
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
    [EINVOICE_FL]         VARCHAR(1) NOT NULL,
    [CUSTOMERID_LNO]      INT NOT NULL,
    [TITLE_DSC]           VARCHAR(1000) NOT NULL,
    [EMAIL_TXT]           VARCHAR(200) NOT NULL,
    [SALE]                BIGINT NOT NULL,
    [EINVOICECLIENT]      INT NULL,
    [ADDRESS_TXT]         VARCHAR(1000) NULL,
    [STATUS_CD]           INT NOT NULL,
    [MIKRO_FL]            VARCHAR(1) NOT NULL,
    [MIKRO_TM]            DATETIME NULL,
    [PROCESSINSTANCE_LNO] BIGINT NULL,
    [PHONENUMBER_TXT] VARCHAR(50) NULL, 
    /*Section="PrimaryKey"*/
    CONSTRAINT [ACC_INVOICE_PK] PRIMARY KEY ([INVOICEID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [ACC_INVOICE_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [ACC_INVOICE_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [ACC_INVOICE_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ACC_INVOICE_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ACC_INVOICE_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [ACC_INVOICE_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [ACC_INVOICE_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [ACC_INVOICE_F08] FOREIGN KEY ([SALE]) REFERENCES [SLS_SALE]([SALEID]),
    CONSTRAINT [ACC_INVOICE_F09] FOREIGN KEY ([EINVOICECLIENT]) REFERENCES [ACC_EINVOICECLIENT]([EINVOICECLIENTID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [ACC_INVOICE_X01] ON [ACC_INVOICE] ([SALE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Sale Invoice: Sale Invoice',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_INVOICE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale Invoice Id: Identity column for ACC_INVOICE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'INVOICEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'EInvoice Flag: EInvoice Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'EINVOICE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Customer Id Number: Customer Id Number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'CUSTOMERID_LNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Title: Title' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'TITLE_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Email: Email' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'EMAIL_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sale: Sale' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'SALE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'EInvoice Client: EInvoice Client' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'EINVOICECLIENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Address: Address' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'ADDRESS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status Code: Status Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'STATUS_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Flag: Mikro Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'MIKRO_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Mikro Transfer Time: Mikro Transfer Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'MIKRO_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process Instance: Process Instance' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_INVOICE',
    @level2type=N'COLUMN',
    @level2name=N'PROCESSINSTANCE_LNO'
GO

/*Section="End"*/