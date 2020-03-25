CREATE PROCEDURE WHS_INS_WAYBILLBYTRANSFERPRODUCTID_SP @TransferProductId INT AS
BEGIN

  DECLARE @emptyguid nvarchar(40)
      SET @emptyguid = '00000000-0000-0000-0000-000000000000';

  DECLARE @emptydate datetime, @today DATE;
      SET @emptydate = CONVERT(DATETIME, '18991230', 112);
   SELECT @today = CAST(GETDATE() AS DATE)

  DECLARE @control INT
   SELECT @control = COUNT(*)
     FROM MIK_TRANSACTION20_SYN
    WHERE sth_evraktip = 2
      AND sth_evrakno_seri = 'OMT'
      AND sth_evrakno_sira = @TransferProductId;

  IF @control = 0
  BEGIN
    IF OBJECT_ID('tempdb.dbo.#insert', 'U') IS NOT NULL DROP TABLE #insert;

    SELECT TD.TRANSFERPRODUCTDETAILID, ROW_NUMBER() OVER (ORDER BY TD.TRANSFERPRODUCTDETAILID) ROWNO,
		   TP.SOURCESTORE, ST1.STORE_NM SOURCESTORENAME,
		   CASE TP.DESTINATIONSTORE WHEN 999 THEN 1000 + TP.RETURNDESTINATION ELSE TP.DESTINATIONSTORE END DESTINATIONSTORE, 
		   CASE TP.DESTINATIONSTORE WHEN 999 THEN W.WAREHOUSE_NM COLLATE Turkish_100_CI_AS ELSE ST2.STORE_NM END DESTINATIONSTORENAME,
		   P.CODE_NM PRODUCTCODE_NM, TD.QUANTITY_QTY QUANTITY,
		   CASE P.SALEVAT_RT WHEN 0 THEN 1 WHEN 1 THEN 2 WHEN 8 THEN 3 WHEN 18 THEN 4 END VATGROUP_CD
      INTO #insert
      FROM WHS_TRANSFERPRODUCT TP
      JOIN WHS_TRANSFERPRODUCTDETAIL TD ON TP.TRANSFERPRODUCTID = TD.TRANSFERPRODUCT AND TD.DELETED_FL = 'N'
      JOIN PRD_PRODUCT P ON TD.PRODUCT = P.PRODUCTID
	  JOIN STR_STORE ST1 ON ST1.STOREID = TP.SOURCESTORE
	  LEFT JOIN STR_STORE ST2 ON ST2.STOREID = TP.DESTINATIONSTORE
	  LEFT JOIN INV_WAREHOUSE_SYN W ON W.WAREHOUSEID =  1000 + TP.RETURNDESTINATION
     WHERE TP.TRANSFERPRODUCTID = @TransferProductId
                
    INSERT INTO MIK_TRANSACTION20_SYN
    SELECT NEWID() sth_Guid, 0 sth_DBCno, 0 sth_SpecRECno, 0 sth_iptal, 16 sth_fileid, 0 sth_hidden, 0 sth_kilitli, 0 sth_degisti, 0 sth_checksum, 10 sth_create_user
      , GETDATE() sth_create_date, 10 sth_lastup_user, GETDATE() sth_lastup_date, '' sth_special1, '' sth_special2, '' sth_special3, 0 sth_firmano, 0 sth_subeno
      , @today sth_tarih, 2 sth_tip, 6 sth_cins, 0 sth_normal_iade
      , 2 sth_evraktip, 'OMT' sth_evrakno_seri, @TransferProductId sth_evrakno_sira, ROWNO sth_satirno
      , cast(@TransferProductId AS VARCHAR(20)) sth_belge_no, @today sth_belge_tarih, PRODUCTCODE_NM sth_stok_kod
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
	  , LEFT('Ürün Transferi ' + SOURCESTORENAME + ' - ' + DESTINATIONSTORENAME,50) sth_aciklama
	  , @emptyguid sth_sip_uid, @emptyguid sth_fat_uid 
	  , DESTINATIONSTORE sth_giris_depo_no
	  , SOURCESTORE sth_cikis_depo_no
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

END;