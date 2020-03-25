﻿CREATE PROCEDURE [dbo].[RCL_SEL_ADJUSTMENTDATE_SP] @StoreId INT, @RecDate DATE AS
BEGIN
  SELECT ISNULL(SUM(AMOUNT_AMT),0) ADJUSMTENT_AMT
    FROM RCL_ADJUSTMENT
   WHERE STORE = @StoreId  
     AND CAST(DATE_DT AS DATE) = @RecDate
	 AND DELETED_FL = 'N'
END
