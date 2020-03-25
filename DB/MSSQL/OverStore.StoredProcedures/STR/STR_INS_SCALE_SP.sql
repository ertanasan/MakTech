-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE [dbo].[STR_INS_SCALE_SP]
    @StoreScalesId        INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_SCALE
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        SCALE_NM,
        STORE,
        SCALEMODEL,
        PRICEFILEPATH_TXT,
        CURRENTPRICEVERSION,
        CURRENTPRICELOAD_TM,
        PRIVATEPRICEVERSION,
        PRIVATEPRICELOAD_TM,
        CREATEPRICEFILE_FL,
        IPADDRESS_TXT,
        STATUS_FL,
        STATUS_TXT,
		SERIAL_TXT,
		SEALVALID_DT
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Name,
        @Store,
        @ScaleModel,
        @PriceFilePath,
        @CurrentPriceVersion,
        @CurrentPriceLoadTime,
        @PrivatePriceVersion,
        @PrivatePriceLoadTime,
        @CreatePriceFileFlag,
        @IpAdress,
        @Status,
        @StatusText,
		@SerialNumber,
		@SealValidDate
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @StoreScalesId = SCOPE_IDENTITY();
/*Section="End"*/
END;