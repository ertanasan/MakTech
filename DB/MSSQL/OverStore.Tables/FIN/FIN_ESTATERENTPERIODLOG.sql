-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [FIN_ESTATERENTPERIODLOG]
(
    /*Section="Columns"*/
    [ESTATERENTPERIODID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [ESTATERENT] INT NOT NULL,
    [PERIODORDER_NO] INT NOT NULL,
    [START_DT] DATETIME NOT NULL,
    [END_DT] DATETIME NOT NULL,
    [CONTRACTRENT_AMT] NUMERIC(22,6) NULL,
    [CONTRACTRENTCURRENCY_TXT] VARCHAR(3) NULL,
    [ADDITIONALRENT_AMT] NUMERIC(22,6) NULL,
    [ADDRENTCURRENCY_TXT] VARCHAR(3) NULL,
    [PLANNEDRENTRAISE_TXT] VARCHAR(1000) NULL,
    [NEGOTIATION_DT] DATETIME NULL,
    [COMMENT_DSC] VARCHAR(1000) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Estate Rent Period Log: periods (years) of the rental agreement, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FIN_ESTATERENTPERIODLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Estate Rent Period Id: Identity column for FIN_ESTATERENTPERIOD' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'ESTATERENTPERIODID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Estate Rent: Master column (FIN_ESTATERENT)' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'ESTATERENT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Period Order: Order of the period for the rental agreement' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'PERIODORDER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Period Start Date: Period Start Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'START_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Period End Date: Period End Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'END_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contract Rent Amount: Rent Amount for the period (written on the contract)' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'CONTRACTRENT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contract Rent Currency: Currency of contract rent' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'CONTRACTRENTCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Rent Amount: Additional rent amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'ADDITIONALRENT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Rent Currency: currency for additional rent ' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'ADDRENTCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Planned Rent Raise: Rent raise conditions determined at the beginning of the period' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'PLANNEDRENTRAISE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Negotiation Date: The notification date for the Estate Rent Raise Rate negotiations' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'NEGOTIATION_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for estate rent period.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_ESTATERENTPERIODLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
