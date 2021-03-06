﻿CREATE PROCEDURE [dbo].[WHS_UPD_ORDERGATHERING_SP] @StoreOrderId BIGINT AS
BEGIN
	WITH CONTROLQUANTITY AS (
	SELECT STOREORDERDETAILID, SUM(ISNULL(CONTROL_QTY,0)) CONTROL_QTY
	  FROM WHS_GATHERINGDETAIL_VW WHERE STOREORDER = @StoreOrderId
	 GROUP BY STOREORDERDETAILID )
	UPDATE SOD 
	   SET SHIPPED_QTY = C.CONTROL_QTY
		 , INTAKE_QTY = C.CONTROL_QTY
		 , UPDATE_DT = GETDATE()
		 , UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN()
	  FROM WHS_STOREORDERDETAIL SOD
	  JOIN CONTROLQUANTITY C ON SOD.STOREORDERDETAILID = C.STOREORDERDETAILID
	 WHERE SOD.STOREORDER = @StoreOrderId

	INSERT INTO WHS_STOREORDERHISTORY  
	(EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, 
	 STOREORDER, HISTORY_TM, STATUS)  
	SELECT EVENT, ORGANIZATION, DELETED_FL, GETDATE(), dbo.SYS_GETCURRENTUSER_FN(), dbo.SYS_GETCURRENTCHANNEL_FN(),
		   dbo.SYS_GETCURRENTBRANCH_FN(), dbo.SYS_GETCURRENTSCREEN_FN(), @StoreOrderId, GETDATE(), 4
	  FROM WHS_STOREORDER
	 WHERE STOREORDERID = @StoreOrderId;

	UPDATE SO 
	   SET STATUS = 4 -- shipped
	     , UPDATE_DT = GETDATE()
		 , UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN()
	  FROM WHS_STOREORDER SO
	 WHERE STOREORDERID = @StoreOrderId

	EXEC WHS_INS_WAYBILL_SP @StoreOrderId
END