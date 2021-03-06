﻿CREATE TABLE [dbo].[INV_STOCKTRANSACTIONS_SYN](
	[WAREHOUSE] [int] NULL,
	[TRANSACTION_DT] [date] NULL,
	[PRODUCT] [int] NULL,
	[TRANSACTIONTYPE] [int] NULL,
	[QUANTITY_QTY] [numeric](10, 3) NULL,
	[COUNTERWAREHOUSE] [int] NULL,
	[INFO_TXT] [varchar](200) NULL,
	[MIKROGUID] [uniqueidentifier] NULL
) ON [PRIMARY]