CREATE TABLE [dbo].[WHS_GATHERINGLOG]
(
    /*Section="Columns"*/
    [GATHERINGID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [STOREORDER]        BIGINT NOT NULL,
    [GATHERINGUSER]     INT NULL,
    [GATHERINGSTART_TM] DATETIME NULL,
    [GATHERINGEND_TM]   DATETIME NULL,
    [GATHERINGSTATUS]   INT NOT NULL,
    [GATHERINGTYPE]     INT NOT NULL,
    [PRIORITY_NO]       INT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Gathering Log: gathering, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_GATHERINGLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering Id: Identity column for WHS_GATHERING' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG', 
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGID'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Store Order: StoreOrderId from WHS_STOREORDER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'STOREORDER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering User: UserId of gathering user from SEC_USER' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering Start Time: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGSTART_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering End Time: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGEND_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering Status: StatusId of WHS_GATHERINGSTATUS' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGSTATUS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering Type: gatheringType' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGTYPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Priority: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGLOG',
    @level2type=N'COLUMN',
    @level2name=N'PRIORITY_NO'
GO

/*Section="End"*/
