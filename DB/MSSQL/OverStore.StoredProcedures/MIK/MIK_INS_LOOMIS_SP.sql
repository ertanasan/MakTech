CREATE PROCEDURE MIK_INS_LOOMIS_SP @Day DATE, @LoomisIdList VARCHAR(MAX) AS
BEGIN
	-- RETURN;
	-- DECLARE @ExpenseIdList VARCHAR(MAX) = '1038,1095,1102'
	-- BEGIN TRANSACTION
	-- DECLARE @Day DATE = CONVERT(DATE, '20190806', 112);
	DECLARE @FisSiraNo INT, @FisYevmiyeNo INT, @TranNo BIGINT 

	DECLARE @emptyguid nvarchar(40)                      
	SET @emptyguid = '00000000-0000-0000-0000-000000000000';                      
	DECLARE @emptydate datetime, @saleDate DATE;                      
	SET @emptydate = CONVERT(DATETIME, '18991230', 112);         
	SELECT @saleDate = @Day
	DECLARE @evraktip INT = 33
	
	SELECT @TranNo = ISNULL(MAX(cha_evrakno_sira),0)+1 FROM MIK_CURRENTTRANSACTION20_SYN WHERE cha_evrakno_seri = 'MML'
	SELECT @FisSiraNo = ISNULL(MAX(fis_sira_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_tarih = @saleDate;  -- fis_firmano = 0 AND fis_maliyil = YEAR(@today); -- AND 
	SELECT @FisYevmiyeNo = ISNULL(MAX(fis_yevmiye_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@saleDate); -- AND fis_tarih = @today;  
	-- SELECT @TranNo, @FisSiraNo, @FisYevmiyeNo
	 
	IF OBJECT_ID('tempdb..#transactions') IS NOT NULL DROP TABLE #transactions
	IF OBJECT_ID('tempdb..#accrows') IS NOT NULL DROP TABLE #accrows
	IF OBJECT_ID('tempdb..#list') IS NOT NULL DROP TABLE #list

	SELECT * INTO #list FROM [dbo].[SYS_CSVTOTABLE_SP] (@LoomisIdList,',')

	SELECT *, ROW_NUMBER() OVER (ORDER BY LEFT(CHAKOD,3) DESC, STORE) ROWNO
	  INTO #transactions
	  FROM (
	SELECT NEWID() GUID1, L.LOOMISID, L.ACTUAL_AMT, L.STORE, ST.STORE_NM
		 , 1 CHATIP, 4 CHACARICINS, 0 CHAGRUPNO, ISNULL(PROP.VALUE_TXT, '100.01.'+RIGHT('000'+ISNULL(CAST(L.STORE AS VARCHAR(10)),''),3)) CHAKOD
	  FROM ACC_LOOMIS L
	  JOIN STR_STORE ST ON L.STORE = ST.STOREID
	  LEFT JOIN STR_PROPERTY PROP ON PROP.PROPERTYTYPE = 10 AND PROP.STORE = ST.STOREID
	 WHERE SALE_DT = @Day
	   AND (LEN(ISNULL(@LoomisIdList,'')) = 0 OR L.LOOMISID IN (SELECT String FROM #list))
	   AND L.MIKROSTATUS_CD = 0
	 UNION ALL
	SELECT NEWID() GUID1, L.LOOMISID, L.ACTUAL_AMT, L.STORE, ST.STORE_NM
	     , 0 CHATIP, 4 CHACARICINS, 0 CHAGRUPNO, '100.01.999' CHAKOD
	  FROM ACC_LOOMIS L
	  JOIN STR_STORE ST ON L.STORE = ST.STOREID
	 WHERE SALE_DT = @Day
	   AND (LEN(ISNULL(@LoomisIdList,'')) = 0 OR L.LOOMISID IN (SELECT String FROM #list))
	   AND L.MIKROSTATUS_CD = 0
	 ) A

	SELECT *, ROW_NUMBER() OVER (ORDER BY LEFT(CHAKOD,3) DESC, STORE) ROWNO
	  INTO #accrows
	  FROM (
	SELECT *, 
		   CASE WHEN CHAKOD != '100.01.999' THEN '100.02.001' ELSE '127.01.001' END ACCCODE,
		   CASE WHEN CHAKOD != '100.01.999' THEN -1*STORETOTAL ELSE STORETOTAL END AMOUNT,
		   CONVERT(NVARCHAR(120), 'Gn.Vir.Dek. : MML-'+CAST(@TranNo AS VARCHAR(20))+'/'+CONVERT(VARCHAR(30), @saleDate, 104)+'/Kasadan Loomis Verilen/'+CHAKOD+'/'+STORE_NM, 120) DESC1
	  FROM (
	SELECT CHAKOD, STORE, STORE_NM, SUM(ACTUAL_AMT) STORETOTAL, MIN(GUID1) TRANGUID
	  FROM #transactions
	 GROUP BY CHAKOD, STORE, STORE_NM) A ) B

	INSERT INTO MIK_CURRENTTRANSACTION20_SYN
	(cha_Guid, cha_DBCno, cha_create_date, cha_evrakno_seri, cha_evrakno_sira, cha_satir_no, cha_tarihi, 
	 cha_belge_tarih, cha_kod, cha_kasa_hizkod, cha_karsisrmrkkodu, cha_meblag, cha_aratoplam,
	 cha_vergipntr, cha_vergi1, cha_vergi2, cha_vergi3, cha_vergi4, cha_aciklama, cha_fis_tarih, 
	 ----------------------------------------
	 cha_SpecRecNo, cha_iptal, cha_fileid, cha_hidden, cha_kilitli, cha_degisti, cha_CheckSum, cha_create_user, 
	 cha_lastup_user, cha_lastup_date, cha_firmano, cha_subeno, cha_evrak_tip,
	 cha_tip, cha_cinsi, cha_normal_Iade, cha_tpoz, cha_ticaret_turu, cha_belge_no, cha_satici_kodu,
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
	 cha_adres_no, cha_vergifon_toplam, cha_ilk_belge_tarihi, cha_ilk_belge_doviz_kuru
	 )
	SELECT GUID1, 0, GETDATE(), 'MML', @TranNo, ROWNO, @saleDate, @saleDate, CHAKOD, ' ' cha_kasa_hizkod, 
	 ' ' cha_karsisrmrkkodu, ACTUAL_AMT, 0 cha_aratoplam, 0 cha_vergipntr, 0, 0, 0, 0, 
	 CONVERT(NVARCHAR(40), LEFT('Kasadan Loomis Verilen', 40)) cha_aciklama, @saleDate,
	 0,0,51,0,0,0,0,10 cha_create_user,10,GETDATE(),0,0, @evraktip cha_evrak_tip, CHATIP,5,0,0,0,' ',' ' cha_satici_kodu,
	 ' ',' ',' ',CHACARICINS,' ',0,1,5.7997 cha_altd_kur,CHAGRUPNO,' ',0,0,1,0,0,0 cha_vade, -- (37)
	 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,@FisSiraNo, -- (50)
	 null,0,@emptydate,0,0,0,0,0,@emptyguid,@emptyguid,@emptydate,
	 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,null,@emptyguid,0,0,@emptydate,0
	  FROM #transactions;

	INSERT INTO MIK_ACCOUNTING20_SYN
	(fis_Guid, fis_DBCno, fis_SpecRECno, fis_iptal, fis_fileid, fis_hidden, fis_kilitli, fis_degisti, fis_checksum, fis_create_user, fis_create_date
	, fis_lastup_user, fis_lastup_date, fis_firmano, fis_subeno, fis_maliyil, fis_tarih, fis_sira_no
	, fis_tur, fis_hesap_kod, fis_satir_no, fis_aciklama1, fis_meblag0, fis_meblag1, fis_meblag2, fis_meblag3, fis_meblag4, fis_meblag5, fis_meblag6
	, fis_sorumluluk_kodu, fis_ticari_tip, fis_ticari_uid, fis_kurfarkifl, fis_ticari_evraktip, fis_tic_evrak_seri, fis_tic_evrak_sira
	, fis_tic_belgetarihi, fis_yevmiye_no, fis_katagori, fis_evrak_DBCno, fis_fmahsup_tipi, fis_aktif_pasif, fis_proje_kodu)
	SELECT NEWID(), 0, 0, 0, 2, 0, 0, 0, 0, 10, GETDATE(), 10, GETDATE(), 0, 0, YEAR(@saleDate), @saleDate, @FisSiraNo, 0 fis_tur, ACCCODE, ROWNO, DESC1, 
		   AMOUNT fis_meblag0, AMOUNT / 5.7997 fis_meblag1, AMOUNT fis_meblag2, 0, 0, 0, 0, 
		   ' 'fis_sorumluluk_kodu, 2, TRANGUID, 0, @evraktip, 'MML', @TranNo, @saleDate fis_tic_belgetarihi, @FisYevmiyeNo, 0, 0, 0, 0, ' '
	  from #accrows
	
	DELETE FROM MIK_ACCOUNTINGDETAIL20_SYN WHERE mfd_evrak_seri = 'MML' and mfd_evrak_sira = @TranNo
	INSERT INTO MIK_ACCOUNTINGDETAIL20_SYN 
	(mfd_Guid, mfd_DBCno, mfd_SpecRECno, mfd_iptal, mfd_fileid, mfd_hidden, mfd_kilitli, mfd_degisti
	, mfd_checksum, mfd_create_user, mfd_create_date, mfd_lastup_user, mfd_lastup_date, mfd_ticari_tip
	, mfd_evraktip, mfd_evrak_seri, mfd_evrak_sira, mfd_bsbakonututar, mfd_bsbatabii, mfd_belgetarihi
	, mfd_tutarnereden, mfd_caritipi, mfd_belgeno, mfd_kdvid, mfd_kdvtutar, mfd_malhizmetmiktari, mfd_bsbakonuufrstutar
	, mfd_aciklama, mfd_caritutar, mfd_kisaevraktipi, mfd_satistipi, mfd_alistipi, mfd_tahtedtipi, mfd_digerevrakadi, mfd_evraktur)
	SELECT NEWID(), 0, 0, 0, 243, 0, 0, 0 mfd_degisti, 0, 10, GETDATE(), 10, GETDATE(), 2 mfd_ticari_tip	
		 , @evraktip mfd_evraktip, 'MML', @TranNo, 0 mfd_bsbakonututar, 0, @saleDate, 0 mfd_tutarnereden, 0, CONVERT(NVARCHAR(20), LEFT('Kasadan Loomis Verilen',20)) mfd_belgeno
		 , 0, 0, 0, 0, N'Kasadan Loomis Verilen', 0 mfd_caritutar, 5 mfd_kisaevraktipi, 0, 0, 0, N'Genel Amaçlı Virman Dekontu', 0
	
	UPDATE B 
	   SET B.MIKROTRANCODE_TXT = 'MML - '+CAST(@TranNo AS VARCHAR(20)),
		   B.MIKRO_TM = GETDATE(),
		   B.UPDATEUSER = ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1),
		   B.UPDATE_DT = GETDATE(),
		   B.MIKROSTATUS_CD = 1
	  FROM ACC_LOOMIS B
	  JOIN #transactions X ON B.LOOMISID = X.LOOMISID

END