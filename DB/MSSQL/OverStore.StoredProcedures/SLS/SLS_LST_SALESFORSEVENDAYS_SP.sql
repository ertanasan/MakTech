
CREATE PROCEDURE [dbo].[SLS_LST_SALESFORSEVENDAYS_SP]
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
			STORE,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = DATEADD(DAY, -6, @TransactionDate) THEN TOTAL_AMT END) AS _6DaysBefore,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = DATEADD(DAY, -5, @TransactionDate) THEN TOTAL_AMT END) AS _5DaysBefore,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = DATEADD(DAY, -4, @TransactionDate) THEN TOTAL_AMT END) AS _4DayBefore,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = DATEADD(DAY, -3, @TransactionDate) THEN TOTAL_AMT END) AS _3DayBefore,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = DATEADD(DAY, -2, @TransactionDate) THEN TOTAL_AMT END) AS _2DayBefore,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = DATEADD(DAY, -1, @TransactionDate) THEN TOTAL_AMT END) AS _1DayBefore,
			SUM(CASE WHEN CONVERT(DATE, TRANSACTION_DT) = @TransactionDate THEN TOTAL_AMT END) AS _QueryDay,
			SUM(TOTAL_AMT) as SevenDaysSales,
			COUNT(TOTAL_AMT) as SevenDaysSalesAmount 
		FROM  SLS_SALE (NOLOCK) 
		WHERE CONVERT(DATE, TRANSACTION_DT) < DATEADD(DAY, 7, @TransactionDate)
			AND (@Organization IS NULL OR ORGANIZATION = @Organization)
		GROUP BY STORE
		ORDER BY SevenDaysSales DESC

    /*Section="End"*/
END;
