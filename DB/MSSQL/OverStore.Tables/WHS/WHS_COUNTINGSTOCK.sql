CREATE TABLE [dbo].[WHS_COUNTINGSTOCK](
	[STORE] [int] NULL,
	[DATE_DT] [datetime] NOT NULL,
	[PREVDATE_DT] [datetime] NULL,
	[PRODUCT] [int] NULL,
	[STOCKGROUP_NM] [varchar](200) NULL,
	[PREVCOUNTING] [numeric](38, 3) NULL,
	[STOCK] [numeric](38, 3) NULL,
	[NEWCOUNTING] [numeric](38, 3) NULL
)