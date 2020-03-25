-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [GAM_CHOICELOG]
(
    /*Section="Columns"*/
    [CHOICEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [QUESTION] INT NOT NULL,
    [CHOICE_TXT] VARCHAR(1000) NOT NULL,
    [RIGHTANSWER_FL] VARCHAR(1) NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Question Choice Log: Question Choices, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'GAM_CHOICELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Question Choice Id: Identity column for GAM_CHOICE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'CHOICEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Question: Question' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'QUESTION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Choice Text: Choice Text' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'CHOICE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Right Answer: Right Answer' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'RIGHTANSWER_FL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'GAM_CHOICELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
