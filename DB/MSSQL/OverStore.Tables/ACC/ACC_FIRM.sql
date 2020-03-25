﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_FIRM]
(
    /*Section="Columns"*/
    [FIRMID]       INT NOT NULL IDENTITY,
    [ORGANIZATION] INT NOT NULL,
    [DELETED_FL]   VARCHAR NOT NULL,
    [CREATE_DT]    DATETIME NOT NULL,
    [UPDATE_DT]    DATETIME NULL,
    [CREATEUSER]   INT NOT NULL,
    [UPDATEUSER]   INT NULL,
    [FIRM_NM]      VARCHAR(100) NOT NULL,
    [FIRMTYPE]     INT NOT NULL,
    [COMMENT_DSC]  VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [ACC_FIRM_PK] PRIMARY KEY ([FIRMID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [ACC_FIRM_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [ACC_FIRM_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ACC_FIRM_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ACC_FIRM_F04] FOREIGN KEY ([FIRMTYPE]) REFERENCES [ACC_FIRMTYPE]([FIRMTYPEID]) 
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [ACC_FIRM_X01] ON [ACC_FIRM] ([FIRM_NM], [ORGANIZATION])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Firm: Firms which have business relations with main company, e.g. suppliers, technical partners',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_FIRM',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Firm Id: Identity column for ACC_FIRM' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'FIRMID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Name: Name of firm.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'FIRM_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Firm Type: FK from ACC_FIRMTYPE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'FIRMTYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for firm.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_FIRM', 
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/
