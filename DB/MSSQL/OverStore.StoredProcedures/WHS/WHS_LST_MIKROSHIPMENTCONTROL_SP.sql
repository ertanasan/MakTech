﻿CREATE PROCEDURE WHS_LST_MIKROSHIPMENTCONTROL_SP @StoreOrderId BIGINT AS
BEGIN
	SELECT SOD.*, P.NAME_NM PRODUCT_NM, P.CODE_NM PRODUCTCODE_NM
	  FROM WHS_STOREORDERDETAIL SOD
	  JOIN PRD_PROPERTY PP ON SOD.PRODUCT = PP.PRODUCT
	  JOIN PRD_PRODUCT P ON PP.PRODUCT = P.PRODUCTID
	 WHERE PP.PROPERTYTYPE = 4
	   AND PP.VALUE_TXT = '1'
	   AND SOD.SHIPPED_QTY > 0 
	   AND SOD.STOREORDER = @StoreOrderId 
END