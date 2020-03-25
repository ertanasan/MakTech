-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [OSM_SCREENPROPERTYLOG]
(
    /*Section="Columns"*/
    [SCREENPROPERTYID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [SCREEN] INT NOT NULL,
    [PROPERTY_NM] VARCHAR(100) NOT NULL,
    [VALUE_TXT] VARCHAR(1000) NOT NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'OverStore Screen Property Log: OverStore Screen Property, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'OSM_SCREENPROPERTYLOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'OverStore Screen Property Id: Identity column for OSM_SCREENPROPERTY' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'SCREENPROPERTYID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Screen: Screen' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'SCREEN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Property Name: Name of overstore screen property.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'PROPERTY_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Property Value: Property Value' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'VALUE_TXT'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Date: Logging date.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Channel: Log Channel identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Branch: Log Branch identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Log Screen: Log Screen identifier.' , 
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'OSM_SCREENPROPERTYLOG', 
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
