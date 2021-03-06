﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [SLS_POSBANKTYPE]
(
    /*Section="Columns"*/
    [POSBANKTYPEID] INT NOT NULL,
    [BANKTYPE_NM]   VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [SLS_POSBANKTYPE_PK] PRIMARY KEY ([POSBANKTYPEID]) 
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [SLS_POSBANKTYPE_X01] ON [SLS_POSBANKTYPE] ([BANKTYPE_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Pos Bank Type: Pos Bank Type',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'SLS_POSBANKTYPE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Pos Bank Type Id: Identity column for SLS_POSBANKTYPE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'SLS_POSBANKTYPE', 
    @level2type=N'COLUMN',
    @level2name=N'POSBANKTYPEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Bank Type: Name of pos bank type.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'SLS_POSBANKTYPE', 
    @level2type=N'COLUMN',
    @level2name=N'BANKTYPE_NM'
GO

/*Section="End"*/
