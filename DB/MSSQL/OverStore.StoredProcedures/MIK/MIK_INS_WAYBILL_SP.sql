CREATE PROCEDURE MIK_INS_WAYBILL_SP 
  @TransactionDate DATE,
  @DocumentSerial VARCHAR(30),
  @DocumentNo INT,
  @DocumentRowNo INT,
  @DocumentInfo VARCHAR(20),
  @TransactionType INT,
  @TransactionKind INT,
  @IsRefund INT,
  @DocumentType INT,
  @DocumentDate DATE,
  @ProductCode VARCHAR(100),
  @Quantity NUMERIC(18,6),
  @VATCode INT,
  @Description VARCHAR(1000),
  @ReceiverWarehouse INT,
  @SenderWarehouse INT,
  @IntakeShipmentDate DATE AS
BEGIN
  DECLARE @emptyguid nvarchar(40)                      
  SET @emptyguid = '00000000-0000-0000-0000-000000000000';                      
                      
  DECLARE @emptydate datetime, @today DATE;                      
  SET @emptydate = CONVERT(DATETIME, '18991230', 112);    

  INSERT INTO MIK_TRANSACTION20_SYN                  
    SELECT NEWID() sth_Guid, 0 sth_DBCno, 0 sth_SpecRECno, 0 sth_iptal, 16 sth_fileid, 0 sth_hidden, 0 sth_kilitli, 0 sth_degisti, 0 sth_checksum, 10 sth_create_user                      
      , GETDATE() sth_create_date, 10 sth_lastup_user, GETDATE() sth_lastup_date, '' sth_special1, '' sth_special2, '' sth_special3, 0 sth_firmano, 0 sth_subeno                      
      , @TransactionDate sth_tarih, @TransactionType sth_tip, @TransactionKind sth_cins, @IsRefund sth_normal_iade                    
      , @DocumentType sth_evraktip, @DocumentSerial sth_evrakno_seri, @DocumentNo sth_evrakno_sira, @DocumentRowNo sth_satirno                      
      , @DocumentInfo sth_belge_no, @DocumentDate sth_belge_tarih, @ProductCode sth_stok_kod                  
      , 0 sth_isk_mas1, 1 sth_isk_mas2, 1 sth_isk_mas3, 1 sth_isk_mas4, 1 sth_isk_mas5                       
      , 1 sth_isk_mas6, 1 sth_isk_mas7, 1 sth_isk_mas8, 1 sth_isk_mas9, 1 sth_isk_mas10                  
      , 0 sth_sat_iskmas1, 0 sth_sat_iskmas2, 0 sth_sat_iskmas3, 0 sth_sat_iskmas4, 0 sth_sat_iskmas5                  
      , 0 sth_sat_iskmas6, 0 sth_sat_iskmas7, 0 sth_sat_iskmas8, 0 sth_sat_iskmas9, 0 sth_sat_iskmas10                  
      , 0 sth_pos_satis, 0 sth_promosyon_fl, 0 sth_cari_cinsi                       
      , '' sth_cari_kodu, 0 sth_cari_grup_no, '' sth_isemri_gider_kodu, '' sth_plasiyer_kodu                  
      , 0 sth_har_doviz_cinsi, 1 sth_har_doviz_kuru, 1 sth_alt_doviz_kuru, 0 sth_stok_doviz_cinsi                       
      , 1 sth_stok_doviz_kuru, @Quantity sth_miktar, 0 sth_miktar2, 1 sth_birim_pntr, 0 sth_tutar                  
      , 0 sth_iskonto1, 0 sth_iskonto2, 0 sth_iskonto3, 0 sth_iskonto4, 0 sth_iskonto5, 0 sth_iskonto6                  
      , 0 sth_masraf1, 0 sth_masraf2, 0 sth_masraf3, 0 sth_masraf4, @VATCode sth_vergi_pntr, 0 sth_vergi                      
      , 0 sth_masraf_vergi_pntr, 0 sth_masraf_vergi, 0 sth_netagirlik, '0' sth_odeme_op                  
      , @Description sth_aciklama, @emptyguid sth_sip_uid, @emptyguid sth_fat_uid                       
      , @ReceiverWarehouse sth_giris_depo_no, @SenderWarehouse sth_cikis_depo_no                    
      , @IntakeShipmentDate sth_malkbl_sevk_tarihi, '' sth_cari_srm_merkezi, '' sth_stok_srm_merkezi, @emptydate sth_fis_tarihi                      
      , 0 sth_fis_sirano, 0 sth_vergisiz_fl, 0 sth_maliyet_ana, 0 sth_maliyet_alternatif, 0 sth_maliyet_orjinal                  
      , 1 sth_adres_no, '' sth_parti_kodu, 0 sth_lot_no         
      , @emptyguid sth_kons_uid, '' sth_proje_kodu, '' sth_exim_kodu, 0 sth_otv_pntr, 0 sth_otv_vergi, 0 sth_brutagirlik             
      , 0 sth_disticaret_turu, 0 sth_otvtutari, 0 sth_otvvergisiz_fl                       
      , 0 sth_oiv_pntr, 0 sth_oiv_vergi, 0 sth_oivvergisiz_fl, 0 sth_fiyat_liste_no, 0 sth_oivtutari, 0 sth_Tevkifat_turu, 0 sth_nakliyedeposu, 0 sth_nakliyedurumu                      
      , @emptyguid sth_yetkili_uid, 0 sth_taxfree_fl, 0 sth_ilave_edilecek_kdv, '' sth_ismerkezi_kodu, '' sth_HareketGrupKodu1, '' sth_HareketGrupKodu2, '' sth_HareketGrupKodu3                       
      , 0 sth_Olcu1, 0 sth_Olcu2, 0 sth_Olcu3, 0 sth_Olcu4, 0 sth_Olcu5, 0 sth_FormulMiktarNo, 0 sth_FormulMiktar     
END