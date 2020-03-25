﻿CREATE PROCEDURE WHS_UPD_FESTOCKTAKING_SP 
  @StockTakingSchedule BIGINT
, @Product INT
, @Zone INT
, @CountingValue NUMERIC(12,6) AS
BEGIN
  UPDATE WHS_STOCKTAKING
     SET COUNTINGVALUE_AMT = @CountingValue
	   , UPDATE_DT = GETDATE()
	   , UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN()
   WHERE STOCKTAKINGSCHEDULE = @StockTakingSchedule
     AND PRODUCT = @Product
	 AND [ZONE] = @Zone
	 
  IF @@ROWCOUNT = 0 
  BEGIN
      INSERT INTO WHS_STOCKTAKING
      (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN,	
	   STORE, COUNTING_DT, PRODUCT, COUNTINGVALUE_AMT, ZONE, STOCKTAKINGSCHEDULE)    
	  VALUES    
	  (1, 1, 'N', GETDATE(),    
       dbo.SYS_GETCURRENTUSER_FN(),    
       dbo.SYS_GETCURRENTCHANNEL_FN(),    
       dbo.SYS_GETCURRENTBRANCH_FN(),    
       dbo.SYS_GETCURRENTSCREEN_FN(),    
       (SELECT STORE FROM WHS_STOCKTAKINGSCHEDULE WHERE STOCKTAKINGSCHEDULEID = @StockTakingSchedule),    
       CAST(GETDATE() AS DATE),    
       @Product, @CountingValue, @Zone, @StockTakingSchedule)    
  END
END