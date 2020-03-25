-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [HDK_ATTRIBUTECHOICELOG]
(
    /*Section="Columns"*/
    [ATTRIBUTECHOICEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [ATTRIBUTE] INT NOT NULL,
    [CHOICE_NM] VARCHAR(100) NOT NULL,
    [DISPLAYORDER_NO] INT NULL,
    [PRIORITYPOINT_NO] INT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Attribute Choice Log: Attribute Choice, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'HDK_ATTRIBUTECHOICELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Attribute Choice Id: Identity column for HDK_ATTRIBUTECHOICE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'ATTRIBUTECHOICEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Attribute: Attribute' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'ATTRIBUTE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Choice Name: Name of attribute choice.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'CHOICE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Display Order: Display Order' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'DISPLAYORDER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Priority Point: Priority Point' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIORITYPOINT_NO'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTECHOICELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
