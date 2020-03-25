-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [HDK_ATTRIBUTELOG]
(
    /*Section="Columns"*/
    [ATTRIBUTEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [ATTRIBUTE_NM] VARCHAR(100) NOT NULL,
    [REQUESTGROUP] INT NULL,
    [REQUESTDEFINITION] INT NULL,
    [ATTRIBUTETYPE] INT NOT NULL,
    [EDITABLE_FL] VARCHAR(1) NULL,
    [REQUIRED_FL] VARCHAR(1) NULL,
    [DISPLAYORDER_NO] INT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Request Attribute Log: Talep girişi sırasında talebe bağlı alınacak bilgiler - özellikler, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'HDK_ATTRIBUTELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Attribute Id: Identity column for HDK_ATTRIBUTE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'ATTRIBUTEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Attribute Name: Name of request attribute.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'ATTRIBUTE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Group: Request Group' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTGROUP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Request Definition: Request Definition' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUESTDEFINITION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Attribute Type: Attribute Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'ATTRIBUTETYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Editable Flag: Allow edit in approve' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'EDITABLE_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Required Flag: Required Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'REQUIRED_FL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Display Order: Display Order' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'DISPLAYORDER_NO'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'HDK_ATTRIBUTELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
