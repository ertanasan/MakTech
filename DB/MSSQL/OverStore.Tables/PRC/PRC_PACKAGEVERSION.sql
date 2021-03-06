﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRC_PACKAGEVERSION]
(
    /*Section="Columns"*/
    [PACKAGEVERSIONID] INT NOT NULL IDENTITY,
    [ORGANIZATION]     INT NOT NULL,
    [DELETED_FL]       VARCHAR NOT NULL,
    [CREATE_DT]        DATETIME NOT NULL,
    [UPDATE_DT]        DATETIME NULL,
    [CREATEUSER]       INT NOT NULL,
    [UPDATEUSER]       INT NULL,
    [PACKAGE]          INT NOT NULL,
    [VERSION_DT]       DATETIME NOT NULL,
    [ACTIVE_FL]        VARCHAR(1) NOT NULL,
    [COMMENT_DSC]      VARCHAR(1000) NULL,
    [ACTIVATION_TM]    DATETIME NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRC_PACKAGEVERSION_PK] PRIMARY KEY ([PACKAGEVERSIONID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [PRC_PACKAGEVERSION_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [PRC_PACKAGEVERSION_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRC_PACKAGEVERSION_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRC_PACKAGEVERSION_F04] FOREIGN KEY ([PACKAGE]) REFERENCES [PRC_PACKAGE]([PACKAGEID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [PRC_PACKAGEVERSION_X01] ON [PRC_PACKAGEVERSION] ([PACKAGE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Package Version: Package Version',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRC_PACKAGEVERSION',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package Version Id: Identity column for PRC_PACKAGEVERSION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'PACKAGEVERSIONID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package: Package' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'PACKAGE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Version Date: Version Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'VERSION_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Active Flag: Active Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'ACTIVE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for package version.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Activation Time: Activation Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGEVERSION',
    @level2type=N'COLUMN',
    @level2name=N'ACTIVATION_TM'
GO

/*Section="End"*/
