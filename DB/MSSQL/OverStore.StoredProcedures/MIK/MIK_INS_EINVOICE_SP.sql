CREATE PROCEDURE [dbo].[MIK_INS_EINVOICE_SP] @SaleInvoiceId BIGINT AS
BEGIN
	-- DECLARE @SaleInvoiceId BIGINT = 64
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

	DECLARE @tranGUID uniqueidentifier = NEWID();
	DECLARE @chaUUID uniqueidentifier = NEWID();

	INSERT INTO MIK_CURRENTTRANSACTION20_SYN
	(cha_Guid, cha_DBCno, cha_create_date, cha_evrakno_seri, cha_evrakno_sira, cha_satir_no, cha_tarihi, -- 7
	 cha_belge_tarih, cha_kod, cha_kasa_hizkod, cha_karsisrmrkkodu, cha_meblag, cha_aratoplam, -- 13
	 cha_vergipntr, cha_vergi1, cha_vergi2, cha_vergi3, cha_vergi4, cha_aciklama, cha_fis_tarih, -- 20 
	 ----------------------------------------
	 cha_SpecRecNo, cha_iptal, cha_fileid, cha_hidden, cha_kilitli, cha_degisti, cha_CheckSum, cha_create_user, -- 28
	 cha_lastup_user, cha_lastup_date, cha_firmano, cha_subeno, cha_evrak_tip, -- 33
	 cha_tip, cha_cinsi, cha_normal_Iade, cha_tpoz, cha_ticaret_turu, cha_belge_no, cha_satici_kodu, -- 40
	 cha_EXIMkodu, cha_projekodu, cha_yat_tes_kodu, cha_cari_cins, cha_ciro_cari_kodu, cha_d_cins, cha_d_kur, cha_altd_kur, 
	 cha_grupno, cha_srmrkkodu, cha_kasa_hizmet, cha_karsidcinsi, cha_karsid_kur, cha_karsidgrupno, cha_miktari, cha_vade,

	 cha_Vade_Farki_Yuz, cha_ft_iskonto1, cha_ft_iskonto2, cha_ft_iskonto3, cha_ft_iskonto4, cha_ft_iskonto5, cha_ft_iskonto6,
	 cha_ft_masraf1, cha_ft_masraf2, cha_ft_masraf3, cha_ft_masraf4, cha_isk_mas1, cha_isk_mas2, cha_isk_mas3, cha_isk_mas4,
	 cha_isk_mas5, cha_isk_mas6, cha_isk_mas7, cha_isk_mas8, cha_isk_mas9, cha_isk_mas10, cha_sat_iskmas1, cha_sat_iskmas2, 
	 cha_sat_iskmas3, cha_sat_iskmas4, cha_sat_iskmas5, cha_sat_iskmas6, cha_sat_iskmas7, cha_sat_iskmas8, cha_sat_iskmas9,
	 cha_sat_iskmas10, cha_yuvarlama, cha_StFonPntr, cha_stopaj, cha_savsandesfonu, cha_avansmak_damgapul, cha_vergi5,
	 cha_vergi6, cha_vergi7, cha_vergi8, cha_vergi9, cha_vergi10, cha_vergisiz_fl, cha_otvtutari, cha_otvvergisiz_fl, 
	 cha_oiv_pntr, cha_oivtutari, cha_oiv_vergi, cha_oivergisiz_fl, cha_fis_sirano, cha_trefno, cha_sntck_poz, -- (52)

	 cha_reftarihi, cha_istisnakodu, cha_pos_hareketi, cha_meblag_ana_doviz_icin_gecersiz_fl, cha_meblag_alt_doviz_icin_gecersiz_fl, 
	 cha_meblag_orj_doviz_icin_gecersiz_fl, cha_sip_uid, cha_kirahar_uid, cha_vardiya_tarihi, cha_vardiya_no, cha_vardiya_evrak_ti, 
	 cha_ebelge_turu, cha_tevkifat_toplam, cha_ilave_edilecek_kdv1, cha_ilave_edilecek_kdv2, cha_ilave_edilecek_kdv3, 
	 cha_ilave_edilecek_kdv4, cha_ilave_edilecek_kdv5, cha_ilave_edilecek_kdv6, cha_ilave_edilecek_kdv7, cha_ilave_edilecek_kdv8, 
	 cha_ilave_edilecek_kdv9, cha_ilave_edilecek_kdv10, cha_e_islem_turu, cha_fatura_belge_turu, cha_diger_belge_adi, cha_uuid, 
	 cha_adres_no, cha_vergifon_toplam, cha_ilk_belge_tarihi, cha_ilk_belge_doviz_kuru, cha_special1, cha_special2, cha_special3
	 )
	SELECT @tranGUID, 0, GETDATE(), @belgeSeri, SALE, 0, @Day, @Day, '100.01.'+RIGHT('000'+ISNULL(CAST(S.STORE AS VARCHAR(10)),''),3) CHAKOD,  -- 9
		   ' ' cha_kasa_hizkod, ' ' cha_karsisrmrkkodu, ABS(TOTAL_AMT), @totalNoWatAmount cha_aratoplam, 0 cha_vergipntr, 0, 0, ABS(TOTAL_AMT) - @totalNoWatAmount cha_vergi3, 0, -- 18
		   CONVERT(NVARCHAR(40), LEFT('FATURA : ' + CAST(SALE AS VARCHAR) + ' - ' + CONVERT(varchar(20), TRANSACTION_DT, 104), 40)), @Day, -- 20
		   0,0,51,0,1,0,0,10 cha_create_user,10,GETDATE(),0,0, @evraktip cha_evrak_tip, 0 CHATIP, @chacins, 0, 1, 0, @belgeNo, ' ' cha_satici_kodu, -- 40
		   ' ',' ',' ', 4 CHACARICINS, @AccountNo,0,1 cha_d_kur, 5.7997 cha_altd_kur, 0 CHAGRUPNO,@sorumlulukmerkezikodu,0,0, 1 cha_karsid_kur,0,0,0 cha_vade, -- (37)
		   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,@FisSiraNo, -- (50)
		   '',0,@emptydate,0,0,0,0,0,@emptyguid,@emptyguid,@emptydate,
		   0,0, 1 cha_ebelge_turu, 0,0,0,0,0,0,0,0,0,0,0,0 cha_e_islem_turu,0,'', @chaUUID, 1 cha_adres_no, 0,@emptydate,0, 'EFR' cha_special1, '', ''
	  FROM ACC_INVOICE I
	  JOIN SLS_SALE S ON I.SALE = S.SALEID
	 WHERE INVOICEID = @SaleInvoiceId;

	DECLARE @fisaciklama1 NVARCHAR(254) = 'Sat.fat : '+CAST(@SaleId AS VARCHAR)+'/'+CONVERT(VARCHAR, @Day, 104)+'/'+@AccountNo+'/'+LEFT(@AccountName,30)+'/100.01.'+RIGHT('000'+ISNULL(CAST(@StoreId AS VARCHAR(10)),''),3)+'/'+@StoreName;
	INSERT INTO MIK_ACCOUNTING20_SYN
	(fis_Guid, fis_DBCno, fis_SpecRECno, fis_iptal, fis_fileid, fis_hidden, fis_kilitli, fis_degisti, fis_checksum, fis_create_user, fis_create_date
	, fis_lastup_user, fis_lastup_date, fis_special1, fis_special2, fis_special3, fis_firmano, fis_subeno, fis_maliyil, fis_tarih, fis_sira_no
	, fis_tur, fis_hesap_kod, fis_satir_no, fis_aciklama1, fis_meblag0, fis_meblag1, fis_meblag2, fis_meblag3, fis_meblag4, fis_meblag5, fis_meblag6
	, fis_sorumluluk_kodu, fis_ticari_tip, fis_ticari_uid, fis_kurfarkifl, fis_ticari_evraktip, fis_tic_evrak_seri, fis_tic_evrak_sira
	, fis_tic_belgeno, fis_tic_belgetarihi, fis_yevmiye_no, fis_katagori, fis_evrak_DBCno, fis_fmahsup_tipi, fis_aktif_pasif, fis_proje_kodu)
	SELECT NEWID(), 0, 0, 0, 2, 0, 0, 0, 0, 10, GETDATE(), 10, GETDATE(), '', '', '', 0, 0, YEAR(@Day), @Day, @FisSiraNo, 1 fis_tur, ACCCODE, ROW_NUMBER() OVER (ORDER BY ACCCODE) ROWNO, 
		   @fisaciklama1, AMOUNT fis_meblag0, AMOUNT / 5.7997 fis_meblag1, AMOUNT fis_meblag2, 0, 0, 0, 0, 
		   @sorumlulukmerkezikodu fis_sorumluluk_kodu, 2, @tranGUID, 0, @evraktip, @belgeSeri, @SaleId, @belgeNo fis_tic_belgeno,  @Day fis_tic_belgetarihi, @FisYevmiyeNo, 0, 0, 0, 0, ' '
	  from #accrows
	
	DELETE FROM MIK_ACCOUNTINGDETAIL20_SYN WHERE mfd_evrak_seri = @belgeSeri and mfd_evrak_sira = @SaleId
	INSERT INTO MIK_ACCOUNTINGDETAIL20_SYN 
	(mfd_Guid, mfd_DBCno, mfd_SpecRECno, mfd_iptal, mfd_fileid, mfd_hidden, mfd_kilitli, mfd_degisti
	, mfd_checksum, mfd_create_user, mfd_create_date, mfd_lastup_user, mfd_lastup_date, mfd_ticari_tip
	, mfd_evraktip, mfd_evrak_seri, mfd_evrak_sira, mfd_bsbakonututar, mfd_bsbatabii, mfd_belgetarihi
	, mfd_tutarnereden, mfd_caritipi, mfd_belgeno, mfd_kdvid, mfd_kdvtutar, mfd_malhizmetmiktari, mfd_bsbakonuufrstutar
	, mfd_aciklama, mfd_caritutar, mfd_kisaevraktipi, mfd_satistipi, mfd_alistipi, mfd_tahtedtipi, mfd_digerevrakadi, mfd_evraktur
	, mfd_carikodu, mfd_carimuhkodu, mfd_cariunvan, mfd_carivergidaireadi, mfd_carivergidaireno, mfd_cariulkekodno)
	SELECT NEWID(), 0, 0, 0, 243, 0, 0, 0 mfd_degisti, 0, 10, GETDATE(), 10, GETDATE(), 2 mfd_ticari_tip	
		 , @evraktip mfd_evraktip, @belgeSeri, @SaleId, @totalNoWatAmount mfd_bsbakonututar, 1, @Day, 5 mfd_tutarnereden, 2 mfd_caritipi
		 , @belgeNo mfd_belgeno
		 , 0, @totalAmount - @totalNoWatAmount, 0, 0, N'' mfd_aciklama, @totalAmount mfd_caritutar, 1 mfd_kisaevraktipi, 0, 0, 0, N'Satış Faturası', 0
		 , @AccountNo, @cariMuhKodu, @AccountName, @VergiDaireAdi, @VergiDaireNo, '052' 

	INSERT INTO MIK_TRANSACTION20_SYN                  
    SELECT NEWID() sth_Guid, 0 sth_DBCno, 0 sth_SpecRECno, 0 sth_iptal, 16 sth_fileid, 0 sth_hidden, 1 sth_kilitli, 0 sth_degisti, 0 sth_checksum, 10 sth_create_user                      
      , GETDATE() sth_create_date, 10 sth_lastup_user, GETDATE() sth_lastup_date, '' sth_special1, '' sth_special2, '' sth_special3, 0 sth_firmano, 0 sth_subeno                      
      , @Day sth_tarih, 1 sth_tip, 0 sth_cins, 0 sth_normal_iade                    
      , 4 sth_evraktip, @belgeSeri sth_evrakno_seri, @SaleId sth_evrakno_sira, ROWNO-1 sth_satirno                      
      , '' sth_belge_no
	  , @Day sth_belge_tarih, PRODUCTCODE_NM sth_stok_kod
      , 0 sth_isk_mas1, 1 sth_isk_mas2, 1 sth_isk_mas3, 1 sth_isk_mas4, 1 sth_isk_mas5                       
      , 1 sth_isk_mas6, 1 sth_isk_mas7, 1 sth_isk_mas8, 1 sth_isk_mas9, 1 sth_isk_mas10                  
      , 0 sth_sat_iskmas1, 0 sth_sat_iskmas2, 0 sth_sat_iskmas3, 0 sth_sat_iskmas4, 0 sth_sat_iskmas5                  
      , 0 sth_sat_iskmas6, 0 sth_sat_iskmas7, 0 sth_sat_iskmas8, 0 sth_sat_iskmas9, 0 sth_sat_iskmas10                  
      , 0 sth_pos_satis, 0 sth_promosyon_fl, 0 sth_cari_cinsi                       
      , @AccountNo sth_cari_kodu, 0 sth_cari_grup_no, '' sth_isemri_gider_kodu, '' sth_plasiyer_kodu                  
      , 0 sth_har_doviz_cinsi, 1 sth_har_doviz_kuru, 5.7997 sth_alt_doviz_kuru, 0 sth_stok_doviz_cinsi                       
      , 1 sth_stok_doviz_kuru, QUANTITY sth_miktar, QUANTITY sth_miktar2, 1 sth_birim_pntr, PRICENOWAT sth_tutar                  
      , 0 sth_iskonto1, 0 sth_iskonto2, 0 sth_iskonto3, 0 sth_iskonto4, 0 sth_iskonto5, 0 sth_iskonto6                  
      , 0 sth_masraf1, 0 sth_masraf2, 0 sth_masraf3, 0 sth_masraf4, VATGROUP_CD sth_vergi_pntr, PRICE-PRICENOWAT sth_vergi                      
      , 0 sth_masraf_vergi_pntr, 0 sth_masraf_vergi, 0 sth_netagirlik, '0' sth_odeme_op                  
      , '' sth_aciklama, @emptyguid sth_sip_uid, @tranGUID sth_fat_uid                       
      , STORE sth_giris_depo_no, STORE sth_cikis_depo_no
      , @Day sth_malkbl_sevk_tarihi, @sorumlulukmerkezikodu sth_cari_srm_merkezi, @sorumlulukmerkezikodu sth_stok_srm_merkezi, @Day sth_fis_tarihi                      
      , @FisSiraNo sth_fis_sirano, 0 sth_vergisiz_fl, 0 sth_maliyet_ana, 0 sth_maliyet_alternatif, 0 sth_maliyet_orjinal                  
      , 1 sth_adres_no, '' sth_parti_kodu, 0 sth_lot_no         
      , @emptyguid sth_kons_uid, '' sth_proje_kodu, '' sth_exim_kodu, 0 sth_otv_pntr, 0 sth_otv_vergi, 0 sth_brutagirlik             
      , 0 sth_disticaret_turu, 0 sth_otvtutari, 0 sth_otvvergisiz_fl                       
      , 0 sth_oiv_pntr, 0 sth_oiv_vergi, 0 sth_oivvergisiz_fl, 0 sth_fiyat_liste_no, 0 sth_oivtutari, 0 sth_Tevkifat_turu, 0 sth_nakliyedeposu, 0 sth_nakliyedurumu                      
      , @emptyguid sth_yetkili_uid, 0 sth_taxfree_fl, 0 sth_ilave_edilecek_kdv, '' sth_ismerkezi_kodu, '' sth_HareketGrupKodu1, '' sth_HareketGrupKodu2, '' sth_HareketGrupKodu3                       
      , 0 sth_Olcu1, 0 sth_Olcu2, 0 sth_Olcu3, 0 sth_Olcu4, 0 sth_Olcu5, 0 sth_FormulMiktarNo, 0 sth_FormulMiktar                      
      FROM #transactions

	INSERT INTO MIK_EFATURAISLEMLERI_SYN
	( efi_Guid, efi_DBCno, efi_SpecRECno, efi_iptal, efi_fileid, efi_hidden, efi_kilitli, efi_degisti, efi_checksum, efi_create_user
	, efi_create_date, efi_lastup_user, efi_lastup_date, efi_special1, efi_special2, efi_special3, efi_tip, efi_evrakno_seri, efi_evrakno_sira
	, efi_evrak_tipi, efi_gib_seri_sira, efi_uuid, efi_onaylandi_fl, efi_OnaylayanKulNo, efi_onaylama_tarihi, efi_islem_tipi, efi_yazdirma_sayisi
	, efi_efaturaolustu_fl, efi_efaturaolusturanKulNo, efi_efaturaolusturmatarihi, efi_kabuledildi_fl, efi_kabuledenKulNo, efi_kabuletme_tarihi
	, efi_rededildi_fl, efi_rededenKulNo, efi_rededilme_tarihi, efi_gonderildi_fl, efi_gonderenKulNo, efi_gonderim_tarihi, efi_baglama_fl, efi_baglayanKulNo
	, efi_baglama_tarihi, efi_bagsil_fl, efi_bagsilenKulNo, efi_bagisil_tarihi, efi_icerikabul_fl, efi_icerikabuledenKulNo, efi_icerikabul_tarihi
	, efi_yazdirma_fl, efi_YazdiranKulNo, efi_Yazdirma_tarihi, efi_efaturaislem_tipi, efi_fpgonderildi_fl, efi_fpgonderenKulNo, efi_fpgonderim_tarihi
	, efi_Iptal_fl, efi_IptaledenKulNo, efi_Iptal_tarihi, efi_Earsiv_iptal_nedeni, efi_Earsiv_iptal_tarihi)
	VALUES
	( NEWID(), 0, 0, 0, 559, 0, 0, 0, 0, 8, 
	  GETDATE(), 8, GETDATE(), '', '', '', 0, @belgeSeri, @SaleId, 
	  63, '', @chaUUID, 0, 0, @emptydate, 0, 0, 
	  1, 8, GETDATE(), 0, 0, @emptydate, 
	  0, 0, @emptydate, 0, 0, @emptydate, 0, 0,
	  @emptydate, 0, 0, @emptydate, 0, 0, @emptydate,
	  0, 0, @emptydate, 1, 0, 0, @emptydate, 
	  0, 0, @emptydate, '', @emptydate)

	/*
	INSERT INTO MIK_EFATURADETAYLARI_SYN
	( efd_Guid, efd_DBCno, efd_SpecRECno, efd_iptal, efd_fileid, efd_hidden, efd_kilitli, efd_degisti, efd_checksum, efd_create_user, efd_create_date, efd_lastup_user, 
	  efd_lastup_date, efd_special1, efd_special2, efd_special3, efd_firmano, efd_tipi, efd_gib_seri, efd_gib_sira, efd_uuid, efd_fat_uid, efd_pozisyon, efd_mVkn)
	VALUES
	( NEWID(), 0, 0, 0, 558, 0, 0, 0, 0, 8, GETDATE(), 8, 
	  GETDATE(), '', '', '', 0, CASE WHEN @efatura = 'MAK' THEN 1 ELSE 2 END, -- efd_tipi 
	  -- LEFT(@belgeNo, 7) /*efd_gib_seri*/, CAST(SUBSTRING(@belgeNo,8, 9) AS INT), -- efd_gib_sira, 
	  NULL, NULL,
	  @chaUUID, @tranGUID, 0, @VergiDaireNo) */

	INSERT INTO MIK_EVRAKACIKLAMALARI_SYN
	(egk_Guid, egk_DBCno, egk_SpecRECno, egk_iptal, egk_fileid, egk_hidden, egk_kilitli, egk_degisti, egk_checksum, egk_create_user, egk_create_date, egk_lastup_user, egk_lastup_date
	, egk_special1, egk_special2, egk_special3, egk_dosyano, egk_hareket_tip, egk_evr_tip, egk_evr_seri, egk_evr_sira, egk_evr_ustkod, egk_evr_doksayisi, egk_evracik1, egk_evracik2
	, egk_evracik3, egk_evracik4, egk_evracik5, egk_evracik6, egk_evracik7, egk_evracik8, egk_evracik9, egk_evracik10, egk_sipgenkarorani, egk_kargokodu, egk_kargono, egk_tesaltarihi
	, egk_tesalkisi, egk_prevwiewsayisi, egk_emailsayisi, egk_Evrakopno_verildi_fl)
	VALUES
	( NEWID(), 0, 0, 0, 66, 0, 0, 0, 0, 8, GETDATE(), 8, GETDATE(), 
	  '', '', '', 51, 0, 63, @belgeSeri, @SaleId, '', 0, @StoreName, '',
	  '', '', '', '', '', '', '', '', 0, '', '', @emptydate,
	  '', 0, 0, 0)

	UPDATE B 
	   SET B.MIKRO_TM = GETDATE(),
		   B.UPDATEUSER = ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1),
		   B.UPDATE_DT = GETDATE(),
		   B.STATUS_CD = 2,
		   B.MIKRO_FL = 'Y'
	  FROM ACC_INVOICE B
	 WHERE B.INVOICEID = @SaleInvoiceId

END