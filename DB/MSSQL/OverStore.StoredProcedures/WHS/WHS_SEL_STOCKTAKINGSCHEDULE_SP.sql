
CREATE PROCEDURE WHS_SEL_STOCKTAKINGSCHEDULE_SP  
    @StockTakingScheduleId BIGINT  
AS  
BEGIN  
  
    /*Section="Query"*/  
    -- Select  
    SELECT  
           S.STOCKTAKINGSCHEDULEID,  
           S.EVENT,  
           S.ORGANIZATION,  
           S.DELETED_FL,  
           S.CREATE_DT,  
           S.UPDATE_DT,  
           S.CREATEUSER,  
           S.UPDATEUSER,  
           S.CREATECHANNEL,  
           S.CREATEBRANCH,  
           S.CREATESCREEN,  
           S.SCHEDULE_NM,  
           S.STORE,  
           S.COUNTINGTYPE,  
           S.PLANNED_DT,  
           S.ACTUAL_DT,  
           S.STATUS        
      FROM WHS_STOCKTAKINGSCHEDULE S (NOLOCK)  
     WHERE S.STOCKTAKINGSCHEDULEID = @StockTakingScheduleId        
  
    /*Section="End"*/  
END;  