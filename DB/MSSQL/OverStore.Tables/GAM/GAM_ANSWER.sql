﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_ANSWER]
(
    /*Section="Columns"*/
    [ANSWERID]      BIGINT NOT NULL IDENTITY,
    [ORGANIZATION]  INT NOT NULL,
    [CREATE_DT]     DATETIME NOT NULL,
    [CREATEUSER]    INT NOT NULL,
    [PLAY]          BIGINT NOT NULL,
    [QUESTION]      INT NOT NULL,
    [ANSWERCHOICE]  INT NOT NULL,
    [RESULT_FL]     VARCHAR(1) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [GAM_ANSWER_PK] PRIMARY KEY ([ANSWERID]),
    /*Section="ForeignKeys"*/
    CONSTRAINT [GAM_ANSWER_F02] FOREIGN KEY ([ORGANIZATION]) REFERENCES [ORG_ORGANIZATION]([ORGANIZATIONID]),
    CONSTRAINT [GAM_ANSWER_F03] FOREIGN KEY ([CREATEUSER]) REFERENCES [SEC_USER]([USERID]),
    CONSTRAINT [GAM_ANSWER_F04] FOREIGN KEY ([PLAY]) REFERENCES [GAM_PLAY]([PLAYID]),
    CONSTRAINT [GAM_ANSWER_F07] FOREIGN KEY ([QUESTION]) REFERENCES [GAM_QUESTION]([QUESTIONID]),
    CONSTRAINT [GAM_ANSWER_F08] FOREIGN KEY ([ANSWERCHOICE]) REFERENCES [GAM_CHOICE]([CHOICEID]),
);
GO

/*Section="Indexes"*/

CREATE INDEX [GAM_ANSWER_X01] ON [GAM_ANSWER] ([PLAY])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Game Play Answer: Game Play Answer',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_ANSWER',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Game Play Answer Id: Identity column for GAM_ANSWER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'ANSWERID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Organization: Organization of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'ORGANIZATION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create Date: Record insert date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'CREATE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Create User: Creator user id of the record.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'CREATEUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Play: Play' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'PLAY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Question: Game Play Answer' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'QUESTION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Answer Choice: Answer Choice' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'ANSWERCHOICE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Result Flag: Result Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_ANSWER', 
    @level2type=N'COLUMN',
    @level2name=N'RESULT_FL'
GO

/*Section="End"*/
