CREATE PROCEDURE RCL_INS_ACCOUNTING_SP
	@ReconciliationID		INT,
	@StoreID				INT,
    @TransactionDate		DATETIME,
	@CardTotal				NUMERIC(22, 6)
AS

BEGIN

    SET NOCOUNT OFF;

	IF @@SERVERNAME != 'DBSERVER1' RETURN 100;

	DECLARE @Count INT, 
			@EvrakSeriNo VARCHAR(4), 
			@Aciklama VARCHAR(50), 
			@MagazaAdi VARCHAR(30),
			@SorumlulukMerkeziKodu VARCHAR(8),
			@KartValor INT,
			@ErrorMessage VARCHAR(100),
			@CariMuhasebeHesabi VARCHAR(10), 
			@CariMuhasebeHesabiKart VARCHAR(10),
			@FisYevmiyeNo INT,
			@FisSiraNo INT,
			@FisSatirNo INT,
			@BelgeNo VARCHAR(20),
			@InsertTime DATETIME,
			@CariGUID1 uniqueidentifier, @CariGUID2 uniqueidentifier;

	--Her gün için bu count/3 kadar maðazanýn verisi aktarýlmýþ demekteir.
	SELECT @MagazaAdi = STORE_NM FROM STR_STORE S (NOLOCK) WHERE S.STOREID = @StoreID;

	SELECT @FisYevmiyeNo = ISNULL(MAX(fis_yevmiye_no), 0) FROM MIK_ACCOUNTING_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@TransactionDate) AND fis_tarih = @TransactionDate;
	IF @FisYevmiyeNo <= 0 SET @FisYevmiyeNo = 1;

	SELECT @FisSiraNo = ISNULL(MAX(fis_sira_no), 0) + 1 FROM MIK_ACCOUNTING_SYN WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@TransactionDate) AND fis_tarih = @TransactionDate;
	--IF @FisSiraNo <= 0 SET @FisSiraNo = 1;

	SELECT @FisSatirNo = ISNULL(MAX(fis_satir_no), 0) FROM MIK_ACCOUNTING_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@TransactionDate) AND fis_yevmiye_no = @FisYevmiyeNo;
	IF @FisSatirNo <= 0 SET @FisSatirNo = 1;

	print '@FisYevmiyeNo';
	print @FisYevmiyeNo;
	print '@FisSiraNo';
	print @FisSiraNo;
	print '@FisSatirNo';
	print @FisSatirNo;

	SET @EvrakSeriNo = 'P' + RIGHT('000' + CAST(@StoreID AS VARCHAR(3)), 3);
	SET @CariMuhasebeHesabi = '100.01.' + RIGHT('000' + CAST(@StoreID AS VARCHAR(3)), 3);
	SET @CariMuhasebeHesabiKart = '102.00.' + RIGHT('000' + CAST(@StoreID AS VARCHAR(3)), 3);
	SET @Aciklama = 'Mutabakat - ' + CONVERT(VARCHAR, @TransactionDate, 104) + ' - ' + @MagazaAdi;
	SET @SorumlulukMerkeziKodu = '201' + RIGHT('00000' + CAST(@StoreID AS VARCHAR(5)), 5)
	SET @KartValor = CAST(CONVERT(VARCHAR, @TransactionDate + 27, 112) AS INT);
	SET @InsertTime = GETDATE();
	SET @BelgeNo = 'MTB' + CAST(YEAR(@TransactionDate) AS VARCHAR) + + RIGHT('00000000' + CAST(@ReconciliationID AS VARCHAR(7)), 7);
	SET @CariGUID1 = NEWID();
	SET @CariGUID2 = NEWID();

	SELECT @Count = COUNT(1) FROM [dbo].[MIK_CURRENTTRANSACTION_SYN] WHERE cha_evrakno_seri LIKE 'P%' AND cha_evrakno_sira = @ReconciliationID;
	IF @Count > 0
	BEGIN
		SET @errormessage = CONCAT(CAST(@ReconciliationID AS INT), ' kodlu iþlem muhasebe sistemine zaten aktarýlmýþ.');
		RAISERROR(@errormessage, 16, 1);
		RETURN;
	END;

	INSERT [dbo].[MIK_CURRENTTRANSACTION_SYN]
	VALUES (@CariGUID1,											--cha_Guid
			0,													--cha_DBCno
			0,													--cha_SpecRecNo
			0,													--cha_iptal
			51,													--cha_fileid
			0,													--cha_hidden
			0,													--cha_kilitli
			0,													--cha_degisti
			0,													--cha_CheckSum
			11,													--cha_create_user
			@InsertTime,										--cha_create_date
			11,													--cha_lastup_user
			@InsertTime,										--cha_lastup_date
			'',													--cha_special1
			'',													--cha_special2
			'',													--cha_special3
			0,													--cha_firmano
			0,													--cha_subeno
			60,													--cha_evrak_tip
			@EvrakSeriNo,										--cha_evrakno_seri
			@ReconciliationID,									--cha_evrakno_sira
			1,													--cha_satir_no
			@TransactionDate,									--cha_tarihi
			0,													--cha_tip
			5,													--cha_cinsi
			0,													--cha_normal_Iade
			0,													--cha_tpoz
			0,													--cha_ticaret_turu
			@BelgeNo,													--cha_belge_no
			@TransactionDate,									--cha_belge_tarih
			@Aciklama,											--cha_aciklama
			'',													--cha_satici_kodu
			'',													--cha_EXIMkodu
			'',													--cha_projekodu
			'',													--cha_yat_tes_kodu
			2,													--cha_cari_cins
			@CariMuhasebeHesabiKart,							--cha_kod
			'',													--cha_ciro_cari_kodu
			0,													--cha_d_cins
			1,													--cha_d_kur
			5.2889,												--cha_altd_kur
			7,													--cha_grupno
			@SorumlulukMerkeziKodu,								--cha_srmrkkodu
			0,													--cha_kasa_hizmet
			'',													--cha_kasa_hizkod
			0,													--cha_karsidcinsi
			1,													--cha_karsid_kur
			0,													--cha_karsidgrupno
			'',                                                 --cha_karsisrmrkkodu
			0,													--cha_miktari
			@CardTotal,											--cha_meblag
			0,													--cha_aratoplam
			@KartValor,			                                --cha_vade
			0,													--cha_Vade_Farki_Yuz
			0,													--cha_ft_iskonto1
			0,													--cha_ft_iskonto2
			0,													--cha_ft_iskonto3
			0,													--cha_ft_iskonto4
			0,													--cha_ft_iskonto5
			0,													--cha_ft_iskonto6
			0,													--cha_ft_masraf1
			0,													--cha_ft_masraf2
			0,													--cha_ft_masraf3
			0,													--cha_ft_masraf4
			0,													--cha_isk_mas1
			0,													--cha_isk_mas2
			0,													--cha_isk_mas3
			0,													--cha_isk_mas4
			0,													--cha_isk_mas5
			0,													--cha_isk_mas6
			0,													--cha_isk_mas7
			0,													--cha_isk_mas8
			0,													--cha_isk_mas9
			0,													--cha_isk_mas10
			0,													--cha_sat_iskmas1
			0,													--cha_sat_iskmas2
			0,													--cha_sat_iskmas3
			0,													--cha_sat_iskmas4
			0,													--cha_sat_iskmas5
			0,													--cha_sat_iskmas6
			0,													--cha_sat_iskmas7
			0,													--cha_sat_iskmas8
			0,													--cha_sat_iskmas9
			0,													--cha_sat_iskmas10
			0,													--cha_yuvarlama
			0,													--cha_StFonPntr
			0,													--cha_stopaj
			0,													--cha_savsandesfonu
			0,													--cha_avansmak_damgapul
			0,													--cha_vergipntr
			0,													--cha_vergi1
			0,													--cha_vergi2
			0,													--cha_vergi3
			0,													--cha_vergi4
			0,													--cha_vergi5
			0,													--cha_vergi6
			0,													--cha_vergi7
			0,													--cha_vergi8
			0,													--cha_vergi9
			0,													--cha_vergi10
			0,													--cha_vergisiz_fl
			0,													--cha_otvtutari
			0,													--cha_otvvergisiz_fl
			0,													--cha_oiv_pntr
			0,													--cha_oivtutari
			0,													--cha_oiv_vergi
			0,													--cha_oivergisiz_fl
			@TransactionDate,									--cha_fis_tarih
			@FisSiraNo,													--cha_fis_sirano
			'',													--cha_trefno
			0,													--cha_sntck_poz
			'1900-01-01',										--cha_reftarihi
			0,													--cha_istisnakodu
			1,													--cha_pos_hareketi
			0,													--cha_meblag_ana_doviz_icin_gecersiz_fl
			0,													--cha_meblag_alt_doviz_icin_gecersiz_fl
			0,													--cha_meblag_orj_doviz_icin_gecersiz_fl
			'00000000-0000-0000-0000-000000000000',				--cha_sip_uid
			'00000000-0000-0000-0000-000000000000',				--cha_kirahar_uid
			'1900-01-01',										--cha_vardiya_tarihi
			0,													--cha_vardiya_no
			0,													--cha_vardiya_evrak_ti
			0,													--cha_ebelge_cinsi
			0,													--cha_tevkifat_toplam
			0,													--cha_ilave_edilecek_kdv1
			0,													--cha_ilave_edilecek_kdv2
			0,													--cha_ilave_edilecek_kdv3
			0,													--cha_ilave_edilecek_kdv4
			0,													--cha_ilave_edilecek_kdv5
			0,													--cha_ilave_edilecek_kdv6
			0,													--cha_ilave_edilecek_kdv7
			0,													--cha_ilave_edilecek_kdv8
			0,													--cha_ilave_edilecek_kdv9
			0,													--cha_ilave_edilecek_kdv10
			0,													--cha_e_islem_turu
			3,													--cha_fatura_belge_turu
			'Z Raporu',											--cha_diger_belge_adi
			'',													--cha_uuid
			0,													--cha_adres_no
			0,													--cha_vergifon_toplam
			'1900-01-01',										--cha_ilk_belge_tarihi
			0,													--cha_ilk_belge_doviz_kuru
			'',													--cha_HareketGrupKodu1
			'',													--cha_HareketGrupKodu2
			'');												--cha_HareketGrupKodu3

	INSERT [dbo].[MIK_CURRENTTRANSACTION_SYN]
	VALUES (@CariGUID2,											--cha_Guid
			0,													--cha_DBCno
			0,													--cha_SpecRecNo
			0,													--cha_iptal
			51,													--cha_fileid
			0,													--cha_hidden
			0,													--cha_kilitli
			0,													--cha_degisti
			0,													--cha_CheckSum
			11,													--cha_create_user
			@InsertTime,										--cha_create_date
			11,													--cha_lastup_user
			@InsertTime,										--cha_lastup_date
			'',													--cha_special1
			'',													--cha_special2
			'',													--cha_special3
			0,													--cha_firmano
			0,													--cha_subeno
			60,													--cha_evrak_tip
			@EvrakSeriNo,									--cha_evrakno_seri
			@ReconciliationID,									--cha_evrakno_sira
			2,													--cha_satir_no
			@TransactionDate,									--cha_tarihi
			1,													--cha_tip
			5,													--cha_cinsi
			0,													--cha_normal_Iade
			0,													--cha_tpoz
			0,													--cha_ticaret_turu
			@BelgeNo,													--cha_belge_no
			@TransactionDate,									--cha_belge_tarih
			@Aciklama,											--cha_aciklama
			'',													--cha_satici_kodu
			'',													--cha_EXIMkodu
			'',													--cha_projekodu
			'',													--cha_yat_tes_kodu
			4,													--cha_cari_cins
			@CariMuhasebeHesabi,								--cha_kod
			'',													--cha_ciro_cari_kodu
			0,													--cha_d_cins
			1,													--cha_d_kur
			5.2889,												--cha_altd_kur
			0,													--cha_grupno
			@SorumlulukMerkeziKodu,								--cha_srmrkkodu
			0,													--cha_kasa_hizmet
			'',													--cha_kasa_hizkod
			0,													--cha_karsidcinsi
			1,													--cha_karsid_kur
			0,													--cha_karsidgrupno
			'',													--cha_karsisrmrkkodu
			0,													--cha_miktari
			@CardTotal,						            		--cha_meblag
			0,													--cha_aratoplam
			0,													--cha_vade
			0,													--cha_Vade_Farki_Yuz
			0,													--cha_ft_iskonto1
			0,													--cha_ft_iskonto2
			0,													--cha_ft_iskonto3
			0,													--cha_ft_iskonto4
			0,													--cha_ft_iskonto5
			0,													--cha_ft_iskonto6
			0,													--cha_ft_masraf1
			0,													--cha_ft_masraf2
			0,													--cha_ft_masraf3
			0,													--cha_ft_masraf4
			0,													--cha_isk_mas1
			0,													--cha_isk_mas2
			0,													--cha_isk_mas3
			0,													--cha_isk_mas4
			0,													--cha_isk_mas5
			0,													--cha_isk_mas6
			0,													--cha_isk_mas7
			0,													--cha_isk_mas8
			0,													--cha_isk_mas9
			0,													--cha_isk_mas10
			0,													--cha_sat_iskmas1
			0,													--cha_sat_iskmas2
			0,													--cha_sat_iskmas3
			0,													--cha_sat_iskmas4
			0,													--cha_sat_iskmas5
			0,													--cha_sat_iskmas6
			0,													--cha_sat_iskmas7
			0,													--cha_sat_iskmas8
			0,													--cha_sat_iskmas9
			0,													--cha_sat_iskmas10
			0,													--cha_yuvarlama
			0,													--cha_StFonPntr
			0,													--cha_stopaj
			0,													--cha_savsandesfonu
			0,													--cha_avansmak_damgapul
			0,													--cha_vergipntr
			0,													--cha_vergi1
			0,													--cha_vergi2
			0,													--cha_vergi3
			0,													--cha_vergi4
			0,													--cha_vergi5
			0,													--cha_vergi6
			0,													--cha_vergi7
			0,													--cha_vergi8
			0,													--cha_vergi9
			0,													--cha_vergi10
			0,													--cha_vergisiz_fl
			0,													--cha_otvtutari
			0,													--cha_otvvergisiz_fl
			0,													--cha_oiv_pntr
			0,													--cha_oivtutari
			0,													--cha_oiv_vergi
			0,													--cha_oivergisiz_fl
			@TransactionDate,									--cha_fis_tarih
			@FisSiraNo,													--cha_fis_sirano
			'',													--cha_trefno
			0,													--cha_sntck_poz
			'1900-01-01',										--cha_reftarihi
			0,													--cha_istisnakodu
			1,													--cha_pos_hareketi
			0,													--cha_meblag_ana_doviz_icin_gecersiz_fl
			0,													--cha_meblag_alt_doviz_icin_gecersiz_fl
			0,													--cha_meblag_orj_doviz_icin_gecersiz_fl
			'00000000-0000-0000-0000-000000000000',				--cha_sip_uid
			'00000000-0000-0000-0000-000000000000',				--cha_kirahar_uid
			'1900-01-01',										--cha_vardiya_tarihi
			0,													--cha_vardiya_no
			0,													--cha_vardiya_evrak_ti
			0,													--cha_ebelge_cinsi
			0,													--cha_tevkifat_toplam
			0,													--cha_ilave_edilecek_kdv1
			0,													--cha_ilave_edilecek_kdv2
			0,													--cha_ilave_edilecek_kdv3
			0,													--cha_ilave_edilecek_kdv4
			0,													--cha_ilave_edilecek_kdv5
			0,													--cha_ilave_edilecek_kdv6
			0,													--cha_ilave_edilecek_kdv7
			0,													--cha_ilave_edilecek_kdv8
			0,													--cha_ilave_edilecek_kdv9
			0,													--cha_ilave_edilecek_kdv10
			0,													--cha_e_islem_turu
			3,													--cha_fatura_belge_turu
			'Z Raporu',											--cha_diger_belge_adi
			'',													--cha_uuid
			0,													--cha_adres_no
			0,													--cha_vergifon_toplam
			'1900-01-01',										--cha_ilk_belge_tarihi
			0,													--cha_ilk_belge_doviz_kuru
			'',													--cha_HareketGrupKodu1
			'',													--cha_HareketGrupKodu2
			'');												--cha_HareketGrupKodu3

	-------------------------------------------------------------------------------------------------------------------
	-------------------------------------------------MUHASEBE----------------------------------------------------------
	-------------------------------------------------------------------------------------------------------------------
	INSERT [MIK_ACCOUNTING_SYN] 
	VALUES (NEWID(), 						      																			--[fis_guid], 
			0, 								 																				--[fis_dbcno], 
			0, 								 																				--[fis_specrecno], 
			0, 								 																				--[fis_iptal], 
			2, 								 																				--[fis_fileid], 
			0, 								 																				--[fis_hidden], 
			0, 								 																				--[fis_kilitli], 
			0, 								 																				--[fis_degisti], 
			0, 								 																				--[fis_checksum], 
			11, 							 																				--[fis_create_user], 
			@InsertTime, 					 																				--[fis_create_date], 
			11, 							 																				--[fis_lastup_user], 
			@InsertTime, 					 																				--[fis_lastup_date], 
			'', 							 																				--[fis_special1], 
			'', 							 																				--[fis_special2], 
			'', 							 																				--[fis_special3], 
			0, 								 																				--[fis_firmano], 
			0, 								 																				--[fis_subeno], 
			YEAR(@TransactionDate), 		 																				--[fis_
			@TransactionDate, 				 																				--[fis_tarih], 
			@FisSiraNo, 				 																					--[fis_sira_no]
			0, 								 																				--[fis_tur], 
			'127.02.001', 					 																				--[fis_hesap_kod], 
			@FisSatirNo + 1, 								 																--[fis_satir_no], 
			@Aciklama, 						 																				--[fis_aciklama1], 
			@CardTotal, 					 																				--[fis_meblag0], 
			0, 				 																								--[fis_meblag1], 
			@CardTotal, 					 																				--[fis_meblag2], 
			0, 								 																				--[fis_meblag3], 
			0, 								 																				--[fis_meblag4], 
			0, 								 																				--[fis_meblag5], 
			0, 								 																				--[fis_meblag6], 
			@SorumlulukMerkeziKodu, 		 																				--[fis_sorumlul
			2, 								 																				--[fis_ticari_tip], 
			@CariGUID1, 						 																			--[fis_ticari_uid], 
			0, 								 																				--[fis_kurfarkifl], 
			60, 							 																				--[fis_ticari_evraktip], 
			@EvrakSeriNo, 				 																					--[fis_tic_evrak_seri], 
			420, 							 																				--[fis_tic_evrak_sira], 
			@BelgeNo, 							 																			--[fis_tic_belgeno], 
			@TransactionDate, 				 																				--[fis_tic_belgetarihi], 
			@FisYevmiyeNo, 			 																						--[fis_yevm
			0, 								 																				--[fis_katagori], 
			0, 								 																				--[fis_evrak_dbcno], 
			0, 								 																				--[fis_fmahsup_tipi], 
			'', 							 																				--[fis_fozelmahkod], 
			'', 							 																				--[fis_grupkodu], 
			0, 								 																				--[fis_aktif_pasif], 
			'', 							 																				--[fis_proje_kodu], 
			'', 							 																				--[fis_hareketgrupkodu1], 
			'', 							 																				--[fis_hareketgrupkodu2], 
			'') 							 																				--[fis_hareketgrupkodu3]) 

	INSERT [MIK_ACCOUNTING_SYN] 
	VALUES (NEWID(),							     																			--[fis_guid], 
			0, 																													--[fis_dbcno], 
			0, 																													--[fis_specrecno], 
			0, 																													--[fis_iptal], 
			2, 																													--[fis_fileid], 
			0, 																													--[fis_hidden], 
			0, 																													--[fis_kilitli], 
			0, 																													--[fis_degisti], 
			0, 																													--[fis_checksum], 
			11, 																												--[fis_create_user], 
			@InsertTime, 																		--[fis_create_date], 
			11, 																												--[fis_lastup_user], 
			@InsertTime, 																		--[fis_lastup_date], 
			'', 																												--[fis_special1], 
			'', 																												--[fis_special2], 
			'', 																												--[fis_special3], 
			0, 																													--[fis_firmano], 
			0, 																													--[fis_subeno], 
			YEAR(@TransactionDate), 																							--[fis_maliyil], 
			@TransactionDate, 																									--[fis_tarih], 
			@FisSiraNo, 																									--[fis_sira_no], 
			0, 																													--[fis_tur], 
			'100.02.001', 																										--[fis_hesap_kod], 
			@FisSatirNo + 2, 																													--[fis_satir_no], 
			@Aciklama,																--[fis_aciklama1], 
			-1 * @CardTotal, 																											--[fis_meblag0], 
			0, 																									--[fis_meblag1], 
			-1 * @CardTotal, 																											--[fis_meblag2], 
			0, 																													--[fis_meblag3], 
			0, 																													--[fis_meblag4], 
			0, 																													--[fis_meblag5], 
			0, 																													--[fis_meblag6], 
			@SorumlulukMerkeziKodu, 																										--[fis_sorumluluk_kodu], 
			2, 																													--[fis_ticari_tip], 
			@CariGUID2, 																			--[fis_ticari_uid], 
			0, 																													--[fis_kurfarkifl], 
			60, 																												--[fis_ticari_evraktip], 
			@EvrakSeriNo, 																											--[fis_tic_evrak_seri], 
			420, 																												--[fis_tic_evrak_sira], 
			@BelgeNo, 																												--[fis_tic_belgeno], 
			@TransactionDate, 																		--[fis_tic_belgetarihi], 
			@FisYevmiyeNo, 																												--[fis_yevmiye_no], 
			0, 																													--[fis_katagori], 
			0, 																													--[fis_evrak_dbcno], 
			0, 																													--[fis_fmahsup_tipi], 
			'', 																												--[fis_fozelmahkod], 
			'', 																												--[fis_grupkodu], 
			0, 																													--[fis_aktif_pasif], 
			'', 																												--[fis_proje_kodu], 
			'', 																												--[fis_hareketgrupkodu1], 
			'', 																												--[fis_hareketgrupkodu2], 
			'') 																												--[fis_hareketgrupkodu3]) 

    SET NOCOUNT ON;

END;


