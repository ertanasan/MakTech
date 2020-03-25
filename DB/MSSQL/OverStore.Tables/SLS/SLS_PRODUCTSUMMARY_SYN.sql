CREATE TABLE [dbo].[SLS_PRODUCTSUMMARY_SYN](
	[TRANSACTION_DT] [date] NULL,
	[STORE] [int] NOT NULL,
	[PRODUCT] [int] NOT NULL,
	[SALE_QTY] [numeric](38, 7) NULL,
	[SALE_AMT] [numeric](38, 6) NULL,
	[SALE_CNT] [int] NULL,
	[REFUND_QTY] [numeric](38, 7) NULL,
	[REFUND_AMT] [numeric](38, 6) NULL,
	[REFUND_CNT] [int] NULL
) ON [PRIMARY]
GO