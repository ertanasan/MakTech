﻿-- Generated by OverGenerator
/*Section="Main"*/
CREATE TABLE [WHS_SHIPMENTTYPE]
(
    /*Section="Columns"*/
    [SHIPMENTTYPEID]  INT NOT NULL,
    [SHIPMENTTYPE_NM] VARCHAR(100) NOT NULL,
    /*Section="PrimaryKey"*/
    CONSTRAINT [WHS_SHIPMENTTYPE_PK] PRIMARY KEY ([SHIPMENTTYPEID]) 
);
GO

/*Section="Indexes"*/

CREATE UNIQUE INDEX [WHS_SHIPMENTTYPE_X01] ON [WHS_SHIPMENTTYPE] ([SHIPMENTTYPE_NM])
GO

/*Section="TableComment"*/
-- Add table comment
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Shipment Type: Shipment Type',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'WHS_SHIPMENTTYPE',
    @level2type = NULL,
    @level2name = NULL
GO

/*Section="ColumnComments"*/
-- Add column comments

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Shipment Type Id: Identity column for WHS_SHIPMENTTYPE' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_SHIPMENTTYPE', 
    @level2type=N'COLUMN',
    @level2name=N'SHIPMENTTYPEID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
    @value=N'Shipment Type Name: Name of shipment type.' ,
    @level0type=N'SCHEMA',
    @level0name=N'dbo', 
    @level1type=N'TABLE',
    @level1name=N'WHS_SHIPMENTTYPE', 
    @level2type=N'COLUMN',
    @level2name=N'SHIPMENTTYPE_NM'
GO

/*Section="End"*/