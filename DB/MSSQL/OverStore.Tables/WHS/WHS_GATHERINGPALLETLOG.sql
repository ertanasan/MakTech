-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_GATHERINGPALLETLOG]
(
    /*Section="Columns"*/
    [GATHERINGPALLETID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [GATHERING] BIGINT NOT NULL,
    [PALLET_NO] INT NOT NULL,
    [CONTROLUSER] INT NULL,
    [CONTROLSTART_TM] DATETIME NULL,
    [CONTROLEND_TM] DATETIME NULL,
    [GATHERINGPALLETSTATUS] INT NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Gathering Pallet Log: gathering pallet, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_GATHERINGPALLETLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering Pallet Id: Identity column for WHS_GATHERINGPALLET' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGPALLETID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering: gathering' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'GATHERING'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Pallet No: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'PALLET_NO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Control User: Unique identifier for {table}.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CONTROLUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Control : N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CONTROLSTART_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Control End Time: N/A' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'CONTROLEND_TM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Gathering Pallet Status: WHS_GATHERINGPALLETSTATUS fk' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'GATHERINGPALLETSTATUS'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_GATHERINGPALLETLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
