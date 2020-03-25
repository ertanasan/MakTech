-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_EXCELFILECOLUMNSLOG]
(
    /*Section="Columns"*/
    [EXCELFILECOLUMNSID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [EXCELFILE] INT NOT NULL,
    [COLUMN_NM] VARCHAR(100) NOT NULL,
    [COLUMNINDEX_NO] INT NOT NULL,
    [COLUMNTYPE_CD] INT NOT NULL,
    [FORMAT_TXT] VARCHAR(50) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Excel File Columns Log: Excel File Columns, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_EXCELFILECOLUMNSLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Excel File Columns Id: Identity column for ACC_EXCELFILECOLUMNS' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'EXCELFILECOLUMNSID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Excel File: Excel File' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'EXCELFILE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Column Name: Name of excel file columns.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'COLUMN_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Column Index: Column Index' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'COLUMNINDEX_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Column Type: Column Type 1: Text 2: Decimal 3: Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'COLUMNTYPE_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Column Format: Column Format, such as date format dd.MM.yyyy or dd/MM/yyyy or decimal format #.#' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'FORMAT_TXT'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILECOLUMNSLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
