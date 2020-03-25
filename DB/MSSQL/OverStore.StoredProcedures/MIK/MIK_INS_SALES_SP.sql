CREATE PROCEDURE MIK_INS_SALES_SP @StoreId INT, @Date DATE AS
BEGIN

	-- DECLARE @StoreId INT = 3
	-- DECLARE @Date DATE = '2020-02-01'

	-- o güne ait önceden aktarılmış veriler varsa sil
	DECLARE @StoreString VARCHAR(3)= REPLACE(STR(@StoreId, 3), SPACE(1), '0')
	DELETE FROM MIK_TRANSACTION20_SYN WHERE sth_evrakno_seri = 'P'+ @StoreString AND sth_evrakno_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_TRANSACTION20_SYN WHERE sth_evrakno_seri = 'C'+ @StoreString AND sth_evrakno_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_CURRENTTRANSACTION20_SYN WHERE cha_evrakno_seri = 'P'+ @StoreString AND cha_evrakno_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_CURRENTTRANSACTION20_SYN WHERE cha_evrakno_seri = 'C'+ @StoreString AND cha_evrakno_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_ACCOUNTING20_SYN WHERE fis_tic_evrak_seri = 'P'+ @StoreString AND fis_tic_evrak_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_ACCOUNTING20_SYN WHERE fis_tic_evrak_seri = 'C'+ @StoreString AND fis_tic_evrak_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_ACCOUNTINGDETAIL20_SYN WHERE mfd_evrak_seri = 'P'+ @StoreString AND mfd_evrak_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)
	DELETE FROM MIK_ACCOUNTINGDETAIL20_SYN WHERE mfd_evrak_seri = 'C'+ @StoreString AND mfd_evrak_sira = CAST(CONVERT(VARCHAR, @Date, 112) AS INT)

	DECLARE @fatUid nvarchar(40) = NEWID()
	DECLARE @IadefatUid nvarchar(40) = NEWID()
	DECLARE @fisSirano INT
	DECLARE @IadefisSirano INT
	SELECT @fisSiraNo = ISNULL(MAX(fis_sira_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_tarih = @Date;
	SET @IadefisSirano = @fisSiraNo + 1

	DECLARE @YevmiyeNo INT
	DECLARE @IadeYevmiyeNo INT
	SELECT @YevmiyeNo = ISNULL(MAX(fis_yevmiye_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@Date); 
	SET @IadeYevmiyeNo = @YevmiyeNo + 1
	
	

	IF OBJECT_ID('tempdb..#MIKTRASANCTION') IS NOT NULL DROP TABLE #MIKTRASANCTION
	IF OBJECT_ID('tempdb..#MIKCURRENTTRANSACTION') IS NOT NULL DROP TABLE #MIKCURRENTTRANSACTION
	IF OBJECT_ID('tempdb..#MIKACCOUNTING') IS NOT NULL DROP TABLE #MIKACCOUNTING
	
	SELECT *, ROW_NUMBER() OVER (PARTITION BY EVRAKNOSERI ORDER BY STOKKOD) - 1 SATIRNO
	  INTO #MIKTRASANCTION
	  FROM (
	SELECT @Date TARIH, CASE WHEN TRANSACTIONTYPE = 5 THEN 'C' ELSE 'P' END + @StoreString EVRAKNOSERI
		 , CASE WHEN TRANSACTIONTYPE = 5 THEN 0 ELSE 1 END TIP, CASE WHEN TRANSACTIONTYPE = 5 THEN 1 ELSE 0 END NORMALIADE
		 , CASE WHEN TRANSACTIONTYPE = 5 THEN 3 ELSE 4 END EVRAKTIP, CASE WHEN TRANSACTIONTYPE = 5 THEN @StoreId ELSE 1 END GIRISDEPO
		 , CASE WHEN TRANSACTIONTYPE = 5 THEN 1 ELSE @StoreId END CIKISDEPO
		 , CAST(CONVERT(VARCHAR, @Date, 112) AS INT) EVRAKNOSIRA, PRODUCTCODE_NM STOKKOD
		 , '120.99.999' CARIKODU, 5.7997 DOVIZKURU, SUM(QUANTITY_QTY) MIKTAR
		 , SUM(PRICE - VAT_AMT) TUTAR, VATGROUP_CD VERGIPNTR, SUM(VAT_AMT) VERGI, MAX(BARCODE_TXT) ACIKLAMA
		 , '00000000-0000-0000-0000-000000000000' EMPTYUID, CASE WHEN TRANSACTIONTYPE = 5 THEN @IadefatUid ELSE @fatUid END FATUID
		 , '20100'+ @StoreString SORUMLULUKMERKEZI
		 , CASE WHEN TRANSACTIONTYPE = 5 THEN @IadefisSirano ELSE @fisSirano END FISSIRANO
	  FROM MIK_SALES_FN(@StoreId, @Date)
	 GROUP BY TRANSACTIONTYPE, PRODUCTCODE_NM, VATGROUP_CD) A

	INSERT INTO MIK_TRANSACTION20_SYN
	( sth_Guid, sth_DBCno, sth_SpecRECno, sth_iptal, sth_fileid, sth_hidden, sth_kilitli, sth_degisti, sth_checksum, sth_create_user, sth_create_date
	, sth_lastup_user, sth_lastup_date, sth_special1, sth_special2, sth_special3, sth_firmano, sth_subeno, sth_tarih, sth_tip, sth_cins, sth_normal_iade
	, sth_evraktip, sth_evrakno_seri, sth_evrakno_sira, sth_satirno, sth_belge_no, sth_belge_tarih, sth_stok_kod, sth_isk_mas1, sth_isk_mas2, sth_isk_mas3
	, sth_isk_mas4, sth_isk_mas5, sth_isk_mas6, sth_isk_mas7, sth_isk_mas8, sth_isk_mas9, sth_isk_mas10, sth_sat_iskmas1, sth_sat_iskmas2, sth_sat_iskmas3
	, sth_sat_iskmas4, sth_sat_iskmas5, sth_sat_iskmas6, sth_sat_iskmas7, sth_sat_iskmas8, sth_sat_iskmas9, sth_sat_iskmas10, sth_pos_satis, sth_promosyon_fl
	, sth_cari_cinsi, sth_cari_kodu, sth_cari_grup_no, sth_isemri_gider_kodu, sth_plasiyer_kodu, sth_har_doviz_cinsi, sth_har_doviz_kuru, sth_alt_doviz_kuru
	, sth_stok_doviz_cinsi, sth_stok_doviz_kuru, sth_miktar, sth_miktar2, sth_birim_pntr, sth_tutar, sth_iskonto1, sth_iskonto2, sth_iskonto3, sth_iskonto4
	, sth_iskonto5, sth_iskonto6, sth_masraf1, sth_masraf2, sth_masraf3, sth_masraf4, sth_vergi_pntr, sth_vergi, sth_masraf_vergi_pntr, sth_masraf_vergi
	, sth_netagirlik, sth_odeme_op, sth_aciklama, sth_sip_uid, sth_fat_uid, sth_giris_depo_no, sth_cikis_depo_no, sth_malkbl_sevk_tarihi, sth_cari_srm_merkezi
	, sth_stok_srm_merkezi, sth_fis_tarihi, sth_fis_sirano, sth_vergisiz_fl, sth_maliyet_ana, sth_maliyet_alternatif, sth_maliyet_orjinal, sth_adres_no
	, sth_parti_kodu, sth_lot_no, sth_kons_uid, sth_proje_kodu, sth_exim_kodu, sth_otv_pntr, sth_otv_vergi, sth_brutagirlik, sth_disticaret_turu, sth_otvtutari
	, sth_otvvergisiz_fl, sth_oiv_pntr, sth_oiv_vergi, sth_oivvergisiz_fl, sth_fiyat_liste_no, sth_oivtutari, sth_Tevkifat_turu, sth_nakliyedeposu
	, sth_nakliyedurumu, sth_yetkili_uid, sth_taxfree_fl, sth_ilave_edilecek_kdv, sth_ismerkezi_kodu, sth_HareketGrupKodu1, sth_HareketGrupKodu2
	, sth_HareketGrupKodu3, sth_Olcu1, sth_Olcu2, sth_Olcu3, sth_Olcu4, sth_Olcu5, sth_FormulMiktarNo, sth_FormulMiktar)
	SELECT NEWID(), 0, 0, 0, 16, 0, 0, 0, 0, 25, GETDATE() -- sth_create_date
	, 25, GETDATE(), '', '', '', 0, 0, TARIH, TIP, 1, NORMALIADE -- sth_normal_iade
	, EVRAKTIP, EVRAKNOSERI, EVRAKNOSIRA, SATIRNO, '', TARIH, STOKKOD, 0, 0, 0 -- sth_isk_mas3
	, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 -- sth_sat_iskmas3
	, 0, 0, 0, 0, 0, 0, 0, 1, 0 -- sth_promosyon_fl
	, 0, CARIKODU, 0, '', '', 0, 1, DOVIZKURU -- sth_alt_doviz_kuru
	, 0, 1, MIKTAR, 0, 1, TUTAR, 0, 0, 0, 0 -- sth_iskonto4
	, 0, 0, 0, 0, 0, 0, VERGIPNTR, VERGI, 0, 0 -- sth_masraf_vergi
	, 0, 0, ACIKLAMA, EMPTYUID, FATUID, GIRISDEPO, CIKISDEPO, TARIH, SORUMLULUKMERKEZI -- sth_cari_srm_merkezi
	, SORUMLULUKMERKEZI, TARIH, FISSIRANO, 0, 0, 0, 0, 0 -- sth_adres_no
	, '', 0, EMPTYUID, '', '', 0, 0, 0, 1, 0 -- sth_otvtutari
	, 0, 0, 0, 0, 0, 0, 0, 0 -- sth_nakliyedeposu
	, 0, EMPTYUID, 0, 0, '', '', '' -- sth_HareketGrupKodu2
	, '', 0, 0, 0, 0, 0, 0, 0 -- sth_FormulMiktar
	  FROM #MIKTRASANCTION

	DECLARE @CHAUUID NVARCHAR(40) = NEWID()
	DECLARE @ACIKLAMA NVARCHAR(80)
	SELECT @ACIKLAMA = CONVERT(NVARCHAR(10), @Date, 104)+', '+STORE_NM FROM STR_STORE WHERE STOREID = @StoreId
	DECLARE @BOSTARIH DATE = CONVERT(DATE, '18991230', 112)
	SELECT FATUID, EVRAKNOSERI, EVRAKNOSIRA, NORMALIADE
		 , CASE WHEN NORMALIADE =  0 THEN 63 ELSE 0 END EVRAKTIP
		 , CASE WHEN NORMALIADE =  0 THEN 0 ELSE 1 END TIP
		 , TARIH, @ACIKLAMA ACIKLAMA, '100.01.'+@StoreString CHAKOD
		 , CARIKODU, SORUMLULUKMERKEZI, FISSIRANO
		 , @BOSTARIH BOSTARIH, EMPTYUID, @CHAUUID CHAUUID
		 , CASE WHEN NORMALIADE =  0 THEN 3 ELSE 11 END FATURABELGETURU
		 , CASE WHEN NORMALIADE =  0 THEN 'Z Raporu' ELSE 'Stok gider pusulası' END DIGERBELGEADI
		 , SUM(TUTAR + VERGI) MEBLAG, SUM(TUTAR) ARATOPLAM
		 , SUM(CASE WHEN VERGIPNTR = 2 THEN VERGI ELSE 0 END) GROUP2VERGI
		 , SUM(CASE WHEN VERGIPNTR = 3 THEN VERGI ELSE 0 END) GROUP3VERGI
		 , SUM(CASE WHEN VERGIPNTR = 4 THEN VERGI ELSE 0 END) GROUP4VERGI
	  INTO #MIKCURRENTTRANSACTION
	  FROM #MIKTRASANCTION
     GROUP BY FATUID, EVRAKNOSERI, EVRAKNOSIRA, NORMALIADE, TARIH, CARIKODU, SORUMLULUKMERKEZI, FISSIRANO, EMPTYUID
	
	-- SELECT * FROM #MIKCURRENTTRANSACTION
	INSERT INTO MIK_CURRENTTRANSACTION20_SYN
	( cha_Guid, cha_DBCno, cha_SpecRecNo, cha_iptal, cha_fileid, cha_hidden, cha_kilitli, cha_degisti, cha_CheckSum, cha_create_user, cha_create_date
	, cha_lastup_user, cha_lastup_date, cha_special1, cha_special2, cha_special3, cha_firmano, cha_subeno, cha_evrak_tip, cha_evrakno_seri, cha_evrakno_sira
	, cha_satir_no, cha_tarihi, cha_tip, cha_cinsi, cha_normal_Iade, cha_tpoz, cha_ticaret_turu, cha_belge_no, cha_belge_tarih, cha_aciklama, cha_satici_kodu
	, cha_EXIMkodu, cha_projekodu, cha_yat_tes_kodu, cha_cari_cins, cha_kod, cha_ciro_cari_kodu, cha_d_cins, cha_d_kur, cha_altd_kur, cha_grupno, cha_srmrkkodu
	, cha_kasa_hizmet, cha_kasa_hizkod, cha_karsidcinsi, cha_karsid_kur, cha_karsidgrupno, cha_karsisrmrkkodu, cha_miktari, cha_meblag, cha_aratoplam
	, cha_vade, cha_Vade_Farki_Yuz, cha_ft_iskonto1, cha_ft_iskonto2, cha_ft_iskonto3, cha_ft_iskonto4, cha_ft_iskonto5, cha_ft_iskonto6, cha_ft_masraf1
	, cha_ft_masraf2, cha_ft_masraf3, cha_ft_masraf4, cha_isk_mas1, cha_isk_mas2, cha_isk_mas3, cha_isk_mas4, cha_isk_mas5, cha_isk_mas6, cha_isk_mas7
	, cha_isk_mas8, cha_isk_mas9, cha_isk_mas10, cha_sat_iskmas1, cha_sat_iskmas2, cha_sat_iskmas3, cha_sat_iskmas4, cha_sat_iskmas5, cha_sat_iskmas6
	, cha_sat_iskmas7, cha_sat_iskmas8, cha_sat_iskmas9, cha_sat_iskmas10, cha_yuvarlama, cha_StFonPntr, cha_stopaj, cha_savsandesfonu, cha_avansmak_damgapul
	, cha_vergipntr, cha_vergi1, cha_vergi2, cha_vergi3, cha_vergi4, cha_vergi5, cha_vergi6, cha_vergi7, cha_vergi8, cha_vergi9, cha_vergi10, cha_vergisiz_fl
	, cha_otvtutari, cha_otvvergisiz_fl, cha_oiv_pntr, cha_oivtutari, cha_oiv_vergi, cha_oivergisiz_fl, cha_fis_tarih, cha_fis_sirano, cha_trefno, cha_sntck_poz
	, cha_reftarihi, cha_istisnakodu, cha_pos_hareketi, cha_meblag_ana_doviz_icin_gecersiz_fl, cha_meblag_alt_doviz_icin_gecersiz_fl, cha_meblag_orj_doviz_icin_gecersiz_fl
	, cha_sip_uid, cha_kirahar_uid, cha_vardiya_tarihi, cha_vardiya_no, cha_vardiya_evrak_ti, cha_ebelge_turu, cha_tevkifat_toplam, cha_ilave_edilecek_kdv1
	, cha_ilave_edilecek_kdv2, cha_ilave_edilecek_kdv3, cha_ilave_edilecek_kdv4, cha_ilave_edilecek_kdv5, cha_ilave_edilecek_kdv6, cha_ilave_edilecek_kdv7
	, cha_ilave_edilecek_kdv8, cha_ilave_edilecek_kdv9, cha_ilave_edilecek_kdv10, cha_e_islem_turu, cha_fatura_belge_turu, cha_diger_belge_adi, cha_uuid
	, cha_adres_no, cha_vergifon_toplam, cha_ilk_belge_tarihi, cha_ilk_belge_doviz_kuru, cha_HareketGrupKodu1, cha_HareketGrupKodu2, cha_HareketGrupKodu3 )
	SELECT FATUID, 0, 0, 0, 51, 0, 0, 0, 0, 25, GETDATE() -- cha_create_date
	, 25, GETDATE(), '', '', '', 0, 0, EVRAKTIP, EVRAKNOSERI, EVRAKNOSIRA -- cha_evrakno_sira
	, 0, TARIH, TIP, 7, NORMALIADE, 1, 1, '', TARIH, ACIKLAMA, '' -- cha_satici_kodu
	, '', '', '', 4, CHAKOD, CARIKODU, 0, 1, 5.7997, 0, SORUMLULUKMERKEZI -- cha_srmrkkodu
	, 0, '', 0, 1, 0, '', 0, MEBLAG, ARATOPLAM -- cha_aratoplam
	, 0, 0, 0, 0, 0, 0, 0, 0, 0 -- cha_ft_masraf1
	, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 -- cha_isk_mas7
	, 0, 0, 0, 0, 0, 0, 0, 0, 0 -- cha_sat_iskmas6
	, 0, 0, 0, 0, 0, 0, 0, 0, 0 -- cha_avansmak_damgapul
	, 0, 0, GROUP2VERGI, GROUP3VERGI, GROUP4VERGI, 0, 0, 0, 0, 0, 0, 0 -- cha_vergisiz_fl
	, 0, 0, 0, 0, 0, 0, TARIH, FISSIRANO, '', 0 -- cha_sntck_poz
	, BOSTARIH, 0, 1, 0, 0, 0 -- cha_meblag_orj_doviz_icin_gecersiz_fl
	, EMPTYUID, EMPTYUID, BOSTARIH, 0, 0, 1, 0, 0 -- cha_ilave_edilecek_kdv1
	, 0, 0, 0, 0, 0, 0 -- cha_ilave_edilecek_kdv7
	, 0, 0, 0, 0, FATURABELGETURU, DIGERBELGEADI, CHAUUID -- cha_uuid
	, 0, 0, BOSTARIH, 0, '', '', '' -- cha_HareketGrupKodu3
	  FROM #MIKCURRENTTRANSACTION

	SELECT *, ROW_NUMBER() OVER (PARTITION BY EVRAKNOSERI ORDER BY FISHESAPKOD) - 1 FISSATIRNO, 
		   CASE WHEN NORMALIADE = 0 THEN 'Sat.fat : ' ELSE 'Al.fat : ' END + FISHESAPKOD + ' / '+@ACIKLAMA FISACIKLAMA
	  INTO #MIKACCOUNTING 
	  FROM (
	SELECT YEAR(TARIH) MALIYIL, TARIH, FISSIRANO, NORMALIADE,
		   CASE WHEN NORMALIADE =  0 THEN 1 ELSE 2 END FISTUR,
		   CASE WHEN NORMALIADE =  0 THEN @YevmiyeNo ELSE @IadeYevmiyeNo END YEVMIYENO,
		   '100.02.001' FISHESAPKOD, SORUMLULUKMERKEZI, FATUID,
		   CASE WHEN NORMALIADE =  0 THEN 63 ELSE 0 END EVRAKTIP,
		   EVRAKNOSERI, EVRAKNOSIRA,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN 1 ELSE -1 END * (TUTAR + VERGI)),2) MEBLAG0,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN 1 ELSE -1 END * (TUTAR + VERGI) / 5.7997),2) MEBLAG1,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN 1 ELSE -1 END * (TUTAR + VERGI)),2) MEBLAG2,
		   0 MEBLAG3, 0 MEBLAG4, 0 MEBLAG5
	  FROM #MIKTRASANCTION
	 GROUP BY TARIH, FISSIRANO, NORMALIADE, SORUMLULUKMERKEZI, FATUID
		 , EVRAKNOSERI, EVRAKNOSIRA
	 UNION ALL
	SELECT YEAR(TARIH) MALIYIL, TARIH, FISSIRANO, NORMALIADE,
		   CASE WHEN NORMALIADE =  0 THEN 1 ELSE 2 END FISTUR,
		   CASE WHEN NORMALIADE =  0 THEN @YevmiyeNo ELSE @IadeYevmiyeNo END YEVMIYENO,
		   CASE WHEN NORMALIADE = 0 THEN CASE VERGIPNTR WHEN 2 THEN '391.01.001' WHEN 3 THEN '391.01.008' WHEN 4 THEN '391.01.018' END 
		   ELSE CASE VERGIPNTR WHEN 2 THEN '191.03.001' WHEN 3 THEN '191.03.008' WHEN 4 THEN '191.03.018' END END FISHESAPKOD, 
		   SORUMLULUKMERKEZI, FATUID,
		   CASE WHEN NORMALIADE =  0 THEN 63 ELSE 0 END EVRAKTIP,
		   EVRAKNOSERI, EVRAKNOSIRA,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * VERGI),2) MEBLAG0,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * VERGI / 5.7997),2) MEBLAG1,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * VERGI),2) MEBLAG2,
		   0 MEBLAG3, 
		   SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * TUTAR) MEBLAG4, 
		   0 MEBLAG5
	  FROM #MIKTRASANCTION
	 GROUP BY TARIH, FISSIRANO, NORMALIADE, SORUMLULUKMERKEZI, FATUID
		 , EVRAKNOSERI, EVRAKNOSIRA, VERGIPNTR 
	 UNION ALL
	SELECT YEAR(TARIH) MALIYIL, TARIH, FISSIRANO, NORMALIADE,
		   CASE WHEN NORMALIADE =  0 THEN 1 ELSE 2 END FISTUR,
		   CASE WHEN NORMALIADE =  0 THEN @YevmiyeNo ELSE @IadeYevmiyeNo END YEVMIYENO,
		   CASE WHEN NORMALIADE = 0 THEN CASE VERGIPNTR WHEN 2 THEN '600.01.001' WHEN 3 THEN '600.01.008' WHEN 4 THEN '600.01.018' END 
		   ELSE CASE VERGIPNTR WHEN 2 THEN '610.01.001' WHEN 3 THEN '610.01.008' WHEN 4 THEN '610.01.018' END END FISHESAPKOD, 
		   SORUMLULUKMERKEZI, FATUID,
		   CASE WHEN NORMALIADE =  0 THEN 63 ELSE 0 END EVRAKTIP,
		   EVRAKNOSERI, EVRAKNOSIRA,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * TUTAR),2) MEBLAG0,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * TUTAR / 5.7997),2) MEBLAG1,
		   ROUND(SUM(CASE WHEN NORMALIADE =  0 THEN -1 ELSE 1 END * TUTAR),2) MEBLAG2,
		   -1*SUM(MIKTAR / ABS(ISNULL(sto_birim1_katsayi,1))), 
		   -1*SUM(MIKTAR / ABS(ISNULL(sto_birim2_katsayi,1))), 
		   -1*SUM(CASE WHEN ABS(ISNULL(sto_birim3_katsayi,1)) <> 0 THEN MIKTAR / ABS(ISNULL(sto_birim3_katsayi,1)) ELSE MIKTAR END) 
	  FROM #MIKTRASANCTION T
	  LEFT JOIN MIK_PRODUCT_SYN P ON T.STOKKOD COLLATE Turkish_CI_AS = P.sto_kod
	 GROUP BY TARIH, FISSIRANO, NORMALIADE, SORUMLULUKMERKEZI, FATUID
		 , EVRAKNOSERI, EVRAKNOSIRA, VERGIPNTR)A

	INSERT INTO MIK_ACCOUNTING20_SYN
	(fis_Guid, fis_DBCno, fis_SpecRECno, fis_iptal, fis_fileid, fis_hidden, fis_kilitli, fis_degisti, fis_checksum, fis_create_user, fis_create_date
	, fis_lastup_user, fis_lastup_date, fis_special1, fis_special2, fis_special3, fis_firmano, fis_subeno, fis_maliyil, fis_tarih, fis_sira_no
	, fis_tur, fis_hesap_kod, fis_satir_no, fis_aciklama1, fis_meblag0, fis_meblag1, fis_meblag2, fis_meblag3, fis_meblag4, fis_meblag5, fis_meblag6
	, fis_sorumluluk_kodu, fis_ticari_tip, fis_ticari_uid, fis_kurfarkifl, fis_ticari_evraktip, fis_tic_evrak_seri, fis_tic_evrak_sira, fis_tic_belgeno
	, fis_tic_belgetarihi, fis_yevmiye_no, fis_katagori, fis_evrak_DBCno, fis_fmahsup_tipi, fis_fozelmahkod, fis_grupkodu, fis_aktif_pasif, fis_proje_kodu
	, fis_HareketGrupKodu1, fis_HareketGrupKodu2, fis_HareketGrupKodu3)
	SELECT NEWID(), 0, 0, 0, 2, 0, 0, 0, 0, 25, GETDATE() -- fis_create_date
	, 25, GETDATE(), '', '', '', 0, 0, MALIYIL, TARIH, FISSIRANO -- fis_sira_no
	, FISTUR, FISHESAPKOD, FISSATIRNO, FISACIKLAMA, MEBLAG0, MEBLAG1, MEBLAG2, MEBLAG3, MEBLAG4, MEBLAG5, 0 -- fis_meblag6
	, SORUMLULUKMERKEZI, 2, FATUID, 0, EVRAKTIP, EVRAKNOSERI, EVRAKNOSIRA, '' -- fis_tic_belgeno
	, TARIH, YEVMIYENO, 0, 0, 0, '', '', 0, '' -- fis_proje_kodu
	, '', '', '' -- fis_HareketGrupKodu3
	  FROM #MIKACCOUNTING

	INSERT INTO MIK_ACCOUNTINGDETAIL20_SYN
	( mfd_Guid, mfd_DBCno, mfd_SpecRECno, mfd_iptal, mfd_fileid, mfd_hidden, mfd_kilitli, mfd_degisti, mfd_checksum, mfd_create_user, mfd_create_date
	, mfd_lastup_user, mfd_lastup_date, mfd_special1, mfd_special2, mfd_special3, mfd_ticari_tip, mfd_evraktip, mfd_evrak_seri, mfd_evrak_sira, mfd_cariunvan
	, mfd_carivergidaireadi, mfd_carivergidaireno, mfd_bsbakonututar, mfd_bsbatabii, mfd_cariulkekodno, mfd_belgetarihi, mfd_tutarnereden, mfd_caritipi
	, mfd_carikodu, mfd_carimuhkodu, mfd_belgeno, mfd_kdvid, mfd_kdvtutar, mfd_malhizmetkodu, mfd_malhizmetcinsi, mfd_malhizmetmiktari, mfd_malhizmetbirim
	, mfd_ggb_gcb_no, mfd_aracivergidaireadi, mfd_aracivergidaireno, mfd_eximulkekodu, mfd_bsbakonuufrstutar, mfd_aciklama, mfd_caritutar, mfd_kisaevraktipi
	, mfd_satistipi, mfd_alistipi, mfd_tahtedtipi, mfd_digerevrakadi, mfd_evraktur)
	SELECT NEWID(), 0, 0, 0, 243, 0, 0, 0, 0, 25, GETDATE() -- mfd_create_date
	, 25, GETDATE(), '', '', '', 2, EVRAKTIP, EVRAKNOSERI, EVRAKNOSIRA, 'PERAKENDE SATIŞLAR AKTARIM CARİSİ' -- mfd_cariunvan
	, '', '', ARATOPLAM, 1, '052', TARIH, 5, 2 -- mfd_caritipi
	, '120.99.999', '120.99.999', '', 0, GROUP2VERGI+GROUP3VERGI+GROUP4VERGI, '', '', 0, '' -- mfd_malhizmetbirim
	, '', '', '', '', 0, @ACIKLAMA, MEBLAG, CASE WHEN NORMALIADE = 0 THEN 1 ELSE 2 END -- mfd_kisaevraktipi
	, CASE WHEN NORMALIADE = 0 THEN 2 ELSE 0 END, CASE WHEN NORMALIADE = 0 THEN 0 ELSE 10 END, 0, DIGERBELGEADI, FATURABELGETURU -- mfd_evraktur
	  FROM #MIKCURRENTTRANSACTION
END