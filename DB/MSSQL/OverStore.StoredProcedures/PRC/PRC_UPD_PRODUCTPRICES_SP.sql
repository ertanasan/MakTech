CREATE PROCEDURE PRC_UPD_PRODUCTPRICES_SP  
    @ProductPriceId    INT,  
    @PriceAmount       NUMERIC(22,6),  
    @Product           INT,  
    @Package           INT,  
    @TopPriceAmount    NUMERIC(22,6),  
    @PrintTopPriceFlag VARCHAR(1),  
    @PackageVersion    INT,
	@CurrentPriceAmount NUMERIC(22,6),
	@PackageProduct	VARCHAR(1)
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

	DECLARE @RowExist INT;
	SELECT @RowExist = COUNT(*) FROM PRC_PRODUCT WHERE PRODUCTID = @ProductPriceId AND PACKAGE = @Package;

	IF @RowExist > 0 -- log at
	BEGIN
		INSERT INTO PRC_PRODUCTLOG  
		(  
			PRODUCTID,  
			LOG_DT,  
			LOGUSER,  
			LOGOPERATION_CD,  
			LOGCHANNEL,  
			LOGBRANCH,  
			LOGSCREEN,  
			PRICE_AMT,  
			PRODUCT,  
			PACKAGE,  
			TOPPRICE_AMT,  
			PRINTTOPPRICE_FL,  
			PACKAGEVERSION  
		)  
		SELECT  
			PRODUCTID,  
			GETDATE(),  
			dbo.SYS_GETCURRENTUSER_FN(),  
			'UPD',  
			dbo.SYS_GETCURRENTCHANNEL_FN(),  
			dbo.SYS_GETCURRENTBRANCH_FN(),  
			dbo.SYS_GETCURRENTSCREEN_FN(),  
			PRICE_AMT,  
			PRODUCT,  
			PACKAGE,  
			TOPPRICE_AMT,  
			PRINTTOPPRICE_FL,  
			PACKAGEVERSION  
		  FROM  
			PRC_PRODUCT P (NOLOCK)  
		 WHERE P.PRODUCTID = @ProductPriceId
			AND PACKAGE = @Package;
	END

	IF (@CurrentPriceAmount = @PriceAmount AND @Package != 1 AND @PackageProduct = 'N') 
		UPDATE PRC_PRODUCT SET DELETED_FL = 'Y', UPDATE_DT = GETDATE() WHERE PRODUCTID = @ProductPriceId AND PACKAGE = @Package
	ELSE 
	BEGIN
		IF (@RowExist > 0)
		BEGIN
			UPDATE PRC_PRODUCT  
			   SET UPDATE_DT = GETDATE(),  
				   UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),  
				   PRICE_AMT = @PriceAmount,  
				   PRODUCT = @Product,  
				   PACKAGE = @Package,  
				   TOPPRICE_AMT = @TopPriceAmount,  
				   PRINTTOPPRICE_FL = @PrintTopPriceFlag,  
				   PACKAGEVERSION = @PackageVersion  
			 WHERE PRODUCTID = @ProductPriceId  
			   AND PACKAGE = @Package
			   AND (@Organization IS NULL OR ORGANIZATION = @Organization);
		END
		ELSE
		BEGIN
			EXEC PRC_INS_PRODUCT_SP @ProductPriceId, @PriceAmount, @Product, @Package, @TopPriceAmount, @PrintTopPriceFlag, @PackageVersion
		END
	END;
  
END;  