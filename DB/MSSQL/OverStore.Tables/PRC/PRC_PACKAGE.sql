﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRC_PACKAGE]
(
    /*Section="Columns"*/
    [PACKAGEID]    INT NOT NULL IDENTITY,
    [ORGANIZATION] INT NOT NULL,
    [DELETED_FL]   VARCHAR NOT NULL,
    [CREATE_DT]    DATETIME NOT NULL,
    [UPDATE_DT]    DATETIME NULL,
    [CREATEUSER]   INT NOT NULL,
    [UPDATEUSER]   INT NULL,
    [PACKAGE_NM]   VARCHAR(100) NOT NULL,
    [TYPE]         INT NOT NULL,
    [COMMENT_DSC]  VARCHAR(1000) NULL,
    [IMAGE]        BIGINT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRC_PACKAGE_PK] PRIMARY KEY ([PACKAGEID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [PRC_PACKAGE_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [PRC_PACKAGE_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRC_PACKAGE_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [PRC_PACKAGE_F04] FOREIGN KEY ([TYPE]) REFERENCES [PRC_PACKAGETYPE]([PACKAGETYPEID]),
    CONSTRAINT [PRC_PACKAGE_F05] FOREIGN KEY ([IMAGE]) REFERENCES [DOC_DOCUMENT]([DOCUMENTID])
);
GO

/*Section="Indexes"*/

CREATE INDEX [PRC_PACKAGE_X01] ON [PRC_PACKAGE] ([IMAGE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Price Package: Price Package',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRC_PACKAGE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package Id: Identity column for PRC_PACKAGE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'PACKAGEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package Name: Name of package.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'PACKAGE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Package Type: Package Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'TYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for price package.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Image: Document Id of the Price Label Image for the Package.  ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'PRC_PACKAGE',
    @level2type=N'COLUMN',
    @level2name=N'IMAGE'
GO

/*Section="End"*/