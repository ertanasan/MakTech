﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_CASHIER]
(
    /*Section="Columns"*/
    [CASHIERID]       INT NOT NULL,
    [ORGANIZATION]    INT NOT NULL,
    [DELETED_FL]      VARCHAR(1) NOT NULL,
    [CREATE_DT]       DATETIME NOT NULL,
    [UPDATE_DT]       DATETIME NULL,
    [CREATEUSER]      INT NOT NULL,
    [UPDATEUSER]      INT NULL,
    [STORE]           INT NOT NULL,
    [CASHIER_NM]      VARCHAR(30) NOT NULL,
    [CASHIERTEMPLATE] INT NOT NULL,
    [CASHIERTITLE]    INT NOT NULL,
    [PASSWORD_NO]     INT NOT NULL,
    [ISCASHIER_FL]    VARCHAR(1) NOT NULL,
    [ISACTIVE_FL]     VARCHAR(1) NOT NULL,
    [ISSALESMAN_FL]   VARCHAR(1) NOT NULL,
    [WORKINGTYPE_CD]  VARCHAR(1) NULL,
    [NOTE_TXT]        VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_CASHIER_PK] PRIMARY KEY ([CASHIERID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [STR_CASHIER_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [STR_CASHIER_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_CASHIER_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_CASHIER_F04] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [STR_CASHIER_F05] FOREIGN KEY ([CASHIERTEMPLATE]) REFERENCES [STR_CASHIERTEMPLATE]([CASHIERTEMPLATEID]),
    CONSTRAINT [STR_CASHIER_F06] FOREIGN KEY ([CASHIERTITLE]) REFERENCES [SEC_TITLE]([TITLEID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [STR_CASHIER_X01] ON [STR_CASHIER] ([STORE])
GO

CREATE INDEX [STR_CASHIER_X02] ON [STR_CASHIER] ([CASHIERTITLE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cashier: Kasiyer',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_CASHIER',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier  Id: Unique identifier for {table}.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'CASHIERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Mağaza No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Name: Name of cashier .' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'CASHIER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Template Number: Cashier Template Number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'CASHIERTEMPLATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Title Number: Cashier title number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'CASHIERTITLE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Password: Password' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'PASSWORD_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier  Flag: Is Working On Cash Register' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'ISCASHIER_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Is Active: States that cashier is an active worker.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'ISACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Salesman: Is Salesman' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'ISSALESMAN_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Working Type: Working Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'WORKINGTYPE_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Note: Note' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIER',
    @level2type=N'COLUMN',
    @level2name=N'NOTE_TXT'
GO

/*Section="End"*/
