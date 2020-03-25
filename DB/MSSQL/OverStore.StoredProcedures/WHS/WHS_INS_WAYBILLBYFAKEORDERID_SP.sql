CREATE PROCEDURE WHS_INS_WAYBILLBYFAKEORDERID_SP @FakeOrderId int AS
BEGIN
 DECLARE @emptyguid nvarchar(40)
     SET @emptyguid = '00000000-0000-0000-0000-000000000000';

 DECLARE @emptydate datetime;
     SET @emptydate = CONVERT(DATETIME, '18991230', 112);

    IF OBJECT_ID('tempdb.dbo.#insert', 'U') IS NOT NULL DROP TABLE #insert;

 --   SELECT OD.STOREORDER, O.STORE, O.ORDER_DT, O.SHIPMENT_DT, 0 ROWNO, P.CODE_NM PRODUCTCODE_NM
	--     , I.QUANTITYDIF_QTY, CASE WHEN I.QUANTITYDIF_QTY < 0 THEN @eksikGelen ELSE @fazlaGelen END DIFFTYPE_TXT
	--	 , CASE P.SALEVAT_RT WHEN 0 THEN 1 WHEN 1 THEN 2 WHEN 8 THEN 3 WHEN 18 THEN 4 END VATGROUP_CD
	--	 , STORE_NM, SOH.HISTORY_TM
 --     INTO #insert
 --     FROM WHS_INTAKESTATUS I
 --     JOIN WHS_STOREORDERDETAIL (NOLOCK) OD ON I.STOREORDERDETAIL = OD.STOREORDERDETAILID
	--  JOIN WHS_STOREORDER (NOLOCK) O ON OD.STOREORDER = O.STOREORDERID
 --     JOIN PRD_PRODUCT P ON OD.PRODUCT = P.PRODUCTID
 --     JOIN STR_STORE ST ON O.STORE = ST.STOREID
	--  JOIN (SELECT STOREORDER, HISTORY_TM, ROW_NUMBER() OVER (PARTITION BY STOREORDER ORDER BY HISTORY_TM DESC) ROWNO
 -- 		      FROM WHS_STOREORDERHISTORY H
 -- 		     WHERE STATUS = 5) SOH ON O.STOREORDERID = SOH.STOREORDER AND SOH.ROWNO = 1
 --    WHERE OD.STOREORDERDETAILID = @StoreOrderDetailId
	--   AND P.DELETED_FL = 'N'
	--   AND P.ACTIVE_FL = 'Y'
	--   AND BP.PRODUCT IS NULL
	--   AND P.SUPERGROUP3 NOT IN (1,3)
 
 --  DECLARE @Control INT, @StoreOrderId INT, @DiffType NVARCHAR(2), @ProductCodeName NVARCHAR(50)
 --  SELECT @StoreOrderId = STOREORDER, @DiffType = DIFFTYPE_TXT, @ProductCodeName = PRODUCTCODE_NM FROM #insert
   
 --  SELECT @Control = COUNT(*)
 --    FROM MIK_TRANSACTION_SYN MT
 --   WHERE MT.sth_evraktip = 2
 --     AND MT.sth_evrakno_seri = @DiffType
 -- 	  AND MT.sth_evrakno_sira = @StoreOrderId
	--  AND MT.sth_stok_kod = @ProductCodeName


 -- IF @control = 0
 -- BEGIN
  
 --   DECLARE @satirno INT
	--SELECT @satirno = ISNULL(MAX(sth_satirno),0)+1 
	--  FROM MIK_TRANSACTION_SYN MT
 --    WHERE MT.sth_evraktip = 2
 --      AND MT.sth_evrakno_seri = @DiffType
 -- 	   AND MT.sth_evrakno_sira = @StoreOrderId

 --   INSERT INTO MIK_TRANSACTION_SYN
 --   SELECT NEWID() sth_Guid, 0 sth_DBCno, 0 sth_SpecRECno, 0 sth_iptal, 16 sth_fileid, 0 sth_hidden, 0 sth_kilitli, 0 sth_degisti, 0 sth_checksum, 10 sth_create_user
 --     , GETDATE() sth_create_date, 10 sth_lastup_user, GETDATE() sth_lastup_date, '' sth_special1, '' sth_special2, '' sth_special3, 0 sth_firmano, 0 sth_subeno
 --     , HISTORY_TM sth_tarih, 2 sth_tip, 6 sth_cins, 0 sth_normal_iade
 --     , 2 sth_evraktip, DIFFTYPE_TXT sth_evrakno_seri, STOREORDER sth_evrakno_sira, @satirno sth_satirno
 --     , '' sth_belge_no, HISTORY_TM sth_belge_tarih, PRODUCTCODE_NM sth_stok_kod
 --     , 0 sth_isk_mas1, 1 sth_isk_mas2, 1 sth_isk_mas3, 1 sth_isk_mas4, 1 sth_isk_mas5
 --     , 1 sth_isk_mas6, 1 sth_isk_mas7, 1 sth_isk_mas8, 1 sth_isk_mas9, 1 sth_isk_mas10
 --     , 0 sth_sat_iskmas1, 0 sth_sat_iskmas2, 0 sth_sat_iskmas3, 0 sth_sat_iskmas4, 0 sth_sat_iskmas5
 --     , 0 sth_sat_iskmas6, 0 sth_sat_iskmas7, 0 sth_sat_iskmas8, 0 sth_sat_iskmas9, 0 sth_sat_iskmas10
 --     , 0 sth_pos_satis, 0 sth_promosyon_fl, 0 sth_cari_cinsi
 --     , '' sth_cari_kodu, 0 sth_cari_grup_no, '' sth_isemri_gider_kodu, '' sth_plasiyer_kodu
 --     , 0 sth_har_doviz_cinsi, 1 sth_har_doviz_kuru, 1 sth_alt_doviz_kuru, 0 sth_stok_doviz_cinsi
 --     , 1 sth_stok_doviz_kuru, ABS(QUANTITYDIF_QTY) sth_miktar, 0 sth_miktar2, 1 sth_birim_pntr, 0 sth_tutar
 --     , 0 sth_iskonto1, 0 sth_iskonto2, 0 sth_iskonto3, 0 sth_iskonto4, 0 sth_iskonto5, 0 sth_iskonto6
 --     , 0 sth_masraf1, 0 sth_masraf2, 0 sth_masraf3, 0 sth_masraf4, VATGROUP_CD sth_vergi_pntr, 0 sth_vergi
 --     , 0 sth_masraf_vergi_pntr, 0 sth_masraf_vergi, 0 sth_netagirlik, '0' sth_odeme_op
 --     , CASE DIFFTYPE_TXT WHEN @eksikGelen THEN @eksikGelen + ' Mağazaya Eksik Gelen Ürün ' WHEN @fazlaGelen THEN @fazlaGelen + ' Depodan Fazla Gönderilen Ürün 'END + STORE_NM sth_aciklama
	--  , @emptyguid sth_sip_uid, @emptyguid sth_fat_uid 
	--  , CASE DIFFTYPE_TXT WHEN @eksikGelen THEN 1001 WHEN @fazlaGelen THEN STORE END sth_giris_depo_no
	--  , CASE DIFFTYPE_TXT WHEN @eksikGelen THEN STORE WHEN @fazlaGelen THEN 1001 END  sth_cikis_depo_no
 --     , HISTORY_TM sth_malkbl_sevk_tarihi, '' sth_cari_srm_merkezi, '' sth_stok_srm_merkezi, @emptydate sth_fis_tarihi
 --     , 0 sth_fis_sirano, 0 sth_vergisiz_fl, 0 sth_maliyet_ana, 0 sth_maliyet_alternatif, 0 sth_maliyet_orjinal
 --     , 1 sth_adres_no, '' sth_parti_kodu, 0 sth_lot_no
 --     , @emptyguid sth_kons_uid, '' sth_proje_kodu, '' sth_exim_kodu, 0 sth_otv_pntr, 0 sth_otv_vergi, 0 sth_brutagirlik
 --     , 0 sth_disticaret_turu, 0 sth_otvtutari, 0 sth_otvvergisiz_fl
 --     , 0 sth_oiv_pntr, 0 sth_oiv_vergi, 0 sth_oivvergisiz_fl, 0 sth_fiyat_liste_no, 0 sth_oivtutari, 0 sth_Tevkifat_turu, 0 sth_nakliyedeposu, 0 sth_nakliyedurumu
 --     , @emptyguid sth_yetkili_uid, 0 sth_taxfree_fl, 0 sth_ilave_edilecek_kdv, '' sth_ismerkezi_kodu, '' sth_HareketGrupKodu1, '' sth_HareketGrupKodu2, '' sth_HareketGrupKodu3
 --     , 0 sth_Olcu1, 0 sth_Olcu2, 0 sth_Olcu3, 0 sth_Olcu4, 0 sth_Olcu5, 0 sth_FormulMiktarNo, 0 sth_FormulMiktar
 --     FROM #insert

	--  UPDATE WHS_INTAKESTATUS
	--     SET MIKROTRANSFER_FL = 'Y'
	--   WHERE STOREORDERDETAIL = @StoreOrderDetailId;
 -- END;

END;