CREATE PROCEDURE STR_UPD_CASHREGISTER_SP    
    @StoreCashRegisterId  INT,    
    @Name                 VARCHAR(100),    
    @Store                INT,    
    @CashRegisterModel    INT,    
    @PriceFilePath        VARCHAR(200),    
    @SaleFilePath1        VARCHAR(1000),    
    @SaleFilePath2        VARCHAR(1000),    
    @SaleFilePath3        VARCHAR(1000),    
    @CurrentPriceVersion  INT,    
    @CurrentPriceLoadTime DATETIME,    
    @PrivatePriceVersion  INT,    
    @PrivatePriceLoadTime DATETIME,    
    @CreatePriceFileFlag  VARCHAR(1),    
    @IpAddress            VARCHAR(20),    
    @Status               VARCHAR(1),    
    @StatusText           VARCHAR(100),  
    @GibDeviceNo          VARCHAR(20),
    @SerialNo             VARCHAR(100)
AS    
BEGIN    
        
    DECLARE @changed INT;    
    SELECT @changed = COUNT(*)    
      FROM STR_CASHREGISTER    
     WHERE CASHREGISTERID = @StoreCashRegisterId    
       AND (STATUS_FL != @Status OR CASHREGISTER_NM != @Name OR     
            STORE != @Store OR CASHREGISTERMODEL != @CashRegisterModel OR    
            PRICEFILEPATH_TXT != @PriceFilePath OR     
            SALEFILEPATH1_TXT != @SaleFilePath1 OR     
            SALEFILEPATH2_TXT != @SaleFilePath2 OR     
            SALEFILEPATH3_TXT != @SaleFilePath3 OR     
            IPADDRESS_TXT != @IpAddress OR  
            GIBDEVICENO_TXT != @GibDeviceNo);    
       
    IF @changed > 0     
    BEGIN    
      INSERT INTO STR_CASHREGISTERLOG     
      (CASHREGISTERID, LOG_DT, LOGUSER, LOGOPERATION_CD, LOGCHANNEL, LOGBRANCH, LOGSCREEN, CASHREGISTER_NM,     
      STORE, CASHREGISTERMODEL, PRICEFILEPATH_TXT, SALEFILEPATH1_TXT, SALEFILEPATH2_TXT, SALEFILEPATH3_TXT,    
      CURRENTPRICEVERSION, CURRENTPRICELOAD_TM, PRIVATEPRICEVERSION, PRIVATEPRICELOAD_TM, CREATEPRICEFILE_FL,    
      IPADDRESS_TXT, STATUS_FL, STATUS_TXT, GIBDEVICENO_TXT)    
      SELECT C.CASHREGISTERID, GETDATE(),  dbo.SYS_GETCURRENTUSER_FN(),  'UPD',  dbo.SYS_GETCURRENTCHANNEL_FN(),      
             dbo.SYS_GETCURRENTBRANCH_FN(),  dbo.SYS_GETCURRENTSCREEN_FN(),  C.CASHREGISTER_NM,    
             C.STORE, C.CASHREGISTERMODEL, C.PRICEFILEPATH_TXT, C.SALEFILEPATH1_TXT, C.SALEFILEPATH2_TXT,     
             C.SALEFILEPATH3_TXT, C.CURRENTPRICEVERSION, C.CURRENTPRICELOAD_TM, C.PRIVATEPRICEVERSION,    
             C.PRIVATEPRICELOAD_TM, C.CREATEPRICEFILE_FL, C.IPADDRESS_TXT, C.STATUS_FL, C.STATUS_TXT, C.GIBDEVICENO_TXT  
        FROM STR_CASHREGISTER C (NOLOCK)      
       WHERE C.CASHREGISTERID = @StoreCashRegisterId;
    END    
    
    
    SET NOCOUNT OFF;    
    UPDATE STR_CASHREGISTER    
       SET UPDATE_DT = GETDATE(),    
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),    
           CASHREGISTER_NM = @Name,    
           STORE = @Store,    
           CASHREGISTERMODEL = @CashRegisterModel,    
           PRICEFILEPATH_TXT = @PriceFilePath,    
           SALEFILEPATH1_TXT = @SaleFilePath1,    
           SALEFILEPATH2_TXT = @SaleFilePath2,    
           SALEFILEPATH3_TXT = @SaleFilePath3,    
           CREATEPRICEFILE_FL = @CreatePriceFileFlag,    
           IPADDRESS_TXT = @IpAddress,    
           STATUS_FL = @Status,    
           STATUS_TXT = @StatusText,   
           GIBDEVICENO_TXT = @GibDeviceNo,
           SERIALNO_TXT = @SerialNo
     WHERE CASHREGISTERID = @StoreCashRegisterId;    
    
    IF @@ROWCOUNT = 0    
    BEGIN    
        SET NOCOUNT ON;    
        THROW 100001, 'Nothing to update. Update failed.', 1;    
        RETURN;    
    END;    
    SET NOCOUNT ON;    
    
END; 