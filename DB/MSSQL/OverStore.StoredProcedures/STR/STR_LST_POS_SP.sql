  
CREATE PROCEDURE [dbo].[STR_LST_POS_SP] @Store INT =NULL  
AS  
BEGIN  
       
    DECLARE @Organization INT;  
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();  
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1  
    BEGIN  
       
      SET @Organization = null;  
    END  
    
    SELECT  
           P.POSID,  
           P.ORGANIZATION,  
           P.DELETED_FL,  
           P.CREATE_DT,  
           P.UPDATE_DT,  
           P.CREATEUSER,  
           P.UPDATEUSER,  
           P.STORE,  
           P.POSCODE_TXT,  
           P.BANK,  
           P.CASHREGISTERCODE_TXT,  
           P.BANKCODE_TXT,  
           P.DESCRIPTION_TXT,
		   P.MOBIL_FL,
           P.OKC_TXT
      FROM STR_POS P (NOLOCK)  
     WHERE (@Store IS NULL OR P.STORE = @Store)  
       AND  (@Organization IS NULL OR P.ORGANIZATION = @Organization)  
       AND DELETED_FL = 'N';  
  
   
END;  
