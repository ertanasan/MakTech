CREATE PROCEDURE [dbo].[WHS_INS_MIKROPRODUCTRETURN_SP] @ProductReturnId INT AS
BEGIN
  DECLARE @emptyguid nvarchar(40)
  SET @emptyguid = '00000000-0000-0000-0000-000000000000';
                    
  DECLARE @emptydate datetime, @today DATE;
  SET @emptydate = CONVERT(DATETIME, '18991230', 112);

  SELECT @today = CAST(GETDATE() AS DATE);
              
  DECLARE @control INT
  SELECT @control = COUNT(*)
    FROM MIK_TRANSACTION20_SYN
   WHERE sth_evraktip = 2
     AND sth_evrakno_seri = 'OPR'
	 AND sth_evrakno_sira = @ProductReturnId;
                
  IF @control = 0
  BEGIN
    IF OBJECT_ID('tempdb.dbo.#insert', 'U') IS NOT NULL DROP TABLE #insert;
	
    SELECT STORE, RETURN_DT, ROW_NUMBER() OVER (ORDER BY PR.PRODUCTRETURNID) ROWNO,
		   P.CODE_NM PRODUCTCODE_NM, PR.INTAKE_AMT QUANTITY,
		   CASE P.SALEVAT_RT WHEN 0 THEN 1 WHEN 1 THEN 2 WHEN 8 THEN 3 WHEN 18 THEN 4 END VATGROUP_CD,
		   STORE_NM, 1000 + PR.RETURNDESTINATION WAREHOUSE
      INTO #insert
      FROM WHS_PRODUCTRETURN PR
      JOIN PRD_PRODUCT P ON PR.PRODUCT = P.PRODUCTID
      JOIN STR_STORE ST ON PR.STORE = ST.STOREID
	 WHERE PR.PRODUCTRETURNID = @ProductReturnId
	   AND PR.STATUS_CD = 4;

	   
    INSERT INTO MIK_TRANSACTION20_SYN
	( sth_Guid, sth_DBCno, sth_SpecRECno, sth_iptal, sth_fileid, sth_hidden, sth_kilitli, sth_degisti, sth_checksum, sth_create_user 
    , sth_create_date, sth_lastup_user, sth_lastup_date, sth_special1, sth_special2, sth_special3, sth_firmano, sth_subeno
    , sth_tarih, sth_tip, sth_cins, sth_normal_iade
	, sth_evraktip, sth_evrakno_seri, sth_evrakno_sira, sth_satirno
	, sth_belge_no, sth_belge_tarih, sth_stok_kod
	, sth_isk_mas1, sth_isk_mas2, sth_isk_mas3, sth_isk_mas4, sth_isk_mas5
	, sth_isk_mas6, sth_isk_mas7, sth_isk_mas8, sth_isk_mas9, sth_isk_mas10
	, sth_sat_iskmas1, sth_sat_iskmas2, sth_sat_iskmas3, sth_sat_iskmas4, sth_sat_iskmas5
	, sth_sat_iskmas6, sth_sat_iskmas7, sth_sat_iskmas8, sth_sat_iskmas9, sth_sat_iskmas10
	, sth_pos_satis, sth_promosyon_fl, sth_cari_cinsi
	, sth_cari_kodu, sth_cari_grup_no, sth_isemri_gider_kodu, sth_plasiyer_kodu
	, sth_har_doviz_cinsi, sth_har_doviz_kuru, sth_alt_doviz_kuru, sth_stok_doviz_cinsi
	, sth_stok_doviz_kuru, sth_miktar, sth_miktar2, sth_birim_pntr, sth_tutar
	, sth_iskonto1, sth_iskonto2, sth_iskonto3, sth_iskonto4, sth_iskonto5, sth_iskonto6
	, sth_masraf1, sth_masraf2, sth_masraf3, sth_masraf4, sth_vergi_pntr, sth_vergi
	, sth_masraf_vergi_pntr, sth_masraf_vergi, sth_netagirlik, sth_odeme_op
	, sth_aciklama, sth_sip_uid, sth_fat_uid
	, sth_giris_depo_no, sth_cikis_depo_no
	, sth_malkbl_sevk_tarihi, sth_cari_srm_merkezi, sth_stok_srm_merkezi, sth_fis_tarihi
	, sth_fis_sirano, sth_vergisiz_fl, sth_maliyet_ana, sth_maliyet_alternatif, sth_maliyet_orjinal
	, sth_adres_no, sth_parti_kodu, sth_lot_no
	, sth_kons_uid, sth_proje_kodu, sth_exim_kodu, sth_otv_pntr, sth_otv_vergi, sth_brutagirlik
	, sth_disticaret_turu, sth_otvtutari, sth_otvvergisiz_fl
	, sth_oiv_pntr, sth_oiv_vergi, sth_oivvergisiz_fl, sth_fiyat_liste_no, sth_oivtutari, sth_Tevkifat_turu, sth_nakliyedeposu, sth_nakliyedurumu
	, sth_yetkili_uid, sth_taxfree_fl, sth_ilave_edilecek_kdv, sth_ismerkezi_kodu, sth_HareketGrupKodu1, sth_HareketGrupKodu2, sth_HareketGrupKodu3
	, sth_Olcu1, sth_Olcu2, sth_Olcu3, sth_Olcu4, sth_Olcu5, sth_FormulMiktarNo, sth_FormulMiktar)
    SELECT NEWID() sth_Guid, 0 sth_DBCno, 0 sth_SpecRECno, 0 sth_iptal, 16 sth_fileid, 0 sth_hidden, 0 sth_kilitli, 0 sth_degisti, 0 sth_checksum, 10 sth_create_user
      , GETDATE() sth_create_date, 10 sth_lastup_user, GETDATE() sth_lastup_date, '' sth_special1, '' sth_special2, '' sth_special3, 0 sth_firmano, 0 sth_subeno
      , @today sth_tarih, 2 sth_tip, 6 sth_cins, 0 sth_normal_iade
      , 2 sth_evraktip, 'OPR' sth_evrakno_seri, @ProductReturnId sth_evrakno_sira, ROWNO sth_satirno
      , cast(@ProductReturnId AS VARCHAR(20)) sth_belge_no, @today sth_belge_tarih, PRODUCTCODE_NM sth_stok_kod
      , 0 sth_isk_mas1, 1 sth_isk_mas2, 1 sth_isk_mas3, 1 sth_isk_mas4, 1 sth_isk_mas5
      , 1 sth_isk_mas6, 1 sth_isk_mas7, 1 sth_isk_mas8, 1 sth_isk_mas9, 1 sth_isk_mas10
      , 0 sth_sat_iskmas1, 0 sth_sat_iskmas2, 0 sth_sat_iskmas3, 0 sth_sat_iskmas4, 0 sth_sat_iskmas5
      , 0 sth_sat_iskmas6, 0 sth_sat_iskmas7, 0 sth_sat_iskmas8, 0 sth_sat_iskmas9, 0 sth_sat_iskmas10
      , 0 sth_pos_satis, 0 sth_promosyon_fl, 0 sth_cari_cinsi
      , '' sth_cari_kodu, 0 sth_cari_grup_no, '' sth_isemri_gider_kodu, '' sth_plasiyer_kodu
      , 0 sth_har_doviz_cinsi, 1 sth_har_doviz_kuru, 1 sth_alt_doviz_kuru, 0 sth_stok_doviz_cinsi
      , 1 sth_stok_doviz_kuru, QUANTITY sth_miktar, 0 sth_miktar2, 1 sth_birim_pntr, 0 sth_tutar
      , 0 sth_iskonto1, 0 sth_iskonto2, 0 sth_iskonto3, 0 sth_iskonto4, 0 sth_iskonto5, 0 sth_iskonto6
      , 0 sth_masraf1, 0 sth_masraf2, 0 sth_masraf3, 0 sth_masraf4, VATGROUP_CD sth_vergi_pntr, 0 sth_vergi
      , 0 sth_masraf_vergi_pntr, 0 sth_masraf_vergi, 0 sth_netagirlik, '0' sth_odeme_op
      , 'Mağaza İade '+STORE_NM sth_aciklama, @emptyguid sth_sip_uid, @emptyguid sth_fat_uid
      , WAREHOUSE sth_giris_depo_no, STORE sth_cikis_depo_no
      , @today sth_malkbl_sevk_tarihi, '' sth_cari_srm_merkezi, '' sth_stok_srm_merkezi, @emptydate sth_fis_tarihi
      , 0 sth_fis_sirano, 0 sth_vergisiz_fl, 0 sth_maliyet_ana, 0 sth_maliyet_alternatif, 0 sth_maliyet_orjinal
      , 1 sth_adres_no, '' sth_parti_kodu, 0 sth_lot_no
      , @emptyguid sth_kons_uid, '' sth_proje_kodu, '' sth_exim_kodu, 0 sth_otv_pntr, 0 sth_otv_vergi, 0 sth_brutagirlik
      , 0 sth_disticaret_turu, 0 sth_otvtutari, 0 sth_otvvergisiz_fl
      , 0 sth_oiv_pntr, 0 sth_oiv_vergi, 0 sth_oivvergisiz_fl, 0 sth_fiyat_liste_no, 0 sth_oivtutari, 0 sth_Tevkifat_turu, 0 sth_nakliyedeposu, 0 sth_nakliyedurumu
      , @emptyguid sth_yetkili_uid, 0 sth_taxfree_fl, 0 sth_ilave_edilecek_kdv, '' sth_ismerkezi_kodu, '' sth_HareketGrupKodu1, '' sth_HareketGrupKodu2, '' sth_HareketGrupKodu3
      , 0 sth_Olcu1, 0 sth_Olcu2, 0 sth_Olcu3, 0 sth_Olcu4, 0 sth_Olcu5, 0 sth_FormulMiktarNo, 0 sth_FormulMiktar
      FROM #insert
  END;
END