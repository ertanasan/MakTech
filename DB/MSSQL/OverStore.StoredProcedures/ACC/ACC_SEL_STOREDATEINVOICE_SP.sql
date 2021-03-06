﻿CREATE PROCEDURE ACC_SEL_STOREDATEINVOICE_SP @StoreId INT, @InvoiceDate DATE AS
BEGIN
	SELECT ISNULL(SUM(ABS(S.TOTAL_AMT)), 0)
	  FROM ACC_INVOICE I
	  JOIN SLS_SALE S ON I.SALE = S.SALEID
	 WHERE S.STORE = @StoreId
	   AND S.TRANSACTION_DT = @InvoiceDate
	   AND I.DELETED_FL = 'N'
	   AND S.TRANSACTIONTYPE = 5
END