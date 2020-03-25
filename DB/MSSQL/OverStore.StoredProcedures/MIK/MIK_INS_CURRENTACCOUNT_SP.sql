CREATE PROCEDURE MIK_INS_CURRENTACCOUNT_SP 
	@kimlikNo VARCHAR(100), @unvan VARCHAR(1000), @vergidaireadi VARCHAR(100), 
	@efaturaflag INT, @email VARCHAR(100), @ceptel VARCHAR(30), @vergidairekodu VARCHAR(30) AS
BEGIN
	DECLARE @control INT
	SELECT @control = COUNT(*)
	  FROM MIK_CURRENTACCOUNT_SYN
	 WHERE Replace(Ltrim(Replace(cari_vdaire_no, '0', ' ')), ' ', '0') = @kimlikNo

	IF @control > 0 RETURN; -- varsa kayıt çık

	DECLARE @carikod VARCHAR(30)
	SELECT @carikod = '120.02.'+CAST(MAX(CAST(REPLACE(cari_kod, '120.02.','') AS INT)) + 1 AS VARCHAR)
	  FROM MIK_CURRENTACCOUNT_SYN
	 WHERE cari_kod LIKE '120.02%'
	-- SELECT @carikod

	DECLARE @emptydate datetime;
	SET @emptydate = CONVERT(DATETIME, '18991230', 112);
	DECLARE @efaturacinsi INT = 1;

	DECLARE @efaturabaslangictarihi datetime = CONVERT(DATETIME, '20131112', 112);

	INSERT INTO MIK_CURRENTACCOUNT_SYN 
	([cari_Guid], [cari_DBCno], [cari_SpecRECno], [cari_iptal], [cari_fileid], [cari_hidden], [cari_kilitli], [cari_degisti], [cari_checksum], [cari_create_user]
	, [cari_create_date], [cari_lastup_user], [cari_lastup_date], [cari_special1], [cari_special2], [cari_special3], [cari_kod], [cari_unvan1], [cari_unvan2]
	, [cari_hareket_tipi], [cari_baglanti_tipi], [cari_stok_alim_cinsi], [cari_stok_satim_cinsi], [cari_muh_kod], [cari_muh_kod1], [cari_muh_kod2], [cari_doviz_cinsi]
	, [cari_doviz_cinsi1], [cari_doviz_cinsi2], [cari_vade_fark_yuz], [cari_vade_fark_yuz1], [cari_vade_fark_yuz2], [cari_KurHesapSekli], [cari_vdaire_adi]
	, [cari_vdaire_no], [cari_sicil_no], [cari_VergiKimlikNo], [cari_satis_fk], [cari_odeme_cinsi], [cari_odeme_gunu], [cari_odemeplan_no], [cari_opsiyon_gun]
	, [cari_cariodemetercihi], [cari_fatura_adres_no], [cari_sevk_adres_no], [cari_banka_tcmb_kod1], [cari_banka_tcmb_subekod1], [cari_banka_tcmb_ilkod1]
	, [cari_banka_hesapno1], [cari_banka_swiftkodu1], [cari_banka_tcmb_kod2], [cari_banka_tcmb_subekod2], [cari_banka_tcmb_ilkod2], [cari_banka_hesapno2]
	, [cari_banka_swiftkodu2], [cari_banka_tcmb_kod3], [cari_banka_tcmb_subekod3], [cari_banka_tcmb_ilkod3], [cari_banka_hesapno3], [cari_banka_swiftkodu3]
	, [cari_banka_tcmb_kod4], [cari_banka_tcmb_subekod4], [cari_banka_tcmb_ilkod4], [cari_banka_hesapno4], [cari_banka_swiftkodu4], [cari_banka_tcmb_kod5]
	, [cari_banka_tcmb_subekod5], [cari_banka_tcmb_ilkod5], [cari_banka_hesapno5], [cari_banka_swiftkodu5], [cari_banka_tcmb_kod6], [cari_banka_tcmb_subekod6]
	, [cari_banka_tcmb_ilkod6], [cari_banka_hesapno6], [cari_banka_swiftkodu6], [cari_banka_tcmb_kod7], [cari_banka_tcmb_subekod7], [cari_banka_tcmb_ilkod7]
	, [cari_banka_hesapno7], [cari_banka_swiftkodu7], [cari_banka_tcmb_kod8], [cari_banka_tcmb_subekod8], [cari_banka_tcmb_ilkod8], [cari_banka_hesapno8]
	, [cari_banka_swiftkodu8], [cari_banka_tcmb_kod9], [cari_banka_tcmb_subekod9], [cari_banka_tcmb_ilkod9], [cari_banka_hesapno9], [cari_banka_swiftkodu9]
	, [cari_banka_tcmb_kod10], [cari_banka_tcmb_subekod10], [cari_banka_tcmb_ilkod10], [cari_banka_hesapno10], [cari_banka_swiftkodu10], [cari_EftHesapNum]
	, [cari_Ana_cari_kodu], [cari_satis_isk_kod], [cari_sektor_kodu], [cari_bolge_kodu], [cari_grup_kodu], [cari_temsilci_kodu], [cari_muhartikeli]
	, [cari_firma_acik_kapal], [cari_BUV_tabi_fl], [cari_cari_kilitli_flg], [cari_etiket_bas_fl], [cari_Detay_incele_flg], [cari_efatura_fl], [cari_POS_ongpesyuzde]
	, [cari_POS_ongtaksayi], [cari_POS_ongIskOran], [cari_kaydagiristarihi], [cari_KabEdFCekTutar], [cari_hal_caritip], [cari_HalKomYuzdesi], [cari_TeslimSuresi]
	, [cari_wwwadresi], [cari_EMail], [cari_CepTel], [cari_VarsayilanGirisDepo], [cari_VarsayilanCikisDepo], [cari_Portal_Enabled], [cari_Portal_PW], [cari_BagliOrtaklisa_Firma]
	, [cari_kampanyakodu], [cari_b_bakiye_degerlendirilmesin_fl], [cari_a_bakiye_degerlendirilmesin_fl], [cari_b_irsbakiye_degerlendirilmesin_fl]
	, [cari_a_irsbakiye_degerlendirilmesin_fl], [cari_b_sipbakiye_degerlendirilmesin_fl], [cari_a_sipbakiye_degerlendirilmesin_fl], [cari_AvmBilgileri1KiraKodu]
	, [cari_AvmBilgileri1TebligatSekli], [cari_AvmBilgileri2KiraKodu], [cari_AvmBilgileri2TebligatSekli], [cari_AvmBilgileri3KiraKodu], [cari_AvmBilgileri3TebligatSekli]
	, [cari_AvmBilgileri4KiraKodu], [cari_AvmBilgileri4TebligatSekli], [cari_AvmBilgileri5KiraKodu], [cari_AvmBilgileri5TebligatSekli], [cari_AvmBilgileri6KiraKodu]
	, [cari_AvmBilgileri6TebligatSekli], [cari_AvmBilgileri7KiraKodu], [cari_AvmBilgileri7TebligatSekli], [cari_AvmBilgileri8KiraKodu], [cari_AvmBilgileri8TebligatSekli]
	, [cari_AvmBilgileri9KiraKodu], [cari_AvmBilgileri9TebligatSekli], [cari_AvmBilgileri10KiraKodu], [cari_AvmBilgileri10TebligatSekli], [cari_KrediRiskTakibiVar_flg]
	, [cari_ufrs_fark_muh_kod], [cari_ufrs_fark_muh_kod1], [cari_ufrs_fark_muh_kod2], [cari_odeme_sekli], [cari_TeminatMekAlacakMuhKodu], [cari_TeminatMekAlacakMuhKodu1]
	, [cari_TeminatMekAlacakMuhKodu2], [cari_TeminatMekBorcMuhKodu], [cari_TeminatMekBorcMuhKodu1], [cari_TeminatMekBorcMuhKodu2], [cari_VerilenDepozitoTeminatMuhKodu]
	, [cari_VerilenDepozitoTeminatMuhKodu1], [cari_VerilenDepozitoTeminatMuhKodu2], [cari_AlinanDepozitoTeminatMuhKodu], [cari_AlinanDepozitoTeminatMuhKodu1]
	, [cari_AlinanDepozitoTeminatMuhKodu2], [cari_def_efatura_cinsi], [cari_otv_tevkifatina_tabii_fl], [cari_KEP_adresi], [cari_efatura_baslangic_tarihi], [cari_mutabakat_mail_adresi]
	, [cari_mersis_no], [cari_istasyon_cari_kodu], [cari_gonderionayi_sms], [cari_gonderionayi_email], [cari_eirsaliye_fl], [cari_eirsaliye_baslangic_tarihi], [cari_vergidairekodu]
	, [cari_CRM_sistemine_aktar_fl], [cari_efatura_xslt_dosya], [cari_pasaport_no], [cari_kisi_kimlik_bilgisi_aciklama_turu], [cari_kisi_kimlik_bilgisi_diger_aciklama]
	, [cari_uts_kurum_no], [cari_kamu_kurumu_fl], [cari_earsiv_xslt_dosya], [cari_Perakende_fl])
	VALUES (
	  NEWID(), 0, 0, 0, 31, 0, 0, 0, 0, 8 /*cari_create_user*/, GETDATE(), 8, GETDATE(), '', '', '', @carikod, @unvan, @unvan /*cari_unvan2*/
	, 0, 0, 0, 0, @carikod, '', '', 0 /* cari_doviz_cinsi*/, 255, 255, 25, 0, 0, 1, @vergidaireadi /*cari_vdaire_adi*/
	, @kimlikno, '', '', 1, 0, 0, 0, 0 /* cari_opsiyon_gun*/, 0, 1, 1, '', '', '' /*cari_banka_tcmb_ilkod1*/, '', '', '', '', '', '' /*cari_banka_hesapno2*/
	, '', '', '', '', '', '' /*cari_banka_swiftkodu3*/, '', '', '', '', '', '' /*cari_banka_tcmb_kod5*/, '', '', '', '', '', '' /*cari_banka_tcmb_subekod6*/
	, '', '', '', '', '', '' /*cari_banka_tcmb_ilkod7*/, '', '', '', '', '', '' /*cari_banka_hesapno8*/, '', '', '', '', '', '' /*cari_banka_swiftkodu9*/
	, '', '', '', '', '', 1 /*cari_EftHesapNum*/, '', '', '', '', '', '', '900.01.039' /*cari_muhartikeli*/, 0, 0, 0, 0, 0, @efaturaflag, 0 /*cari_POS_ongpesyuzde*/
	, 0, 0, CAST(GETDATE() AS DATE), 0, 0, 0, 0 /*cari_TeslimSuresi*/, '', @email, @ceptel, 0, 0, 0, '', 0 /*cari_BagliOrtaklisa_Firma*/
	, '', 0, 0, 0 /*cari_b_irsbakiye_degerlendirilmesin_fl*/, 0, 0, 0, '' /*cari_AvmBilgileri1KiraKodu*/, 0, '', 0, '', 0 /*cari_AvmBilgileri3TebligatSekli*/
	, '', 0, '', 0, '' /*cari_AvmBilgileri8TebligatSekli*/, 0, '', 0, '', 0 /*cari_AvmBilgileri8TebligatSekli*/, '', 0, '', 0, 0 /*cari_KrediRiskTakibiVar_flg*/
	, '', '', '', 0, 910, '' /*cari_TeminatMekAlacakMuhKodu1*/, '', 912, '', '', 226 /*cari_VerilenDepozitoTeminatMuhKodu*/, '', '', 326, '' /*cari_AlinanDepozitoTeminatMuhKodu1*/
	, '', @efaturacinsi, 0, '', @efaturabaslangictarihi, '' /*cari_mutabakat_mail_adresi*/, '', '', 0, 0, 0, @emptydate, @vergidairekodu /*cari_vergidairekodu*/
	, 0, '', '', 0, '', '', 0, '', 0 /*cari_Perakende_fl*/)

	-- DECLARE @carikod VARCHAR(100) = '120.02.149'
	-- drop table #address
	DECLARE @addresstext VARCHAR(1000)
	SELECT @addresstext = ADDRESS_TXT FROM ACC_IDENTITYINFO WHERE IDENTITYNO_TXT = @kimlikNo -- '3330584900'

	SELECT TRIM(SUBSTRING(value, 1, CHARINDEX(':', value)-2)) GRUP, TRIM(SUBSTRING(value, CHARINDEX(':', value)+1, 100)) DEGER
	  INTO #address
	  FROM STRING_SPLIT(@addresstext, ',')

	DECLARE @CaddeSokak VARCHAR(100), @DaireNO VARCHAR(100), @IlAdi VARCHAR(100), @IlceAdi VARCHAR(100), @IlKodu VARCHAR(100), @KapiNO VARCHAR(100), @MahalleSemt VARCHAR(100)
	SELECT @CaddeSokak = MAX(CASE WHEN GRUP = 'CaddeSokak' THEN DEGER END)
		 , @DaireNO = MAX(CASE WHEN GRUP = 'DaireNO' THEN DEGER END)
		 , @IlAdi = MAX(CASE WHEN GRUP = 'IlAdi' THEN DEGER END)
		 , @IlceAdi = MAX(CASE WHEN GRUP = 'IlceAdi' THEN DEGER END)
		 , @IlKodu = MAX(CASE WHEN GRUP = 'IlKodu' THEN DEGER END)
		 , @KapiNO = MAX(CASE WHEN GRUP = 'KapiNO' THEN DEGER END)
		 , @MahalleSemt = MAX(CASE WHEN GRUP = 'MahalleSemt' THEN DEGER END)
	  FROM #address

	INSERT INTO MIK_CURRENTACCOUNTADDRESS_SYN
	(adr_Guid, adr_DBCno, adr_SpecRECno, adr_iptal, adr_fileid, adr_hidden, adr_kilitli, adr_degisti, adr_checksum, adr_create_user, adr_create_date, adr_lastup_user, adr_lastup_date
	, adr_special1, adr_special2, adr_special3, adr_cari_kod, adr_adres_no, adr_aprint_fl, adr_cadde, adr_mahalle, adr_sokak, adr_Semt, adr_Apt_No, adr_Daire_No, adr_posta_kodu
	, adr_ilce, adr_il, adr_ulke, adr_Adres_kodu, adr_tel_ulke_kodu, adr_tel_bolge_kodu, adr_tel_no1, adr_tel_no2, adr_tel_faxno, adr_tel_modem, adr_yon_kodu, adr_uzaklik_kodu, adr_temsilci_kodu
	, adr_ozel_not, adr_ziyaretperyodu, adr_ziyaretgunu, adr_gps_enlem, adr_gps_boylam, adr_ziyarethaftasi, adr_ziygunu2_1, adr_ziygunu2_2, adr_ziygunu2_3, adr_ziygunu2_4, adr_ziygunu2_5
	, adr_ziygunu2_6, adr_ziygunu2_7, adr_efatura_alias, adr_eirsaliye_alias)
	VALUES
	(NEWID(), 0, 0, 0, 32, 0, 0, 0, 0, 8, GETDATE(), 8, GETDATE(),
	 '', '', '', @carikod, 1, 0, @CaddeSokak, @MahalleSemt, '', '', @KapiNO, @DaireNO, '',
	 @IlceAdi, @IlAdi, 'TÜRKİYE', '', 90, '', '', '', '', '', '', 0, '',
	 '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
	 0, 0, '', '');
END