CREATE PROCEDURE [dbo].[WHS_SEL_STOREORDERFORGATHERING_SP]
	@param1 int = 0,
	@param2 int
AS
BEGIN
    DECLARE @SelectedStoreOrderId SYS_LONGS;
    DECLARE @Count INT = 0;

    BEGIN TRANSACTION TRX;
    INSERT INTO @SelectedStoreOrderId
        SELECT TOP 1 STOREORDERID
          FROM WHS_STOREORDER WITH (UPDLOCK, ROWLOCK, READPAST) 
         WHERE STATUS IN (3, 301, 302, 310, 320, 311, 321, 312, 322)
		 ORDER BY ORDER_DT DESC;

    SELECT @Count = COUNT(*)
      FROM @SelectedStoreOrderId;

    SELECT SO.*
      FROM WHS_STOREORDER SO (NOLOCK)
     WHERE SO.STOREORDERID = @SelectedStoreOrderId;

    IF @Count > 0
    BEGIN
		DECLARE @StoreOrderId BIGINT,
				@Event        INT,
				@Organization INT,
				@Store        INT,
				@OrderCode    VARCHAR(100),
				@Status       INT = 301,
				@OrderDate    DATETIME,
				@ShipmentDate DATETIME;

		SELECT  @StoreOrderId	= OS.STOREORDERID,
				@Event			= OS.[EVENT],
				@Organization	= OS.[ORGANIZATION],
				@Store			= OS.STORE,
				@OrderCode		= OS.ORDERCODE_NM,
				@OrderDate		= OS.ORDER_DT,
				@ShipmentDate	= OS.SHIPMENT_DT
		   FROM WHS_STOREORDER OS
		  WHERE OS.STOREORDERID = @SelectedStoreOrderId
		
		EXEC WHS_UPD_STOREORDER_SP 
				@StoreOrderId,
				@Event,
				@Organization,
				@Store,
				@OrderCode,
				@Status,
				@OrderDate,
				@ShipmentDate;
    END;
    COMMIT TRANSACTION TRX;
END;
