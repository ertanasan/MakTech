CREATE PROCEDURE STR_LST_USERSSTORES_SP  
    @User INT,  
    @Store INT  
AS  
BEGIN  
  
    /*Section="Query"*/  
    -- Select all  
    SELECT  
           U.[USER],  
           U.STORE,  
           U.CREATE_DT,  
           U.CREATEUSER,  
           U.CREATECHANNEL,  
           U.CREATEBRANCH,  
           U.CREATESCREEN,  
           [USER].USER_NM "USER.USER_NM",  
           STORE.STORE_NM "STORE.STORE_NM"  
      FROM STR_USERSSTORES U (NOLOCK)  
      JOIN SEC_USER [USER] (NOLOCK) ON U.[USER] = [USER].USERID   
      JOIN STR_STORE STORE (NOLOCK) ON U.STORE = STORE.STOREID  
     WHERE (@User IS NULL OR U.[USER] = @User)  
       AND (@Store IS NULL OR U.STORE = @Store)  
     ORDER BY USER;  
  
/*Section="End"*/  
END;