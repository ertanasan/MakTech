CREATE PROCEDURE [dbo].[STR_UPD_PROPERTYFORALLSTORES_SP]  
    @PropertyType   INT,  
	@PropertyValue VARCHAR(1000)  
AS  
BEGIN  
 /*Section="Update SP For Each Store"*/  
 UPDATE STR_PROPERTY   
  SET VALUE_TXT = @PropertyValue  
  WHERE STORE IN (SELECT PR.STORE FROM STR_PROPERTY PR WHERE PR.PROPERTYTYPE = @PropertyType AND PR.VALUE_TXT IS NOT NULL AND PR.VALUE_TXT != @PropertyValue)  
   AND PROPERTYTYPE = @PropertyType  
  
 SELECT @@ROWCOUNT;  
 /*Section="End"*/  
END;  