﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [ANN_NOTIFICATIONGROUP]
(
    /*Section="Columns"*/
    [NOTIFICATIONGROUPID] INT NOT NULL IDENTITY,
    [ORGANIZATION]        INT NOT NULL,
    [DELETED_FL]          VARCHAR NOT NULL,
    [CREATE_DT]           DATETIME NOT NULL,
    [UPDATE_DT]           DATETIME NULL,
    [CREATEUSER]          INT NOT NULL,
    [UPDATEUSER]          INT NULL,
    [GROUP_NM]            VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [ANN_NOTIFICATIONGROUP_PK] PRIMARY KEY ([NOTIFICATIONGROUPID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [ANN_NOTIFICATIONGROUP_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [ANN_NOTIFICATIONGROUP_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ANN_NOTIFICATIONGROUP_F03] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]) 
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [ANN_NOTIFICATIONGROUP_X01] ON [ANN_NOTIFICATIONGROUP] ([GROUP_NM], [ORGANIZATION])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Notification Group: user groups for notification',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ANN_NOTIFICATIONGROUP',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Notification Group Id: Identity column for ANN_NOTIFICATIONGROUP' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'NOTIFICATIONGROUPID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Group Name: Name of notification group.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ANN_NOTIFICATIONGROUP', 
    @level2type=N'COLUMN',
    @level2name=N'GROUP_NM'
GO

/*Section="End"*/
