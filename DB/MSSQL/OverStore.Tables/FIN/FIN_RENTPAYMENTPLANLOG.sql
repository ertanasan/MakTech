-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [FIN_RENTPAYMENTPLANLOG]
(
    /*Section="Columns"*/
    [RENTPAYMENTPLANID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [ESTATERENTPERIOD] INT NOT NULL,
    [PAYMENTORDER_NO] INT NOT NULL,
    [DUE_DT] DATETIME NOT NULL,
    [PAYMENT_AMT] NUMERIC(22,6) NOT NULL,
    [CURRENCY_TXT] VARCHAR(3) NOT NULL,
    [ADDITIONALPAYMENT_AMT] NUMERIC(22,6) NULL,
    [ADDPAYMENTCURRENCY_TXT] VARCHAR(3) NULL,
    [COMMENT_DSC] VARCHAR(1000) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Rent Payment Plan Log: Rent Payment Plan, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FIN_RENTPAYMENTPLANLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Rent Payment Plan Id: Identity column for FIN_RENTPAYMENTPLAN' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'RENTPAYMENTPLANID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Rent Period: Estate Rent Period  FK from FIN_ESTATERENTPERIOD' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'ESTATERENTPERIOD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Payment Order: Payment Order of the Rental Agreement Period' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'PAYMENTORDER_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Due Date: Payment Due Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'DUE_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Payment Amount: Payment Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'PAYMENT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Currency: Currency type of the payment' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'CURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Payment Amount: Additional Payment Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'ADDITIONALPAYMENT_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Additional Payment Currency: currency of additional payment' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'ADDPAYMENTCURRENCY_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for rent payment plan.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_RENTPAYMENTPLANLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
