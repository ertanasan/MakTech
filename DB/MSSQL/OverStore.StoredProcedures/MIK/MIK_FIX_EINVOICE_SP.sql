CREATE PROCEDURE MIK_FIX_EINVOICE_SP @SaleInvoiceId BIGINT AS
BEGIN
	-- DECLARE @SaleInvoiceId BIGINT = 63
	DECLARE @FisSiraNo INT, @FisYevmiyeNo INT, @TranNo BIGINT 

	DECLARE @emptyguid nvarchar(40)                      
	SET @emptyguid = '00000000-0000-0000-0000-000000000000';                      
	DECLARE @emptydate datetime;                      
	SET @emptydate = CONVERT(DATETIME, '18991230', 112);         
	DECLARE @evraktip INT = 63
	DECLARE @chacins INT = 6
	DECLARE @Day DATE, @SaleId BIGINT, @AccountNo VARCHAR(50), @AccountName VARCHAR(1000), @StoreId INT, @StoreName VARCHAR(100);
	DECLARE @VergiDaireAdi VARCHAR(1000), @VergiDaireNo VARCHAR(100), @cariMuhKodu VARCHAR(100), @efatura VARCHAR(3)

	SELECT @Day = S.TRANSACTION_DT, @SaleId = S.SALEID, @AccountNo = cari_kod
		 , @AccountName = cari_unvan1, @StoreId = S.STORE, @StoreName = ST.STORE_NM
		 , @VergiDaireAdi = cari_vdaire_adi, @VergiDaireNo = cari_vdaire_no
		 , @cariMuhKodu = cari_muh_kod, @efatura = CASE WHEN EINVOICE_FL = 'Y' THEN 'MAK' ELSE 'MEM' END
	  FROM SLS_SALE S
	  JOIN ACC_INVOICE I ON S.SALEID = I.SALE
	  JOIN MIK_CURRENTACCOUNT20_SYN CA ON CAST(I.CUSTOMERID_LNO AS VARCHAR) = Replace(Ltrim(Replace(CA.cari_vdaire_no, '0', ' ')), ' ', '0')
	  JOIN STR_STORE ST ON S.STORE = ST.STOREID
	 WHERE I.INVOICEID = @SaleInvoiceId
	
	DECLARE @belgeNo NVARCHAR(100), @belgeSeri VARCHAR(3)
	SELECT @belgeNo = LEFT(MAXBELGENO,3)+CAST(CAST(RIGHT(MAXBELGENO,13) AS numeric(16,0))+1 AS varchar),
		   @belgeSeri = CASE WHEN @efatura = 'MAK' THEN 'MPE' ELSE 'MPA' END
	  FROM (
	SELECT MAX(cha_belge_no) MAXBELGENO
	  FROM MIK_CURRENTTRANSACTION20_SYN
	 WHERE cha_belge_no LIKE @efatura+'%') A

	SET @belgeNo = '' -- ilk başta belge no atamayacağız... 17.01.2020

	DECLARE @sorumlulukmerkezikodu VARCHAR(100)
	SELECT @sorumlulukmerkezikodu = '20100'+RIGHT('000'+ISNULL(CAST(@StoreId AS VARCHAR(10)),''),3)   

	SELECT @FisSiraNo = ISNULL(MAX(fis_sira_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_tarih = @Day;  
	SELECT @FisYevmiyeNo = ISNULL(MAX(fis_yevmiye_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@Day); 
	-- SELECT @FisSiraNo, @FisYevmiyeNo
	 
	IF OBJECT_ID('tempdb..#transactions') IS NOT NULL DROP TABLE #transactions
	IF OBJECT_ID('tempdb..#accrows') IS NOT NULL DROP TABLE #accrows

	SELECT STORE, P.CODE_NM PRODUCTCODE_NM, ABS(PRICE) PRICE, VAT_RT, ABS(ROUND(PRICE * 100.0 / (100.0 + VAT_RT), 2)) PRICENOWAT
		 , CASE WHEN SD.UNIT = 1 THEN QUANTITY_QTY / 1000.0 ELSE QUANTITY_QTY END QUANTITY
		 , ROW_NUMBER() OVER (ORDER BY SD.SALEDETAILID) ROWNO
		 , CASE VAT_RT WHEN 0 THEN 1 WHEN 1 THEN 2 WHEN 8 THEN 3 WHEN 18 THEN 4 END VATGROUP_CD
	  INTO #transactions
	  FROM SLS_SALEDETAIL SD
	  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID
	 WHERE SALE = @SaleId
	   AND SD.DELETED_FL = 'N'
	   AND SD.CANCEL_FL = 'N';

	WITH VATGROUP AS (
	SELECT CAST(VAT_RT AS INT) VAT_RT, SUM(PRICE) PRICE, SUM(PRICENOWAT) PRICENOWAT
	  FROM #transactions
	 GROUP BY CAST(VAT_RT AS INT))
	SELECT * INTO #accrows
	  FROM (
    SELECT '100.02.001' ACCCODE, SUM(PRICE) AMOUNT FROM VATGROUP
	 UNION ALL
	SELECT '391.01.'+RIGHT('000'+CAST(VAT_RT AS varchar),3), PRICENOWAT-PRICE FROM VATGROUP 
	 UNION ALL
    SELECT '600.01.'+RIGHT('000'+CAST(VAT_RT AS varchar),3), -1*PRICENOWAT FROM VATGROUP) A

	DECLARE @totalAmount NUMERIC(22, 6), @totalNoWatAmount NUMERIC(22, 6)
	SELECT @totalAmount = SUM(PRICE), @totalNoWatAmount = SUM(PRICENOWAT) FROM #transactions

	DECLARE @tranGUID uniqueidentifier;
	SELECT @tranGUID = fis_ticari_uid, @FisYevmiyeNo = fis_yevmiye_no, @belgeNo = fis_tic_belgeno
		 , @FisSiraNo = fis_sira_no
	  FROM MIK_ACCOUNTING20_SYN 
	 WHERE fis_tic_evrak_sira = @SaleId AND fis_hesap_kod LIKE '100%' 

    DECLARE @maxno INT
	SELECT @maxno = MAX(fis_satir_no) FROM MIK_ACCOUNTING20_SYN WHERE fis_tic_evrak_sira = @SaleId; 

	DECLARE @fisaciklama1 NVARCHAR(254) = 'Sat.fat : '+CAST(@SaleId AS VARCHAR)+'/'+CONVERT(VARCHAR, @Day, 104)+'/'+@AccountNo+'/'+LEFT(@AccountName,30)+'/100.01.'+RIGHT('000'+ISNULL(CAST(@StoreId AS VARCHAR(10)),''),3)+'/'+@StoreName;

	-- SELECT * from #accrows

	DELETE FROM MIK_ACCOUNTING20_SYN WHERE fis_tic_evrak_sira = @SaleId AND fis_hesap_kod = '99Z' 
	DELETE FROM MIK_ACCOUNTING20_SYN WHERE fis_tic_evrak_sira = @SaleId AND fis_hesap_kod LIKE '689%'
	DELETE FROM MIK_ACCOUNTING20_SYN WHERE fis_tic_evrak_sira = @SaleId AND fis_hesap_kod LIKE '391%'

	INSERT INTO MIK_ACCOUNTING20_SYN  
	(fis_Guid, fis_DBCno, fis_SpecRECno, fis_iptal, fis_fileid, fis_hidden, fis_kilitli, fis_degisti, fis_checksum, fis_create_user, fis_create_date  
	 , fis_lastup_user, fis_lastup_date, fis_special1, fis_special2, fis_special3, fis_firmano, fis_subeno, fis_maliyil, fis_tarih, fis_sira_no  
	 , fis_tur, fis_hesap_kod, fis_satir_no, fis_aciklama1, fis_meblag0, fis_meblag1, fis_meblag2, fis_meblag3, fis_meblag4, fis_meblag5, fis_meblag6  
	 , fis_sorumluluk_kodu, fis_ticari_tip, fis_ticari_uid, fis_kurfarkifl, fis_ticari_evraktip, fis_tic_evrak_seri, fis_tic_evrak_sira  
	 , fis_tic_belgeno, fis_tic_belgetarihi, fis_yevmiye_no, fis_katagori, fis_evrak_DBCno, fis_fmahsup_tipi, fis_aktif_pasif, fis_proje_kodu)  
	SELECT NEWID(), 0, 0, 0, 2, 0, 0, 0, 0, 10, GETDATE(), 10, GETDATE(), '', '', '', 0, 0, YEAR(@Day), @Day, @FisSiraNo, 1 fis_tur, ACCCODE, @maxno + ROW_NUMBER() OVER (ORDER BY ACCCODE) ROWNO, 
		   @fisaciklama1, AMOUNT fis_meblag0, AMOUNT / 5.7997 fis_meblag1, AMOUNT fis_meblag2, 0, 0, 0, 0, 
		   @sorumlulukmerkezikodu fis_sorumluluk_kodu, 2, @tranGUID, 0, @evraktip, @belgeSeri, @SaleId, @belgeNo fis_tic_belgeno,  @Day fis_tic_belgetarihi, @FisYevmiyeNo, 0, 0, 0, 0, ' '
	  from #accrows
	 where ACCCODE LIKE '391%'
	 


END