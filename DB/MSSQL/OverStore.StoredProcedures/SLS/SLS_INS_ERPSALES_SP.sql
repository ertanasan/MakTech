﻿CREATE PROCEDURE SLS_INS_ERPSALES_SP @StoreId INT, @TransactionDate DATE WITH RECOMPILE AS
BEGIN

	INSERT INTO SLS_SALE 
	(EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, TRANSACTION_TXT
	, STORE, CASHIER_NM, CASHREGISTER, TRANSACTION_DT, TRANSACTION_TM, TOTALVAT_AMT, TOTAL_AMT, PRODUCTDISCOUNT_AMT, SALEDISCOUNT_AMT, PRODUCT_CNT
	, DURATION_CNT, CANCELLED_FL, TRANSACTIONTYPE)
	SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, 
		   CAST(MagazaNo AS VARCHAR(10))+'-'+CAST(KasaTanim_id AS VARCHAR(10))+'-'+REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR,IslemZamani,120),'-',''),':',''),' ','')+'-'+CAST(HareketNo AS VARCHAR(10)) TRANSACTION_TXT, 
		   MagazaNo, '00000000', KasaTanim_id, CAST(IslemZamani AS DATE),  IslemZamani, 0, HareketToplami, 0, 0, UrunAdedi, SatisSuresi, 
		   CASE WHEN LEFT(HareketBayrakMeta,1) = '1' THEN 'Y' ELSE 'N' END CANCELLED_FL, HareketTipi
	  FROM ERP_SALE_SYN
	 WHERE MAGAZANO = @StoreId
	   AND CAST(IslemZamani AS DATE) = @TransactionDate
	   AND HareketTipi in (1, 2, 5)

	INSERT INTO SLS_SALEDETAIL 
	(EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, SALE, TRANSACTION_TXT, TRANSACTION_DT
	, BARCODE_TXT, PRODUCT, PRODUCTCODE_NM, STORE, PRICE, VAT_RT, QUANTITY_QTY, UNIT, CANCEL_FL, UNITPRICE_AMT)
	SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, SS.SALEID, SS.TRANSACTION_TXT, SS.TRANSACTION_DT, 
		   CAST(SD.BarkodTip AS VARCHAR) + CAST(SD.PLU AS VARCHAR) BARCODE_TXT, P.PRODUCTID, P.CODE_NM, SS.STORE, SD.SatisToplami, SD.KDVOran, SD.Miktar, 
		   CASE SD.BirimTipi WHEN 1 THEN 1 WHEN 0 THEN 2 ELSE SD.BirimTipi END UNIT, CASE WHEN LEFT(SatisBayrakMeta,1) = '1' THEN 'Y' ELSE 'N' END CANCEL_FL,
		   SD.BirimFiyat
	  FROM ERP_SALE_SYN S
	  JOIN ERP_SALEDETAIL_SYN SD ON S.ID = SD.Hareket_id
	  JOIN SLS_SALE SS ON SS.TRANSACTION_TXT = CAST(MagazaNo AS VARCHAR(10))+'-'+CAST(KasaTanim_id AS VARCHAR(10))+'-'+REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR,IslemZamani,120),'-',''),':',''),' ','')+'-'+CAST(HareketNo AS VARCHAR(10)) 
	  LEFT JOIN PRD_BARCODE B ON CAST(SD.BarkodTip AS VARCHAR) + CAST(SD.PLU AS VARCHAR) COLLATE Turkish_100_CI_AS = B.BARCODE_TXT
	  JOIN PRD_PRODUCT P ON ISNULL(B.PRODUCT, 326) = P.PRODUCTID
	 WHERE MAGAZANO = @StoreId
	   AND CAST(IslemZamani AS DATE) = @TransactionDate
	   AND HareketTipi in (1, 2, 5)

	INSERT INTO SLS_SALEPAYMENT
	(EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, SALE
	, TRANSACTION_TXT, TRANSACTION_DT, STORE, PAYMENTTYPE_TXT, PAID_AMT, REFUND_AMT, POSBANKTYPE, POSTRXTYPE
	, ACCNO_TXT, DEBITCARD_FL, CARD_AMT)
	SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, SALEID, TRANSACTION_TXT, TRANSACTION_DT, STORE, '00', TOTAL_AMT, 0, 0, 0, ' ', 'N', 0
	  FROM SLS_SALE
	 WHERE STORE = @StoreId
	   AND TRANSACTION_DT = @TransactionDate

	INSERT INTO SLS_SALEZET
	(EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, STORE
	, TRANSACTION_DT, ZET_NO, RECEIPT_CNT, RECEIPTTOTAL_AMT, REFUND_CNT, REFUND_AMT, CASHREGISTER
	, SLPTOTAL_AMT, SLP_CNT)
	SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, S.Magazano, CAST(S.IslemZamani AS DATE) TRANSACTION_DT, 
		   SZ.ZRaporNo, SZ.FisliSatisSayisi, SZ.FisliSatisToplam, SZ.GiderPusulaSayisi, SZ.GiderPusulaToplam, S.KasaTanim_id,
		   SZ.FaturaliSatisToplam, SZ.FaturaliSatisSayisi
	  FROM ERP_SALE_SYN S
	  JOIN ERP_SALEZET_SYN SZ ON S.ID = SZ.Hareket_id
	 WHERE MAGAZANO = @StoreId
	   AND CAST(IslemZamani AS DATE) = @TransactionDate
	   AND HareketTipi IN (80, 84, 85)

END