﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [RCL_BANKNOTE]
(
    /*Section="Columns"*/
    [BANKNOTEID]   INT NOT NULL IDENTITY,
    [BANKNOTE_AMT] NUMERIC(22,6) NOT NULL,
    [COIN_FL]      VARCHAR(1) NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [RCL_BANKNOTE_PK] PRIMARY KEY ([BANKNOTEID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Banknote: Banknote',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'RCL_BANKNOTE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Banknote Id: Identity column for RCL_BANKNOTE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'RCL_BANKNOTE', 
    @level2type=N'COLUMN',
    @level2name=N'BANKNOTEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Banknote Amount: Banknote Amount' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'RCL_BANKNOTE', 
    @level2type=N'COLUMN',
    @level2name=N'BANKNOTE_AMT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Coin Flag: Coin Flag' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'RCL_BANKNOTE', 
    @level2type=N'COLUMN',
    @level2name=N'COIN_FL'
GO

/*Section="End"*/
