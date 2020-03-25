﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [OSM_DOCUMENTDOWNLOADLOG]
(
    /*Section="Columns"*/
    [DOCUMENTDOWNLOADLOGID] BIGINT NOT NULL IDENTITY,
    [ORGANIZATION]          INT NOT NULL,
    [CREATE_DT]             DATETIME NOT NULL,
    [CREATEUSER]            INT NOT NULL,
    [CREATECHANNEL]         INT NOT NULL,
    [CREATEBRANCH]          INT NOT NULL,
    [CREATESCREEN]          INT NOT NULL,
    [DOCUMENT]              BIGINT NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_PK] PRIMARY KEY ([DOCUMENTDOWNLOADLOGID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_F01] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_F02] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_F03] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_F04] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_F05] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [OSM_DOCUMENTDOWNLOADLOG_F06] FOREIGN KEY ([DOCUMENT]) REFERENCES [DOC_DOCUMENT]([DOCUMENTID]) 
);
GO

/*Section="Indexes"*/

CREATE INDEX [OSM_DOCUMENTDOWNLOADLOG_X01] ON [OSM_DOCUMENTDOWNLOADLOG] ([DOCUMENT])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Document Download Log: Log for document download operations',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'OSM_DOCUMENTDOWNLOADLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Document Download Log Id: Identity column for OSM_DOCUMENTDOWNLOADLOG' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'DOCUMENTDOWNLOADLOGID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Document: downloaded document id from DOC_DOCUMENT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_DOCUMENTDOWNLOADLOG', 
    @level2type=N'COLUMN',
    @level2name=N'DOCUMENT'
GO

/*Section="End"*/