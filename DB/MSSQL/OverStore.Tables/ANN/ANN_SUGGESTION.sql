﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [ANN_SUGGESTION]
(
    /*Section="Columns"*/
    [SUGGESTIONID]        BIGINT NOT NULL IDENTITY,
    [EVENT]               INT NOT NULL,
    [ORGANIZATION]        INT NOT NULL,
    [DELETED_FL]          VARCHAR NOT NULL,
    [CREATE_DT]           DATETIME NOT NULL,
    [UPDATE_DT]           DATETIME NULL,
    [CREATEUSER]          INT NOT NULL,
    [UPDATEUSER]          INT NULL,
    [CREATECHANNEL]       INT NOT NULL,
    [CREATEBRANCH]        INT NOT NULL,
    [CREATESCREEN]        INT NOT NULL,
    [SUGGESTION_TXT]      VARCHAR(2000) NOT NULL,
    [PROCESSINSTANCE_LNO] BIGINT NULL,
    [STATUS]              INT NOT NULL,
    [TYPE]                INT NULL,
    [INNOVATIVENESS_RT]   NUMERIC(4,2) NULL,
    [FEASIBILITY_RT]      NUMERIC(4,2) NULL,
    [ADDEDVALUE_RT]       NUMERIC(4,2) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [ANN_SUGGESTION_PK] PRIMARY KEY ([SUGGESTIONID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [ANN_SUGGESTION_F01] FOREIGN KEY ([EVENT]) REFERENCES [PRM_EVENT]([EVENTID]),
    CONSTRAINT [ANN_SUGGESTION_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [ANN_SUGGESTION_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ANN_SUGGESTION_F04] FOREIGN KEY ([UPDATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [ANN_SUGGESTION_F05] FOREIGN KEY ([CREATECHANNEL]) REFERENCES [SYS_CHANNEL]([CHANNELID]),
    CONSTRAINT [ANN_SUGGESTION_F06] FOREIGN KEY ([CREATEBRANCH]) REFERENCES [ORG_BRANCH]([BRANCHID]),
    CONSTRAINT [ANN_SUGGESTION_F07] FOREIGN KEY ([CREATESCREEN]) REFERENCES [PRG_SCREEN]([SCREENID]),
    CONSTRAINT [ANN_SUGGESTION_F08] FOREIGN KEY ([STATUS]) REFERENCES [ANN_SUGGESTIONSTATUS]([SUGGESTIONSTATUSID]),
    CONSTRAINT [ANN_SUGGESTION_F09] FOREIGN KEY ([TYPE]) REFERENCES [ANN_SUGGESTIONTYPE]([SUGGESTIONTYPEID])
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Suggestion: Staff suggestions',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ANN_SUGGESTION',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Suggestion Id: Identity column for ANN_SUGGESTION' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'SUGGESTIONID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Event: Event for the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'EVENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Deleted: Deletion flag.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'DELETED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update Date: Record update date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'UPDATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Update User: Updater user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'UPDATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Channel: Creation channel of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'CREATECHANNEL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Branch: Creator branch of the transaction.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'CREATEBRANCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Screen: Screen id of the transaction performed.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'CREATESCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Suggestion Text: Suggestion text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'SUGGESTION_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Process Instance: Process Instace ID from BPM_PROCESSINSTANCE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'PROCESSINSTANCE_LNO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Status: Status id from ANN_SUGGESTIONSTATUS' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'STATUS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Type: Suggestion Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'TYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Innovativeness Rating: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'INNOVATIVENESS_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Feasibility Rating: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'FEASIBILITY_RT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Added Value Rating: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ANN_SUGGESTION',
    @level2type=N'COLUMN',
    @level2name=N'ADDEDVALUE_RT'
GO

/*Section="End"*/
