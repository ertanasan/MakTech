CREATE PROCEDURE DWH_BAT_WHSORDER_SP AS 
BEGIN

	SELECT s.sip_stok_kod, sto_isim, ct.cari_kod, ct.cari_unvan1, s.sip_tarih, s.sip_teslim_tarih, s.sip_b_fiyat, s.sip_miktar, s.sip_teslim_miktar, s.sip_tutar, s.sip_aciklama, s.sip_depono, S.sip_Guid
	  INTO #NEWLIST
	  FROM MIK_SIPARISLER20_SYN S
	  JOIN MIK_CURRENTACCOUNT20_SYN CT ON S.sip_musteri_kod = CT.cari_kod
	  LEFT JOIN MIK_STOKLAR20_SYN P ON S.sip_stok_kod = P.sto_kod

	DELETE O
	-- SELECT *
	  FROM WHS_ORDER_SYN O 
	  LEFT JOIN #NEWLIST NL ON O.ORDERGUID = NL.sip_Guid
	 WHERE O.ORDER_DT > '2020-01-22'
	   AND NL.sip_Guid IS NULL

	UPDATE O
	   SET PRODUCTCODE_NM = NL.sip_stok_kod, 
		   PRODUCT_NM = NL.sto_isim,
		   VENDOR_CD = NL.cari_kod,
		   VENDOR_NM = NL.cari_unvan1, 
		   ORDER_DT = NL.sip_tarih,
		   DELIVERY_DT = NL.sip_teslim_tarih,
		   UNITPRICE_AMT = NL.sip_b_fiyat,
		   ORDER_QTY = NL.sip_miktar,
		   DELIVERY_QTY = NL.sip_teslim_miktar,
		   ORDER_AMT = NL.sip_tutar,
		   ORDER_DSC = NL.sip_aciklama,
		   DELIVERYWH_CD = NL.sip_depono
	-- SELECT *
	  FROM WHS_ORDER_SYN O 
	  JOIN #NEWLIST NL ON O.ORDERGUID = NL.sip_Guid
	 WHERE (PRODUCTCODE_NM != NL.sip_stok_kod OR
		   PRODUCT_NM != NL.sto_isim OR
		   VENDOR_CD != NL.cari_kod OR
		   VENDOR_NM != NL.cari_unvan1 OR
		   ORDER_DT != NL.sip_tarih OR
		   DELIVERY_DT != NL.sip_teslim_tarih OR
		   UNITPRICE_AMT != cast(NL.sip_b_fiyat as numeric(12,3)) OR
		   ORDER_QTY != cast(NL.sip_miktar as numeric(12,3)) OR
		   DELIVERY_QTY != cast(NL.sip_teslim_miktar as numeric(12,3)) OR
		   ORDER_AMT != cast(NL.sip_tutar as numeric(22,6)) OR
		   ORDER_DSC != NL.sip_aciklama OR
		   DELIVERYWH_CD != NL.sip_depono)

	INSERT INTO WHS_ORDER_SYN
	SELECT NL.*
	  FROM #NEWLIST NL
	  LEFT JOIN WHS_ORDER_SYN O ON O.ORDERGUID = NL.sip_Guid
	 WHERE O.ORDERGUID IS NULL
END