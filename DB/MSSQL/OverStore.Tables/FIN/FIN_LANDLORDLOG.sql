-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [FIN_LANDLORDLOG]
(
    /*Section="Columns"*/
    [LANDLORDID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [LANDLOARD_NM] VARCHAR(100) NOT NULL,
    [LANDLORDTYPE_CD] INT NOT NULL,
    [LANDLORD_ADR] VARCHAR(1000) NOT NULL,
    [CONTACT_TXT] VARCHAR(1000) NULL,
    [NATIONALID_TXT] VARCHAR(20) NULL,
    [TAXPAYERID_TXT] VARCHAR(20) NULL,
    [TAXOFFICE_TXT] VARCHAR(100) NULL,
    [LEGALREPRESENTATIVE] INT NULL,
    [ACCOUNTINGCODE_TXT] VARCHAR(50) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Landlord Log: Landlord of the store/warehouse , logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'FIN_LANDLORDLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Landlord Id: Identity column for FIN_LANDLORD' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LANDLORDID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Landlord Name: Name of estate landlord.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LANDLOARD_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Landlord Type: 1_ gerçek kişi, 
2 _ tüzel kişi' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LANDLORDTYPE_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Landlord Address: address of the landlord' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LANDLORD_ADR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Contact Info: Contact info of the landlord' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CONTACT_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'National Id: National Identification Number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'NATIONALID_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Taxpayer Id: taxpayer identification number' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'TAXPAYERID_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Tax Office: Tax Office' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'TAXOFFICE_TXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Legal Representative: legal representative of the landlord' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LEGALREPRESENTATIVE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Accounting Code: Accounting Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'ACCOUNTINGCODE_TXT'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'FIN_LANDLORDLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
