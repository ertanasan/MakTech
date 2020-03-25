CREATE FUNCTION dbo.WHS_GETSHIPMENTDAY_FN (@StoreId INT, @ProcessTime DATETIME) RETURNS DATE AS
BEGIN
	-- mevcut zaman bilgisini oku, 
	-- saat 4'ü geçtiyse 1 gün ileri at
	-- 2 gün ileri at ve o gün için sevk günü mü diye bak, değilse ilk sevk günü olan günü bul.
	DECLARE @now DATETIME, @shipmentDay DATE, @addDays INT, @schedule VARCHAR(30), @ShipmentDate DATE;
	
	SELECT @schedule = SCHEDULE_TXT FROM WHS_SHIPMENTSCHEDULE WHERE STORE = @StoreId

	SET @now = @ProcessTime;
	set @addDays = 2;

	IF DATEPART(HOUR,@now) >= 16
	BEGIN
		SET @addDays = 3;
	END

	SET @shipmentDay = DATEADD(DAY, @addDays, @now);

	WITH STOREDAYS AS
	(SELECT 1 DAYOFWEEKNO WHERE SUBSTRING(@schedule,1,1) = 1 UNION ALL
	 SELECT 2 WHERE SUBSTRING(@schedule,3,1) = 1 UNION ALL
	 SELECT 3 WHERE SUBSTRING(@schedule,5,1) = 1 UNION ALL
	 SELECT 4 WHERE SUBSTRING(@schedule,7,1) = 1 UNION ALL
	 SELECT 5 WHERE SUBSTRING(@schedule,9,1) = 1 UNION ALL
	 SELECT 6 WHERE SUBSTRING(@schedule,11,1) = 1 UNION ALL
	 SELECT 7 WHERE SUBSTRING(@schedule,13,1) = 1 )
	SELECT @ShipmentDate = MIN(DATE_DT) 
	  FROM RPT_DATE
	 WHERE DATE_DT >= @shipmentDay
	   AND DAYOFWEEK_NO IN (SELECT DAYOFWEEKNO FROM STOREDAYS)

	RETURN CAST(@ShipmentDate AS DATE);
END