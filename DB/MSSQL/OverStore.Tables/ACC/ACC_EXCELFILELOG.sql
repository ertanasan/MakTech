-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [ACC_EXCELFILELOG]
(
    /*Section="Columns"*/
    [EXCELFILEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [TRANSFER_NM] VARCHAR(100) NOT NULL,
    [SHEET_NO] INT NOT NULL,
    [ROWSTART_NO] INT NOT NULL,
    [COLUMNSTART_NO] INT NOT NULL,
    [NUMBEROFCOLUMNS_QTY] INT NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Excel File Log: Excel File Template Info, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ACC_EXCELFILELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Excel File Id: Identity column for ACC_EXCELFILE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'EXCELFILEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Transfer Name: Name of excel file.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'TRANSFER_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Sheet No: Sheet No' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'SHEET_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Row Start No: Row Start No, First Row : 1' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'ROWSTART_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Column Start No: Column Start No First Column : 1' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'COLUMNSTART_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Number Of Columns: Number Of Columns' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'NUMBEROFCOLUMNS_QTY'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'ACC_EXCELFILELOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
