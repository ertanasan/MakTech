﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_STORE]
(
    /*Section="Columns"*/
    [STOREID]           INT NOT NULL,
    [ORGANIZATION]      INT NOT NULL,
    [DELETED_FL]        VARCHAR NOT NULL,
    [CREATE_DT]         DATETIME NOT NULL,
    [UPDATE_DT]         DATETIME NULL,
    [CREATEUSER]        INT NOT NULL,
    [UPDATEUSER]        INT NULL,
    [STORE_NM]          VARCHAR(100) NOT NULL,
    [BRANCH]            INT NOT NULL,
    [IPADDRESS_TXT]     VARCHAR(1000) NOT NULL,
    [ADVANCE_AMT]       NUMERIC(22,6) NOT NULL,
    [OPENING_DT]        DATETIME NULL,
    [CLOSING_DT]        DATETIME NULL,
    [ACTIVE_FL]         VARCHAR(1) NULL,
    [PRODUCTION_FL]     VARCHAR(1) NULL,
    [CITY]              INT NULL,
    [TOWN]              INT NULL,
    [ADDRESS_TXT]       VARCHAR(1000) NULL,
    [REGIONMANAGER]     INT NULL,
    [INCONSTRUCTION_FL] VARCHAR(1) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_STORE_PK] PRIMARY KEY ([STOREID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [STR_STORE_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [STR_STORE_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_STORE_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_STORE_F04] FOREIGN KEY ([BRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [STR_STORE_F05] FOREIGN KEY ([CITY]) REFERENCES [STR_CITY]([CITYID]),
    CONSTRAINT [STR_STORE_F06] FOREIGN KEY ([TOWN]) REFERENCES [STR_TOWN]([TOWNID]),
    CONSTRAINT [STR_STORE_F07] FOREIGN KEY ([REGIONMANAGER]) REFERENCES [STR_REGIONMANAGERS]([REGIONMANAGERSID])
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [STR_STORE_X01] ON [STR_STORE] ([STORE_NM], [ORGANIZATION])
GO

CREATE INDEX [STR_STORE_X02] ON [STR_STORE] ([BRANCH])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Store: Store definitions.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_STORE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Id: Identity column for STR_STORE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'STOREID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Name: Name of store.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'STORE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization Branch: Organization Branch' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'BRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Ip Address: Store Ip Addresses' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'IPADDRESS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Advance: Günlük avans miktarı' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'ADVANCE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Opening Date: Opening Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'OPENING_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Closing Date: Closing Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'CLOSING_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Active Flag: Active Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'ACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Production Flag: Production Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'PRODUCTION_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'City: City' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'CITY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Town: Town' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'TOWN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Address: Address' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'ADDRESS_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Region Manager: Region Manager' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'REGIONMANAGER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'InConstruction: Whether the Store is in construction or not' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_STORE',
    @level2type=N'COLUMN',
    @level2name=N'INCONSTRUCTION_FL'
GO

/*Section="End"*/