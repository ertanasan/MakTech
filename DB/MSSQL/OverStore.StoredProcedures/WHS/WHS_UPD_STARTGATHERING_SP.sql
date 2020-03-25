CREATE PROCEDURE [dbo].[WHS_UPD_STARTGATHERING_SP] @GatheringId BIGINT, @AllowReGather VARCHAR(1), @ErrorCode INT OUT AS
BEGIN
	DECLARE @gatheringStatus INT, @orderStatus INT, @PaletNo INT, @GatheringUser INT;
    DECLARE @currentUser INT = dbo.SYS_GETCURRENTUSER_FN();
	SET @ErrorCode = 0;

	BEGIN TRANSACTION TRX;
    
	SELECT @gatheringStatus = G.GATHERINGSTATUS, @orderStatus = SO.STATUS, @GatheringUser = G.GATHERINGUSER
	  FROM WHS_GATHERING G
	  JOIN WHS_STOREORDER SO ON G.STOREORDER = SO.STOREORDERID
	  JOIN STR_STORE ST ON SO.STORE = ST.STOREID
	  JOIN WHS_GATHERINGTYPE GT ON G.GATHERINGTYPE = GT.GATHERINGTYPEID
	 WHERE G.GATHERINGID = @GatheringId;
	
	IF ((@gatheringStatus = 1 AND @orderStatus = 3) -- beklemede ve sevk edilmemiş durumda
		OR
		(@orderStatus = 3 AND @AllowReGather = 'Y')) -- tekrar toplanacasa. 
	BEGIN
		/* Section: Deleting current GatheringPallets */
		IF (@AllowReGather = 'Y' AND @gatheringStatus = 9)
		BEGIN
			DECLARE @gatheringPalletId INT = 0;
			WHILE @gatheringPalletId IS NOT NULL
			BEGIN
				SELECT @gatheringPalletId = MAX(GP.GATHERINGPALLETID)
					FROM WHS_GATHERINGPALLET GP
					WHERE GP.GATHERING = @GatheringId
					AND GP.DELETED_FL = 'N';
		
				IF @gatheringPalletId IS NOT NULL
					EXEC WHS_DEL_GATHERINGPALLET_SP @gatheringPalletId 
			END
		END
		/* Section Ends */

		UPDATE WHS_GATHERING 
		   SET GATHERINGUSER = dbo.SYS_GETCURRENTUSER_FN()
			 , GATHERINGSTART_TM = GETDATE()
			 , GATHERINGEND_TM = NULL
			 , GATHERINGSTATUS = 2 -- toplanıyor
		 WHERE GATHERINGID = @GatheringId
	END ELSE IF (@gatheringStatus = 2 AND @GatheringUser = @currentUser AND @orderStatus = 3) -- kendi başlattığı işe devam ediyor
	BEGIN
	  SET @ErrorCode = 0; -- kendi başlattığı işe devam ediyor
	END	ELSE IF (@orderStatus != 3)
	BEGIN
	  SET @ErrorCode = 1; -- sevk edilmiş
	END ELSE IF @gatheringStatus = 2 
	BEGIN
	  SET @ErrorCode = 2; -- şu an toplanıyor
	END ELSE IF @gatheringStatus = 9
	BEGIN
	  DECLARE @GatheringPalletStatus INT;
	  SELECT @GatheringPalletStatus = MAX(GP.GATHERINGPALLETSTATUS)
	    FROM WHS_GATHERINGPALLET GP
		JOIN WHS_GATHERING G ON GP.GATHERING = G.GATHERINGID
	   WHERE GP.GATHERING = @GatheringId AND GP.DELETED_FL = 'N'

	  IF @GatheringPalletStatus = 1   
		SET @ErrorCode = 3; -- zaten toplanmış  
	  ELSE -- @GatheringPalletStatus > 1   
		SET @ErrorCode = 4;  -- zaten toplanmış ve kontrol işlemi başlamış
	END 
	COMMIT TRANSACTION TRX;  
END