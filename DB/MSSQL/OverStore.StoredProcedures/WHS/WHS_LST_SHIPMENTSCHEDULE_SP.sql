/*Section="Main"*/    
CREATE PROCEDURE [dbo].[WHS_LST_SHIPMENTSCHEDULE_SP] 
	@Store INT = -1
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
    /*Section="Query"*/    
      
 -- Insert default schedule for new store   
 INSERT INTO WHS_SHIPMENTSCHEDULE   
 SELECT 1, 'N', GETDATE(), NULL, 1, NULL, STORE_NM, STOREID, '0-0-0-0-0-0-0', NULL  
   FROM STR_STORE_VW ST  
   LEFT JOIN WHS_SHIPMENTSCHEDULE SS ON ST.STOREID = SS.STORE  
  WHERE SS.STORE IS NULL  
   
 -- Select all    
    SELECT    
           S.SHIPMENTSCHEDULEID,    
           S.ORGANIZATION,    
           S.DELETED_FL,    
           S.CREATE_DT,    
           S.UPDATE_DT,    
           S.CREATEUSER,    
           S.UPDATEUSER,    
           S.SHIPMENTSCHEDULE_NM,    
           S.STORE,    
           S.SCHEDULE_TXT,    
           S.COMMENT_DSC    
      FROM WHS_SHIPMENTSCHEDULE S (NOLOCK)    
     WHERE (@Organization IS NULL OR S.ORGANIZATION = @Organization)    
       AND DELETED_FL = 'N'    
    AND S.STORE = CASE WHEN @Store = -1 THEN S.STORE ELSE @Store END  
     ORDER BY SHIPMENTSCHEDULE_NM;    
    
/*Section="End"*/    
END; 