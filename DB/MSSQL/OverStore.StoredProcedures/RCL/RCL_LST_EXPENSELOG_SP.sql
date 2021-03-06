﻿CREATE PROCEDURE RCL_LST_EXPENSELOG_SP @ExpenseId BIGINT AS
BEGIN

	SELECT B.EXPENSEID, LOG_DT, USERFULL_NM
		 , CASE WHEN NEXTLOG_DT IS NULL THEN ET2.EXPENSETYPE_NM ELSE B.EXPENSETYPE_NM END EXPENSETYPE_NM
		 , CASE WHEN NEXTLOG_DT IS NULL THEN LASTE.EXPENSE_DT ELSE B.EXPENSE_DT END EXPENSE_DT
		 , CASE WHEN NEXTLOG_DT IS NULL THEN LASTE.EXPENSE_AMT ELSE B.EXPENSE_AMT END EXPENSE_AMT
		 , CASE WHEN NEXTLOG_DT IS NULL THEN LASTE.RECEIPTNO_TXT ELSE B.RECEIPTNO_TXT END RECEIPTNO_TXT
		 , CASE WHEN NEXTLOG_DT IS NULL THEN LASTE.PAYOFF_DT ELSE B.PAYOFF_DT END PAYOFF_DT
		 , CASE WHEN NEXTLOG_DT IS NULL THEN LASTE.VAT_RT ELSE B.VAT_RT END VAT_RT
		 , CASE WHEN NEXTLOG_DT IS NULL THEN LASTE.OPEN_FL ELSE B.OPEN_FL END OPEN_FL
	  FROM (
	SELECT EXPENSEID, LOG_DT, USERFULL_NM
		 , LEAD(LOG_DT) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) NEXTLOG_DT
		 , LEAD(EXPENSETYPE_NM) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) EXPENSETYPE_NM
		 , LEAD(EXPENSE_DT) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) EXPENSE_DT
		 , LEAD(EXPENSE_AMT) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) EXPENSE_AMT
		 , LEAD(RECEIPTNO_TXT) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) RECEIPTNO_TXT
		 , LEAD(PAYOFF_DT) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) PAYOFF_DT
		 , LEAD(VAT_RT) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) VAT_RT
		 , LEAD(OPEN_FL) OVER (PARTITION BY EXPENSEID ORDER BY LOG_DT) OPEN_FL
	  FROM (
	SELECT E.EXPENSEID, E.CREATE_DT LOG_DT, U1.USERFULL_NM, ET.EXPENSETYPE_NM, E.EXPENSE_DT, E.EXPENSE_AMT, E.RECEIPTNO_TXT, E.PAYOFF_DT, E.VAT_RT, E.OPEN_FL
	  FROM RCL_EXPENSE E 
	  LEFT JOIN RCL_EXPENSETYPE ET ON E.EXPENSETYPE = ET.EXPENSETYPEID
	  JOIN SEC_USER U1 ON E.CREATEUSER = U1.USERID
	 UNION ALL
	SELECT EL.EXPENSEID, EL.LOG_DT, U1.USERFULL_NM, ET.EXPENSETYPE_NM, EL.EXPENSE_DT, EL.EXPENSE_AMT, EL.RECEIPTNO_TXT, EL.PAYOFF_DT, EL.VAT_RT, EL.OPEN_FL
	  FROM RCL_EXPENSELOG EL
	  LEFT JOIN RCL_EXPENSETYPE ET ON EL.EXPENSETYPE = ET.EXPENSETYPEID
	  JOIN SEC_USER U1 ON EL.LOGUSER = U1.USERID) A ) B
	  JOIN RCL_EXPENSE LASTE ON B.EXPENSEID = LASTE.EXPENSEID
	  LEFT JOIN RCL_EXPENSETYPE ET2 ON LASTE.EXPENSETYPE = ET2.EXPENSETYPEID
	 WHERE B.EXPENSEID = @ExpenseId
	 ORDER BY B.EXPENSEID, LOG_DT

END