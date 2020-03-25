﻿CREATE PROCEDURE WHS_INS_STOREORDERSUGGESTIONS_SP @StoreOrderId BIGINT AS
BEGIN
	IF OBJECT_ID('tempdb..#suggestions') IS NOT NULL DROP TABLE #suggestions

	SET NOCOUNT OFF
	DECLARE @storeId INT, @status INT;
	SELECT @storeId = STORE, @status = [STATUS] FROM WHS_STOREORDER WHERE STOREORDERID = @StoreOrderId

	IF @@ROWCOUNT = 0 
	BEGIN
		SET NOCOUNT ON;
        THROW 100001, 'Order not found', 1;
        RETURN;
	END
	SET NOCOUNT ON;

	IF @status = 1 -- giriş statüsündeyse
	BEGIN
		DECLARE @today DATE = CAST(GETDATE() AS DATE)
		SELECT *
		  INTO #suggestions
		  FROM [WHS_ORDERSUGGESTION_FN](@storeId, @today)

		UPDATE SOD SET SOD.SUGGESTION_QTY = SG.ORDER_QTY
		  FROM WHS_STOREORDERDETAIL SOD
		  JOIN #suggestions SG ON SOD.PRODUCT = SG.PRODUCT
		 WHERE SOD.STOREORDER = @StoreOrderId

		INSERT INTO WHS_STOREORDERDETAIL 
		(EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN,
		 PRODUCT, ORDER_QTY, REVISED_QTY, SHIPPED_QTY, ORDERUNIT_QTY, STOREORDER, INTAKE_QTY, SUGGESTION_QTY)
		SELECT 1047, 1, 'N', GETDATE(),
			   dbo.SYS_GETCURRENTUSER_FN(),
			   dbo.SYS_GETCURRENTCHANNEL_FN(),
			   dbo.SYS_GETCURRENTBRANCH_FN(),
			   dbo.SYS_GETCURRENTSCREEN_FN(),
			   SG.PRODUCT, 0, 0, 0, SG.ORDERUNIT_QTY, @StoreOrderId, 0, SG.ORDER_QTY
		  FROM #suggestions SG
		  LEFT JOIN WHS_STOREORDERDETAIL SOD ON SOD.STOREORDER = @StoreOrderId AND SOD.PRODUCT = SG.PRODUCT
		 WHERE SOD.STOREORDER IS NULL
	END
END