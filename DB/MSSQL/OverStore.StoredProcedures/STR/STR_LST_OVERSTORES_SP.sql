CREATE PROCEDURE [dbo].[STR_LST_OVERSTORES_SP]  
AS  
BEGIN  
    DECLARE @Organization INT;  
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();  
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1  
    BEGIN  
      SET @Organization = null;  
    END  
    SELECT  
           S.STOREID,  
           S.ORGANIZATION,  
           S.DELETED_FL,  
           S.CREATE_DT,  
           S.UPDATE_DT,  
           S.CREATEUSER,  
           S.UPDATEUSER,  
           S.STORE_NM,  
           S.BRANCH,  
           S.IPADDRESS_TXT,  
           S.ADVANCE_AMT,  
           S.OPENING_DT,  
           S.CLOSING_DT,  
           S.ACTIVE_FL,  
           S.PRODUCTION_FL,  
           S.CITY,  
           S.TOWN,  
           S.ADDRESS_TXT  
      FROM STR_STORE S (NOLOCK)  
     WHERE PRODUCTION_FL = 'Y'  
    AND (@Organization IS NULL OR S.ORGANIZATION = @Organization)  
       AND DELETED_FL = 'N'  
     ORDER BY STOREID;  
  
END;  