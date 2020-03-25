CREATE PROCEDURE STR_INS_CASHREGISTER_SP    
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
	@GibDeviceNo          VARCHAR(10),
    @SerialNo             VARCHAR(100)
    
AS    
BEGIN    
    SET NOCOUNT OFF    
  
    -- ID generator  
    DECLARE @ID INT  
    SELECT TOP 1 @ID = ROWNO  
      FROM (  
    SELECT TOP 900 99+row_number() over(order by DATE_DT) ROWNO  
      FROM RPT_DATE) A  
      LEFT JOIN STR_CASHREGISTER CR ON A.ROWNO = CR.CASHREGISTERID  
     WHERE CR.CASHREGISTERID IS NULL  
     ORDER BY ROWNO    
  
    INSERT INTO STR_CASHREGISTER    
    (    
        CASHREGISTERID,    
        ORGANIZATION,    
        DELETED_FL,    
        CREATE_DT,    
        CREATEUSER,    
        CASHREGISTER_NM,    
        STORE,    
        CASHREGISTERMODEL,    
        PRICEFILEPATH_TXT,    
        SALEFILEPATH1_TXT,    
        SALEFILEPATH2_TXT,    
        SALEFILEPATH3_TXT,    
        CURRENTPRICEVERSION,    
        CURRENTPRICELOAD_TM,    
        PRIVATEPRICEVERSION,    
        PRIVATEPRICELOAD_TM,    
        CREATEPRICEFILE_FL,    
        IPADDRESS_TXT,    
        STATUS_FL,    
        STATUS_TXT,
		GIBDEVICENO_TXT,
        SERIALNO_TXT
    )    
    VALUES    
    (    
        @ID, -- @StoreCashRegisterId,    
        dbo.SYS_GETCURRENTORGANIZATION_FN(),    
        'N',    
        GETDATE(),    
        dbo.SYS_GETCURRENTUSER_FN(),    
        @Name,    
        @Store,    
        @CashRegisterModel,    
        @PriceFilePath,    
        @SaleFilePath1,    
        @SaleFilePath2,    
        @SaleFilePath3,    
        @CurrentPriceVersion,    
        @CurrentPriceLoadTime,    
        @PrivatePriceVersion,    
        @PrivatePriceLoadTime,    
        @CreatePriceFileFlag,    
        @IpAddress,    
        @Status,    
        @StatusText,
		@GibDeviceNo,
        @SerialNo
    );    
    
    IF @@ROWCOUNT = 0    
    BEGIN    
        SET NOCOUNT ON;    
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;    
        RETURN;    
    END;    
    SET NOCOUNT ON;    
END; 