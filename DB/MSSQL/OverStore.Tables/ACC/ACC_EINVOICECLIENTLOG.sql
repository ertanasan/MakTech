-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_EINVOICECLIENTLOG]
(
    /*Section="Columns"*/
    [EINVOICECLIENTID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [IDENTIFIER_NO] BIGINT NOT NULL,
    [ALIAS_DSC] VARCHAR(200) NOT NULL,
    [TITLE_DSC] VARCHAR(1000) NOT NULL,
    [TYPE_NM] VARCHAR(50) NOT NULL,
    [FIRSTCREATE_TM] DATETIME NULL,
    [ALIASCREATE_TM] DATETIME NULL,
    [EMAIL_TXT] VARCHAR(200) NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'EInvoice Client Log: EInvoice Client, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_EINVOICECLIENTLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'EInvoice Client Id: Identity column for ACC_EINVOICECLIENT' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'EINVOICECLIENTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Identifier: Identifier' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'IDENTIFIER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Alias: Alias' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'ALIAS_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Title: Title' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'TITLE_DSC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Type: Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'TYPE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'First Create Time: First Create Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'FIRSTCREATE_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Alias Create Time: Alias Create Time' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'ALIASCREATE_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Email: Email' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'EMAIL_TXT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EINVOICECLIENTLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
