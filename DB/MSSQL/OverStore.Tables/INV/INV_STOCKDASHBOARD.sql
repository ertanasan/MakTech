﻿CREATE TABLE [dbo].[INV_STOCKDASHBOARD](
	[DATE_DT] [datetime] NULL,
	[STORE] [int] NULL,
	[PRODUCT] [int] NULL,
	[STOCK_QTY] [float] NULL,
	[STOCK_AMT] [float] NULL,
	[SALE_QTY] [numeric](38, 6) NULL,
	[SALE_AMT] [numeric](38, 6) NULL
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX INV_STOCKDASHBOARD_IX01 ON INV_STOCKDASHBOARD(DATE_DT, STORE, PRODUCT) INCLUDE (STOCK_AMT, STOCK_QTY, SALE_QTY, SALE_AMT)
GO
CREATE INDEX INV_STOCKDASHBOARD_IX02 ON INV_STOCKDASHBOARD(STORE) INCLUDE (DATE_DT, PRODUCT, STOCK_AMT, STOCK_QTY, SALE_QTY, SALE_AMT)
GO
CREATE INDEX INV_STOCKDASHBOARD_IX03 ON INV_STOCKDASHBOARD(PRODUCT) INCLUDE (DATE_DT, STORE, STOCK_AMT, STOCK_QTY, SALE_QTY, SALE_AMT)
GO
