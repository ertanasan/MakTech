-- Created by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_EMPLOYEELOG]
(
    /*Section="Columns"*/
    [EMPLOYEEID] INT NOT NULL,
    [LOG_DT] DATETIME NOT NULL,
    [LOGUSER] INT NOT NULL,
    [LOGOPERATION_CD] VARCHAR(3) NOT NULL,
    [LOGCHANNEL] INT NOT NULL,
    [LOGBRANCH] INT NOT NULL,
    [LOGSCREEN] INT NOT NULL,
    [EMPLOYEE_NM] VARCHAR(100) NOT NULL,
    [DEPARTMENT_CD] INT NULL,
    [DEPARTMENT_NM] VARCHAR(100) NOT NULL,
    [INCENTIVEACT_CD] INT NULL,
    [START_DT] DATETIME NULL,
    [QUIT_DT] DATETIME NULL,
    [WORKINGTYPE_DSC] VARCHAR(100) NULL
)
GO

/*Section="TableComment"*/
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Employee Log: Employees, logs.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_EMPLOYEELOG',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Employee Id: Identity column for STR_EMPLOYEE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'EMPLOYEEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Employee Name: Name of employee.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'EMPLOYEE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Department Code: Department Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'DEPARTMENT_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Department Name: Department Name' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'DEPARTMENT_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Incentive Act Code: Incentive Act Code' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'INCENTIVEACT_CD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Start Date: Start Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'START_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Quit Date: Quit Date' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'QUIT_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Working Type: Working Type' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'WORKINGTYPE_DSC'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Date: Logging date.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOG_DT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Log User Id: User Id of the log operation.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGUSER'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Operation Type: INSert, UPDate, DELete operation types.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGOPERATION_CD'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Channel: Log Channel identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGCHANNEL'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Branch: Log Branch identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGBRANCH'
GO

EXEC sys.sp_addextendedproperty
    @name=N'MS_Description',
    @value=N'Log Screen: Log Screen identifier.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo',
    @level1type=N'TABLE',
    @level1name=N'STR_EMPLOYEELOG',
    @level2type=N'COLUMN',
    @level2name=N'LOGSCREEN'
GO

/*Section="End"*/
