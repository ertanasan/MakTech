﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [FIN_RENTPAYMENTPLAN]
(
    /*Section="Columns"*/
    [RENTPAYMENTPLANID]      INT NOT NULL IDENTITY,
    [ORGANIZATION]           INT NOT NULL,
    [DELETED_FL]             VARCHAR NOT NULL,
    [CREATE_DT]              DATETIME NOT NULL,
    [UPDATE_DT]              DATETIME NULL,
    [CREATEUSER]             INT NOT NULL,
    [UPDATEUSER]             INT NULL,
    [ESTATERENTPERIOD]       INT NOT NULL,
    [PAYMENTORDER_NO]        INT NOT NULL,
    [DUE_DT]                 DATETIME NOT NULL,
    [PAYMENT_AMT]            NUMERIC(22,6) NOT NULL,
    [CURRENCY_TXT]           VARCHAR(3) NOT NULL,
    [ADDITIONALPAYMENT_AMT]  NUMERIC(22,6) NULL,
    [ADDPAYMENTCURRENCY_TXT] VARCHAR(3) NULL,
    [COMMENT_DSC]            VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [FIN_RENTPAYMENTPLAN_PK] PRIMARY KEY ([RENTPAYMENTPLANID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [FIN_RENTPAYMENTPLAN_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [FIN_RENTPAYMENTPLAN_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [FIN_RENTPAYMENTPLAN_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [FIN_RENTPAYMENTPLAN_F04] FOREIGN KEY ([ESTATERENTPERIOD]) REFERENCES [FIN_ESTATERENTPERIOD]([ESTATERENTPERIODID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [FIN_RENTPAYMENTPLAN_X01] ON [FIN_RENTPAYMENTPLAN] ([ESTATERENTPERIOD])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Rent Payment Plan: Rent Payment Plan',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FIN_RENTPAYMENTPLAN',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Rent Payment Plan Id: Identity column for FIN_RENTPAYMENTPLAN' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'RENTPAYMENTPLANID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Rent Period: Estate Rent Period  FK from FIN_ESTATERENTPERIOD' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'ESTATERENTPERIOD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Payment Order: Payment Order of the Rental Agreement Period' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'PAYMENTORDER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Due Date: Payment Due Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'DUE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Payment Amount: Payment Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'PAYMENT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Currency: Currency type of the payment' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'CURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Payment Amount: Additional Payment Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'ADDITIONALPAYMENT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Payment Currency: currency of additional payment' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'ADDPAYMENTCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for rent payment plan.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLAN',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/
