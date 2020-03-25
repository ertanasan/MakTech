CREATE PROCEDURE WHS_LST_PRODUCTRETURN_SP @StatusCode INT = -1 AS
BEGIN
	IF OBJECT_ID('tempdb.dbo.#stores', 'U') IS NOT NULL  DROP TABLE #stores;
	SELECT * into #stores FROM dbo.STR_GETUSERSTORES_FN();
    SELECT P.PRODUCTRETURNID,
           P.EVENT,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           P.RETURN_DT,
           P.WAYBILL_DT,
           P.PRODUCT,
           P.SUPPLIER_TXT,
           P.MANUFACTURING_DT,
           P.EXPIRE_DT,
           P.RETURNQUANTITY_AMT,
           P.PACKAGETYPE,
           P.RETURNREASON_TXT,
           P.RETURNDESTINATION,
           P.STATUS_CD,
           P.PROCESSINSTANCE_LNO,
           P.STORE,
		   P.INTAKE_AMT,
		   P.CUSTOMERRETURN_FL,
           P.REUSABLE_FL,
		   CASE P.STATUS_CD
		   WHEN 1 THEN 'Giriş'
		   WHEN 2 THEN 'Onaylandı'
		   WHEN 3 THEN 'Sevk Edildi'
		   WHEN 4 THEN 'Kabul Edildi'
		   -- WHEN 5 THEN 'Tamamlandı'
		   WHEN 6 THEN 'Reddedildi'
		   WHEN 7 THEN 'İptal'
		   ELSE 'Tanımsız'
		   END STATUS_TXT,
		   P.SALEDETAIL,
		   P.WAYBILL_TXT
      FROM WHS_PRODUCTRETURN P (NOLOCK)
	  JOIN #stores ST ON P.STORE = ST.STOREID
     WHERE P.DELETED_FL = 'N'
	   AND (@StatusCode = -1 OR P.STATUS_CD = @StatusCode)
     ORDER BY RETURN_DT DESC;
END;
