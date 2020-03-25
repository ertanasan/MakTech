﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [PRD_BARCODETYPE]
(
    /*Section="Columns"*/
    [BARCODETYPEID]  INT NOT NULL,
    [BARCODETYPE_NM] VARCHAR(100) NOT NULL,
    [COMMENT_DSC]    VARCHAR(1000) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [PRD_BARCODETYPE_PK] PRIMARY KEY ([BARCODETYPEID]) 
);
GO

/*Section="Indexes"*/

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Barcode Type: Perakende, raf, koli gibi barkod türleri bilgisini tutacak...',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PRD_BARCODETYPE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode Type Id: Identity column for PRD_BARCODETYPE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODETYPE', 
    @level2type=N'COLUMN',
    @level2name=N'BARCODETYPEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Barcode Type: Name of barcode type.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODETYPE', 
    @level2type=N'COLUMN',
    @level2name=N'BARCODETYPE_NM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Comment: Comment for barcode type.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'PRD_BARCODETYPE', 
    @level2type=N'COLUMN',
    @level2name=N'COMMENT_DSC'
GO

/*Section="End"*/
