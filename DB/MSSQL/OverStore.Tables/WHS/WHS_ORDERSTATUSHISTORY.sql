﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_ORDERSTATUSHISTORY]
(
    /*Section="Columns"*/
    [ORDERSTATUSHISTORYID] BIGINT NOT NULL IDENTITY,
    [EVENT]                INT NOT NULL,
    [ORGANIZATION]         INT NOT NULL,
    [DELETED_FL]           VARCHAR NOT NULL,
    [CREATE_DT]            DATETIME NOT NULL,
    [UPDATE_DT]            DATETIME NULL,
    [CREATEUSER]           INT NOT NULL,
    [UPDATEUSER]           INT NULL,
    [CREATECHANNEL]        INT NOT NULL,
    [CREATEBRANCH]         INT NOT NULL,
    [CREATESCREEN]         INT NOT NULL,
    [RETURNORDER]          BIGINT NOT NULL,
    [STATUS]               INT NOT NULL,
    [OPERATION_CD]         INT NOT NULL,
    [COMMENT_TXT]          VARCHAR(1000) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_PK] PRIMARY KEY ([ORDERSTATUSHISTORYID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F08] FOREIGN KEY ([RETURNORDER]) REFERENCES [WHS_RETURNORDER]([RETURNORDERID]),
    CONSTRAINT [WHS_ORDERSTATUSHISTORY_F09] FOREIGN KEY ([STATUS]) REFERENCES [WHS_RETURNSTATUS]([RETURNSTATUSID]) 
);
GO

/*Section="Indexes"*/

CREATE INDEX [WHS_ORDERSTATUSHISTORY_X01] ON [WHS_ORDERSTATUSHISTORY] ([RETURNORDER])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Order Status History: Order Status History',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_ORDERSTATUSHISTORY',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Order Status History Id: Identity column for WHS_ORDERSTATUSHISTORY' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'ORDERSTATUSHISTORYID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Return Order: Return Order' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'RETURNORDER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status: Status' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'STATUS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Operation Code: Operation Code (1:Approved 2:Rejected)' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'OPERATION_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_ORDERSTATUSHISTORY', 
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_TXT'
GO

/*Section="End"*/