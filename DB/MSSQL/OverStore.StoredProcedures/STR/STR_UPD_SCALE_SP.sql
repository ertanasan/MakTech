-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE [dbo].[STR_UPD_SCALE_SP]
    @StoreScalesId        INT,
    @Name                 VARCHAR(100),
    @Store                INT,
    @ScaleModel           INT,
    @PriceFilePath        VARCHAR(200),
    @CurrentPriceVersion  INT,
    @CurrentPriceLoadTime DATETIME,
    @PrivatePriceVersion  INT,
    @PrivatePriceLoadTime DATETIME,
    @CreatePriceFileFlag  VARCHAR(1),
    @IpAdress             VARCHAR(20),
    @Status               VARCHAR(1),
    @StatusText           VARCHAR(100),
	@SerialNumber		  VARCHAR(100),
	@SealValidDate        DATETIME
AS
BEGIN



	DECLARE @changed INT;
	SELECT @changed = COUNT(*)
	  FROM STR_SCALE
	 WHERE SCALEID = @StoreScalesId
	   AND (STATUS_FL != @Status OR SCALE_NM != @Name OR 
			STORE != @Store OR SCALEMODEL != @ScaleModel OR
			PRICEFILEPATH_TXT != @PriceFilePath OR 
			IPADDRESS_TXT != @IpAdress);

	IF @changed > 0 
	BEGIN
	  INSERT INTO STR_SCALELOG	
	  (SCALEID
		, LOG_DT
		, LOGUSER
		, LOGOPERATION_CD
		, LOGCHANNEL
		, LOGBRANCH
		, LOGSCREEN
		, SCALE_NM
		, STORE
		, SCALEMODEL
		, PRICEFILEPATH_TXT
		, CURRENTPRICEVERSION
		, CURRENTPRICELOAD_TM
		, PRIVATEPRICEVERSION
		, PRIVATEPRICELOAD_TM
		, CREATEPRICEFILE_FL
		, IPADDRESS_TXT
		, STATUS_FL
		, STATUS_TXT
		, SERIAL_TXT
		, SEALVALID_DT)
	  SELECT  S.SCALEID,	GETDATE(),  dbo.SYS_GETCURRENTUSER_FN(),  'UPD',  dbo.SYS_GETCURRENTCHANNEL_FN(),  
			  dbo.SYS_GETCURRENTBRANCH_FN(),  dbo.SYS_GETCURRENTSCREEN_FN(),  S.SCALE_NM,
			  S.STORE, S.SCALEMODEL, S.PRICEFILEPATH_TXT, S.CURRENTPRICEVERSION, S.CURRENTPRICELOAD_TM, S.PRIVATEPRICEVERSION,
			  S.PRIVATEPRICELOAD_TM, S.CREATEPRICEFILE_FL, S.IPADDRESS_TXT, S.STATUS_FL, S.STATUS_TXT, S.SERIAL_TXT, S.SEALVALID_DT
	     FROM STR_SCALE S (NOLOCK)  
        WHERE S.SCALEID = @StoreScalesId;  
	END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_SCALE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SCALE_NM = @Name,
           STORE = @Store,
           SCALEMODEL = @ScaleModel,
           PRICEFILEPATH_TXT = @PriceFilePath,
           -- CURRENTPRICEVERSION = @CurrentPriceVersion,
           -- CURRENTPRICELOAD_TM = @CurrentPriceLoadTime,
           -- PRIVATEPRICEVERSION = @PrivatePriceVersion,
           -- PRIVATEPRICELOAD_TM = @PrivatePriceLoadTime,
           CREATEPRICEFILE_FL = @CreatePriceFileFlag,
           IPADDRESS_TXT = @IpAdress,
           STATUS_FL = @Status,
           STATUS_TXT = @StatusText,
		   SERIAL_TXT = @SerialNumber,
		   SEALVALID_DT = @SealValidDate
     WHERE SCALEID = @StoreScalesId

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;