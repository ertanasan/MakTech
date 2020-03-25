﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [STR_CASHIERTEMPLATE]
(
    /*Section="Columns"*/
    [CASHIERTEMPLATEID]  INT NOT NULL,
    [CASHIERTEMPLATE_NM] VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [STR_CASHIERTEMPLATE_PK] PRIMARY KEY ([CASHIERTEMPLATEID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Cashier Template: Kasiyer Şablonu',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'STR_CASHIERTEMPLATE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Template Id: Identity column for STR_CASHIERTEMPLATE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERTEMPLATE', 
    @level2type=N'COLUMN',
    @level2name=N'CASHIERTEMPLATEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Cashier Template Name: Name of cashier template.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'STR_CASHIERTEMPLATE', 
    @level2type=N'COLUMN',
    @level2name=N'CASHIERTEMPLATE_NM'
GO

/*Section="End"*/
