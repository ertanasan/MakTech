
CREATE PROCEDURE [dbo].[SLS_LST_STORECOUNTMONTHLY_SP]
	@TransactionDate DATETIME = NULL
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
		SET @Organization = null;
    END

	/* Section="TransactionDate" */
	IF @TransactionDate IS NULL
		SET @TransactionDate = GETDATE();
	-- The @transactionDate will be used as DATE type inside the query; DATETIME -> DATE transformation is needed
	SET @TransactionDate = CONVERT(DATE, @TransactionDate);

    /*Section="Query"*/
  SELECT
		CONVERT(CHAR(4), DATEPART(YEAR, TRANSACTION_DT)) + '-' + (RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(MONTH, TRANSACTION_DT)),2)) AS [Year-Month],
		COUNT(DISTINCT STORE) AS StoreCount,
		CONVERT(INT,SUM(TOTAL_AMT)) AS [TotalSales],
		CONVERT(INT, SUM(TOTAL_AMT) / COUNT(DISTINCT STORE)) AS [SalesPerStore]
	FROM  SLS_SALE (NOLOCK)
	WHERE CONVERT(DATE, TRANSACTION_DT) > DATEADD(YEAR, -1, @TransactionDate)
		--AND S.ACTIVE_FL = 'Y'
		AND (@Organization IS NULL OR ORGANIZATION = @Organization)
	GROUP BY CONVERT(CHAR(4), DATEPART(YEAR, TRANSACTION_DT)) + '-' + (RIGHT('00' + CONVERT(NVARCHAR(2), DATEPART(MONTH, TRANSACTION_DT)),2))
	ORDER BY [Year-Month]

    /*Section="End"*/
END;