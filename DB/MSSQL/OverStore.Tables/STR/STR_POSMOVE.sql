﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_POSMOVE]
(
    /*Section="Columns"*/
    [POSMOVEID]    INT NOT NULL IDENTITY,
    [POSID]        INT NOT NULL,
    [ORGANIZATION] INT NOT NULL,
    [DELETED_FL]   VARCHAR NOT NULL,
    [MOVE_TM]      DATETIME NOT NULL,
    [STORE]        INT NOT NULL,
    [CREATE_DT]    DATETIME NOT NULL,
    [UPDATE_DT]    DATETIME NULL,
    [CREATEUSER]   INT NOT NULL,
    [UPDATEUSER]   INT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_POSMOVE_PK] PRIMARY KEY ([POSMOVEID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [STR_POSMOVE_F01] FOREIGN KEY ([POSID]) REFERENCES [STR_POS]([POSID]),
    CONSTRAINT [STR_POSMOVE_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [STR_POSMOVE_F03] FOREIGN KEY ([STORE]) REFERENCES [STR_STORE]([STOREID]),
    CONSTRAINT [STR_POSMOVE_F04] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [STR_POSMOVE_F05] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]) 
);
GO

/*Section="Indexes"*/

CREATE INDEX [STR_POSMOVE_X01] ON [STR_POSMOVE] ([POSID])
GO

CREATE INDEX [STR_POSMOVE_X02] ON [STR_POSMOVE] ([STORE])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Pos Movement: Pos Movements between stores',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_POSMOVE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Pos Movement Id: Identity column for STR_POSMOVE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'POSMOVEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Pos Id: POS ID' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'POSID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Move Time: Move Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'MOVE_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store: Store' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'STORE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_POSMOVE', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

/*Section="End"*/