CREATE procedure [dbo].[MIK_INS_FILLWORKDATATABLES_SP]  @StoreId int, @date date as    
begin    
 declare @datestring char(8)        
 set @datestring = convert(char(8), @date, 112);        
        
 declare @store char(3)        
 set @store = REPLACE(STR(@StoreId, 3), SPACE(1), '0');        
        
 exec MIK_INS_CREATEWORKDATATABLES_SP @StoreId, @date;        
 -- print '1:'+convert(varchar(50), getdate(), 120);   
 IF OBJECT_ID('tempdb.dbo.#SALEDETAIL', 'U') IS NOT NULL DROP TABLE #SALEDETAIL;         
 SELECT S.TRANSACTION_TM, SD.SALE, S.TRANSACTIONTYPE, S.COEFF      
      , CASE WHEN S.TRANSACTIONTYPE = 5 THEN 'I' ELSE 'K' END+RIGHT('000'+ISNULL(S.CASHREGISTER,''),3) CASHREGISTER, COALESCE(PC.MIKRO, P.CODE_NM) PRODUCTCODE_NM        
      , ROW_NUMBER() OVER (PARTITION BY SD.SALE ORDER BY SD.SALEDETAILID) - 1 ROWNO        
      , CASE WHEN P.UNIT = 1 THEN QUANTITY_QTY / 1000.0 ELSE QUANTITY_QTY END QUANTITY_QTY        
      , S.COEFF*PRICE PRICE      
      , S.COEFF*PRICE*VAT_RT/(100+VAT_RT) VAT_AMT        
      , CASE VAT_RT WHEN 0 THEN 1 WHEN 1 THEN 2 WHEN 8 THEN 3 WHEN 18 THEN 4 END VATGROUP_CD        
      , SALEROWNO, SD.BARCODE_TXT        
   INTO #SALEDETAIL        
   FROM SLS_SALEDETAIL SD (NOLOCK)    
   JOIN (SELECT S.TRANSACTION_TM, S.SALEID, S.CASHREGISTER, S.TRANSACTIONTYPE, CASE WHEN S.TRANSACTIONTYPE = 5 THEN -1 ELSE 1 END COEFF, ROW_NUMBER() OVER (PARTITION BY 1 ORDER BY SALEID) SALEROWNO        
           FROM SLS_SALE S (NOLOCK)      
		   LEFT JOIN ACC_INVOICE I (NOLOCK) ON S.SALEID = I.SALE AND I.DELETED_FL = 'N'
          WHERE S.TRANSACTION_DT = @date        
            AND S.STORE = @StoreId        
            AND S.CANCELLED_FL = 'N'
			AND (I.SALE IS NULL OR S.TRANSACTIONTYPE = 5)) S ON SD.SALE = S.SALEID        
   JOIN PRD_PRODUCT P (NOLOCK) ON SD.PRODUCT = P.PRODUCTID        
   LEFT JOIN MIK_PRODUCTCROSS PC (NOLOCK) ON SD.PRODUCT = PC.MAKTECH    
   -- JOIN (SELECT STORE, ROW_NUMBER() OVER (PARTITION BY STORE ORDER BY CASHREGISTERID) CRNO FROM STR_CASHREGISTER) CR ON SD.STORE = CR.STORE        
  WHERE SD.TRANSACTION_DT = @date        
    AND SD.STORE = @StoreId        
    AND SD.CANCEL_FL = 'N'        
 -- print '2:'+convert(varchar(50), getdate(), 120);         
 declare @emptyguid nvarchar(40)        
 set @emptyguid = '00000000-0000-0000-0000-000000000000';        
        
 declare @emptydate datetime;        
 set @emptydate = CONVERT(DATETIME, '18991230', 112);        
        
 IF OBJECT_ID('tempdb.dbo.#lines', 'U') IS NOT NULL DROP TABLE #lines;         
 select NEWID() sth_Guid, 0 sth_DBCno, 0 sth_SpecRECno, 0 sth_iptal, 1002 sth_fileid, 0 sth_hidden, 1 sth_kilitli, 0 sth_degisti, 0 sth_checksum, 1 sth_create_user        
      , GETDATE() sth_create_date, 1 sth_lastup_user, GETDATE() sth_lastup_date, '' sth_special1, '' sth_special2, '' sth_special3, 0 sth_firmano, 0 sth_subeno        
      , TRANSACTION_TM sth_tarih, case when coeff = -1 then 0 else 1 end sth_tip, 1 sth_cins, case when coeff = -1 then 1 else 0 end sth_normal_iade      
      , case when coeff = -1 then 13 else 1 end sth_evraktip, CASHREGISTER sth_evrakno_seri, SALEROWNO sth_evrakno_sira, ROWNO sth_satirno        
      , '' sth_belge_no, TRANSACTION_TM sth_belge_tarih, PRODUCTCODE_NM sth_stok_kod, 0 sth_isk_mas1, 0 sth_isk_mas2, 0 sth_isk_mas3, 0 sth_isk_mas4, 0 sth_isk_mas5         
      , 0 sth_isk_mas6, 0 sth_isk_mas7, 0 sth_isk_mas8, 0 sth_isk_mas9, 0 sth_isk_mas10, 0 sth_sat_iskmas1, 0 sth_sat_iskmas2, 0 sth_sat_iskmas3, 0 sth_sat_iskmas4        
      , 0 sth_sat_iskmas5, 0 sth_sat_iskmas6, 0 sth_sat_iskmas7, 0 sth_sat_iskmas8, 0 sth_sat_iskmas9, 0 sth_sat_iskmas10, 1 sth_pos_satis, 0 sth_promosyon_fl, 0 sth_cari_cinsi         
      , '' sth_cari_kodu, 0 sth_cari_grup_no, '' sth_isemri_gider_kodu, '' sth_plasiyer_kodu, 0 sth_har_doviz_cinsi, 0 sth_har_doviz_kuru, 0 sth_alt_doviz_kuru, 0 sth_stok_doviz_cinsi         
      , 0 sth_stok_doviz_kuru, QUANTITY_QTY sth_miktar, 0 sth_miktar2, 1 sth_birim_pntr, (PRICE-VAT_AMT) sth_tutar, 0 sth_iskonto1, 0 sth_iskonto2, 0 sth_iskonto3, 0 sth_iskonto4         
      , 0 sth_iskonto5, 0 sth_iskonto6, 0 sth_masraf1, 0 sth_masraf2, 0 sth_masraf3, 0 sth_masraf4, VATGROUP_CD sth_vergi_pntr, VAT_AMT sth_vergi        
      , 0 sth_masraf_vergi_pntr, 0 sth_masraf_vergi, 0 sth_netagirlik, '0' sth_odeme_op, BARCODE_TXT sth_aciklama, @emptyguid sth_sip_uid, @emptyguid sth_fat_uid         
      , case when coeff = -1 then @StoreId else 0 end sth_giris_depo_no, case when coeff = 1 then @StoreId else 0 end sth_cikis_depo_no      
      , @emptydate sth_malkbl_sevk_tarihi, '' sth_cari_srm_merkezi, '' sth_stok_srm_merkezi, @emptydate sth_fis_tarihi        
      , 0 sth_fis_sirano, 0 sth_vergisiz_fl, 0 sth_maliyet_ana, 0 sth_maliyet_alternatif, 0 sth_maliyet_orjinal, 0 sth_adres_no, '' sth_parti_kodu, 0 sth_lot_no         
      , @emptyguid sth_kons_uid, '' sth_proje_kodu, '' sth_exim_kodu, 0 sth_otv_pntr, 0 sth_otv_vergi, 0 sth_brutagirlik, 1 sth_disticaret_turu, 0 sth_otvtutari, 0 sth_otvvergisiz_fl         
      , 0 sth_oiv_pntr, 0 sth_oiv_vergi, 0 sth_oivvergisiz_fl, 0 sth_fiyat_liste_no, 0 sth_oivtutari, 0 sth_Tevkifat_turu, 0 sth_nakliyedeposu, 0 sth_nakliyedurumu        
      , @emptyguid sth_yetkili_uid, 0 sth_taxfree_fl, 0 sth_ilave_edilecek_kdv, '' sth_ismerkezi_kodu, '' sth_HareketGrupKodu1, '' sth_HareketGrupKodu2, '' sth_HareketGrupKodu3         
      , 0 sth_Olcu1, 0 sth_Olcu2, 0 sth_Olcu3, 0 sth_Olcu4, 0 sth_Olcu5, 0 sth_FormulMiktarNo, 0 sth_FormulMiktar        
   into #lines        
   from #SALEDETAIL        
 -- print '3:'+convert(varchar(50), getdate(), 120);               
 declare @stable varchar(200)        
 set @stable = '[MikroDB_V16_MAKBUL'+substring(@datestring,3,2)+'_WORKDATA].[dbo].[S_'+@datestring+'_'+@store+']';        
 declare @query varchar(max);        
 set @query = 'insert into '+@stable+' select * from #lines';        
 exec (@query);        
        
 IF OBJECT_ID('tempdb.dbo.#SALE', 'U') IS NOT NULL DROP TABLE #SALE;         
 SELECT SALEID, SALEROWNO, CASHREGISTER, CASHREGISTERID, TRANSACTION_TM, TOTAL_AMT, B.PRICETOTAL, TRANTYPE, TRANSACTIONTYPE       
      , B.VATTOTAL, B.PRICE0, B.VAT0, B.PRICE1, B.VAT1, B.PRICE8, B.VAT8, B.PRICE18, B.VAT18, C.CASH_AMT, C.CARD_AMT        
   INTO #SALE        
   FROM (        
 SELECT SALEID, CASE WHEN TRANSACTIONTYPE = 5 THEN 'I' ELSE 'K' END +RIGHT('000'+ISNULL(S.CASHREGISTER,''),3) CASHREGISTER, S.CASHREGISTER CASHREGISTERID,      
        TRANSACTION_TM, ABS(TOTAL_AMT) TOTAL_AMT, CASE WHEN TRANSACTIONTYPE = 5 THEN 'I' ELSE 'F' END TRANTYPE, TRANSACTIONTYPE,       
        ROW_NUMBER() OVER (PARTITION BY 1 ORDER BY SALEID) SALEROWNO      
   FROM SLS_SALE S (NOLOCK)     
   LEFT JOIN ACC_INVOICE I (NOLOCK) ON S.SALEID = I.SALE AND I.DELETED_FL = 'N'
  WHERE STORE = @StoreId        
    AND TRANSACTION_DT = @date      
	AND S.CANCELLED_FL = 'N'
	AND (I.SALE IS NULL OR S.TRANSACTIONTYPE = 5)) A        
   JOIN (        
 SELECT SALE, SUM(PRICE) PRICETOTAL, SUM(VAT) VATTOTAL        
      , SUM(CASE WHEN VAT_RT = 0 THEN PRICE ELSE 0 END) PRICE0        
      , SUM(CASE WHEN VAT_RT = 0 THEN VAT ELSE 0 END) VAT0        
      , SUM(CASE WHEN VAT_RT = 1 THEN PRICE ELSE 0 END) PRICE1        
      , SUM(CASE WHEN VAT_RT = 1 THEN VAT ELSE 0 END) VAT1        
      , SUM(CASE WHEN VAT_RT = 8 THEN PRICE ELSE 0 END) PRICE8        
      , SUM(CASE WHEN VAT_RT = 8 THEN VAT ELSE 0 END) VAT8        
      , SUM(CASE WHEN VAT_RT = 18 THEN PRICE ELSE 0 END) PRICE18        
      , SUM(CASE WHEN VAT_RT = 18 THEN VAT ELSE 0 END) VAT18        
   FROM (        
 SELECT SD.SALE, VAT_RT, SUM(ABS(PRICE)) PRICE, ROUND(SUM(ABS(PRICE)*VAT_RT/(100+VAT_RT)),2) VAT        
   FROM SLS_SALEDETAIL SD (NOLOCK)       
  WHERE STORE = @StoreId        
    AND TRANSACTION_DT = @date        
    AND CANCEL_FL = 'N'        
  GROUP BY SD.SALE, VAT_RT) A        
  GROUP BY SALE) B ON A.SALEID = B.SALE        
   JOIN (        
 SELECT SALE, ABS(PAID_AMT-REFUND_AMT) CASH_AMT, ABS(CARD_AMT) CARD_AMT        
   FROM SLS_SALEPAYMENT (NOLOCK)    
  WHERE STORE = @StoreId        
    AND TRANSACTION_DT = @date) C ON B.SALE = C.SALE;        
 -- print '4:'+convert(varchar(50), getdate(), 120);               
 IF OBJECT_ID('tempdb.dbo.#payment', 'U') IS NOT NULL DROP TABLE #payment;         
 select NEWID() po_Guid        
      , 0 po_DBCno, 0 po_SpecRECno, 0 po_iptal, 1003 po_fileid, 0 po_hidden, 0 po_kilitli, 0 po_degisti, 0 po_checksum, 1 po_create_user        
      , getdate() po_create_date, 1 po_lastup_user, getdate() po_lastup_date, '' po_special1, '' po_special2, '' po_special3, 0 po_firmano        
      , 0 po_subeno, CASHREGISTER po_KasaKodu, SALEROWNO po_BelgeNo, 0 po_MyeZNo, '' po_KasiyerKodu, TRANSACTION_TM po_BelgeTarihi        
      , TOTAL_AMT po_BelgeToplam, 0 po_VerMtrh0, PRICE0-VAT0 po_VerMtrh1, PRICE1-VAT1 po_VerMtrh2, PRICE8-VAT8 po_VerMtrh3, PRICE18-VAT18 po_VerMtrh4        
      , 0 po_VerMtrh5, 0 po_VerMtrh6, 0 po_VerMtrh7, 0 po_VerMtrh8, 0 po_VerMtrh9, 0 po_VerMtrh10        
      , VAT0 po_Vergi1, VAT1 po_Vergi2, VAT8 po_Vergi3, VAT18 po_Vergi4, 0 po_Vergi5, 0 po_Vergi6, 0 po_Vergi7, 0 po_Vergi8, 0 po_Vergi9, 0 po_Vergi10        
      , CASE WHEN TRANSACTIONTYPE = 2 THEN 1 ELSE 0 END po_Fisfatura, 1 po_Pozisyon, '' po_CariKodu, 0 po_Yuvarlama      
      , CASE WHEN TRANTYPE='I' THEN 0 ELSE CASH_AMT END po_Odm_AnaDtut1, CASE WHEN TRANTYPE='I' THEN 0 ELSE CASH_AMT END  po_Odm_OrjDtut1      
      , CASE WHEN TRANTYPE='I' THEN 0 ELSE CARD_AMT END po_Odm_AnaDtut2, CASE WHEN TRANTYPE='I' THEN 0 ELSE CARD_AMT END  po_Odm_OrjDtut2        
      , 0 po_Odm_AnaDtut3, 0 po_Odm_OrjDtut3, 0 po_Odm_AnaDtut4, 0 po_Odm_OrjDtut4, 0 po_Odm_AnaDtut5, 0 po_Odm_OrjDtut5        
      , 0 po_Odm_AnaDtut6, 0 po_Odm_OrjDtut6, 0 po_Odm_AnaDtut7, 0 po_Odm_OrjDtut7, 0 po_Odm_AnaDtut8, 0 po_Odm_OrjDtut8, 0 po_Odm_AnaDtut9, 0 po_Odm_OrjDtut9         
      , 0 po_Odm_AnaDtut10, 0 po_Odm_OrjDtut10, 0 po_Odm_AnaDtut11, 0 po_Odm_OrjDtut11, 0 po_Odm_AnaDtut12, 0 po_Odm_OrjDtut12, 0 po_Odm_AnaDtut13, 0 po_Odm_OrjDtut13         
      , 0 po_Odm_AnaDtut14, 0 po_Odm_OrjDtut14, 0 po_Odm_AnaDtut15, 0 po_Odm_OrjDtut15, 0 po_Odm_AnaDtut16, 0 po_Odm_OrjDtut16, 0 po_Odm_AnaDtut17, 0 po_Odm_OrjDtut17         
      , 0 po_Odm_AnaDtut18, 0 po_Odm_OrjDtut18, 0 po_Odm_AnaDtut19, 0 po_Odm_OrjDtut19, 0 po_Odm_AnaDtut20, 0 po_Odm_OrjDtut20, 0 po_Odm_AnaDtut21, 0 po_Odm_OrjDtut21         
      , 0 po_Odm_AnaDtut22, 0 po_Odm_OrjDtut22, 0 po_Odm_AnaDtut23, 0 po_Odm_OrjDtut23, 0 po_Odm_AnaDtut24, 0 po_Odm_OrjDtut24, 0 po_Odm_AnaDtut25, 0 po_Odm_OrjDtut25         
      , 0 po_Odm_AnaDtut26, 0 po_Odm_OrjDtut26, 0 po_Odm_AnaDtut27, 0 po_Odm_OrjDtut27, 0 po_Odm_AnaDtut28, 0 po_Odm_OrjDtut28, 0 po_Odm_AnaDtut29, 0 po_Odm_OrjDtut29        
      , 0 po_Odm_AnaDtut30, 0 po_Odm_OrjDtut30, 0 po_Odm_AnaDtut31, 0 po_Odm_OrjDtut31, 0 po_Odm_AnaDtut32, 0 po_Odm_OrjDtut32, 0 po_Odm_AnaDtut33, 0 po_Odm_OrjDtut33         
      , 0 po_Odm_AnaDtut34, 0 po_Odm_OrjDtut34, 0 po_Odm_AnaDtut35, 0 po_Odm_OrjDtut35, 0 po_Odm_AnaDtut36, 0 po_Odm_OrjDtut36, 0 po_Odm_AnaDtut37, 0 po_Odm_OrjDtut37         
      , 0 po_Odm_AnaDtut38, 0 po_Odm_OrjDtut38, 0 po_Odm_AnaDtut39, 0 po_Odm_OrjDtut39, 0 po_Odm_AnaDtut40, 0 po_Odm_OrjDtut40, 0 po_Odm_AnaDtut41, 0 po_Odm_OrjDtut41         
      , 0 po_Odm_AnaDtut42, 0 po_Odm_OrjDtut42, 0 po_Odm_AnaDtut43, 0 po_Odm_OrjDtut43, 0 po_Odm_AnaDtut44, 0 po_Odm_OrjDtut44, 0 po_Odm_AnaDtut45, 0 po_Odm_OrjDtut45         
      , 0 po_Odm_AnaDtut46, 0 po_Odm_OrjDtut46, 0 po_Odm_AnaDtut47, 0 po_Odm_OrjDtut47, 0 po_Odm_AnaDtut48, 0 po_Odm_OrjDtut48, 0 po_Odm_AnaDtut49, 0 po_Odm_OrjDtut49         
      , CASE WHEN TRANTYPE='I' THEN CASH_AMT ELSE 0 END po_Odm_AnaDtut50, CASE WHEN TRANTYPE='I' THEN CASH_AMT ELSE 0 END  po_Odm_OrjDtut50      
      , 0 po_Vadeler_OdemeTipi1, @emptydate po_Vadeler_vade1, 0 po_Vadeler_Tutar1        
      , 0 po_Vadeler_OdemeTipi2, @emptydate po_Vadeler_vade2, 0 po_Vadeler_Tutar2, 0 po_Vadeler_OdemeTipi3, @emptydate po_Vadeler_vade3, 0 po_Vadeler_Tutar3         
      , 0 po_Vadeler_OdemeTipi4, @emptydate po_Vadeler_vade4, 0 po_Vadeler_Tutar4, 0 po_Vadeler_OdemeTipi5, @emptydate po_Vadeler_vade5, 0 po_Vadeler_Tutar5         
      , 0 po_Vadeler_OdemeTipi6, @emptydate po_Vadeler_vade6, 0 po_Vadeler_Tutar6, 0 po_Vadeler_OdemeTipi7, @emptydate po_Vadeler_vade7, 0 po_Vadeler_Tutar7         
      , 0 po_Vadeler_OdemeTipi8, @emptydate po_Vadeler_vade8, 0 po_Vadeler_Tutar8, 0 po_Vadeler_OdemeTipi9, @emptydate po_Vadeler_vade9, 0 po_Vadeler_Tutar9         
      , 0 po_Vadeler_OdemeTipi10, @emptydate po_Vadeler_vade10, 0 po_Vadeler_Tutar10, 0 po_Vadeler_OdemeTipi11, @emptydate po_Vadeler_vade11, 0 po_Vadeler_Tutar11         
      , 0 po_Vadeler_OdemeTipi12, @emptydate po_Vadeler_vade12, 0 po_Vadeler_Tutar12, 0 po_Vadeler_OdemeTipi13, @emptydate po_Vadeler_vade13, 0 po_Vadeler_Tutar13         
      , 0 po_Vadeler_OdemeTipi14, @emptydate po_Vadeler_vade14, 0 po_Vadeler_Tutar14, 0 po_Vadeler_OdemeTipi15, @emptydate po_Vadeler_vade15, 0 po_Vadeler_Tutar15        
      , 0 po_Vadeler_OdemeTipi16, @emptydate po_Vadeler_vade16, 0 po_Vadeler_Tutar16, 0 po_Vadeler_OdemeTipi17, @emptydate po_Vadeler_vade17, 0 po_Vadeler_Tutar17         
      , 0 po_Vadeler_OdemeTipi18, @emptydate po_Vadeler_vade18, 0 po_Vadeler_Tutar18, 0 po_Vadeler_OdemeTipi19, @emptydate po_Vadeler_vade19, 0 po_Vadeler_Tutar19         
      , 0 po_Vadeler_OdemeTipi20, @emptydate po_Vadeler_vade20, 0 po_Vadeler_Tutar20, 0 po_Vadeler_OdemeTipi21, @emptydate po_Vadeler_vade21, 0 po_Vadeler_Tutar21         
      , 0 po_Vadeler_OdemeTipi22, @emptydate po_Vadeler_vade22, 0 po_Vadeler_Tutar22, 0 po_Vadeler_OdemeTipi23, @emptydate po_Vadeler_vade23, 0 po_Vadeler_Tutar23         
      , 0 po_Vadeler_OdemeTipi24, @emptydate po_Vadeler_vade24, 0 po_Vadeler_Tutar24, 0 po_Vadeler_OdemeTipi25, @emptydate po_Vadeler_vade25, 0 po_Vadeler_Tutar25         
      , 0 po_Vadeler_OdemeTipi26, @emptydate po_Vadeler_vade26, 0 po_Vadeler_Tutar26, 0 po_Vadeler_OdemeTipi27, @emptydate po_Vadeler_vade27, 0 po_Vadeler_Tutar27         
      , 0 po_Vadeler_OdemeTipi28, @emptydate po_Vadeler_vade28, 0 po_Vadeler_Tutar28, 0 po_Vadeler_OdemeTipi29, @emptydate po_Vadeler_vade29, 0 po_Vadeler_Tutar29         
      , 0 po_Vadeler_OdemeTipi30, @emptydate po_Vadeler_vade30, 0 po_Vadeler_Tutar30, 0 po_Vadeler_OdemeTipi31, @emptydate po_Vadeler_vade31, 0 po_Vadeler_Tutar31         
      , 0 po_Vadeler_OdemeTipi32, @emptydate po_Vadeler_vade32, 0 po_Vadeler_Tutar32, 0 po_Vadeler_OdemeTipi33, @emptydate po_Vadeler_vade33, 0 po_Vadeler_Tutar33         
      , 0 po_Vadeler_OdemeTipi34, @emptydate po_Vadeler_vade34, 0 po_Vadeler_Tutar34, 0 po_Vadeler_OdemeTipi35, @emptydate po_Vadeler_vade35, 0 po_Vadeler_Tutar35         
      , 0 po_Vadeler_OdemeTipi36, @emptydate po_Vadeler_vade36, 0 po_Vadeler_Tutar36, 0 po_Tks_Satis, 0 po_Tks_Satis_Tutar, 0 po_Odm_TaksitTipi1, 0 po_Odm_TaksitTipi2         
      , 0 po_Odm_TaksitTipi3, 0 po_Odm_TaksitTipi4, 0 po_Odm_TaksitTipi5, 0 po_Odm_TaksitTipi6, 0 po_Odm_TaksitTipi7, 0 po_Odm_TaksitTipi8, 0 po_Odm_TaksitTipi9, 0 po_Odm_TaksitTipi10         
      , 0 po_Odm_TaksitTipi11, 0 po_Odm_TaksitTipi12, 0 po_Odm_TaksitTipi13, 0 po_Odm_TaksitTipi14, 0 po_Odm_TaksitTipi15, 0 po_Odm_TaksitTipi16, 0 po_Odm_TaksitTipi17, 0 po_Odm_TaksitTipi18         
      , 0 po_Odm_TaksitTipi19, 0 po_Odm_TaksitTipi20, 0 po_Odm_TaksitTipi21, 0 po_Odm_TaksitTipi22, 0 po_Odm_TaksitTipi23, 0 po_Odm_TaksitTipi24, 0 po_Odm_TaksitTipi25, 0 po_Odm_TaksitTipi26         
      , 0 po_Odm_TaksitTipi27, 0 po_Odm_TaksitTipi28, 0 po_Odm_TaksitTipi29, 0 po_Odm_TaksitTipi30, 0 po_Odm_TaksitTipi31, 0 po_Odm_TaksitTipi32, 0 po_Odm_TaksitTipi33, 0 po_Odm_TaksitTipi34         
      , 0 po_Odm_TaksitTipi35, 0 po_Odm_TaksitTipi36, 0 po_Odm_TaksitTipi37, 0 po_Odm_TaksitTipi38, 0 po_Odm_TaksitTipi39, 0 po_Odm_TaksitTipi40, 0 po_Odm_TaksitTipi41, 0 po_Odm_TaksitTipi42         
      , 0 po_Odm_TaksitTipi43, 0 po_Odm_TaksitTipi44, 0 po_Odm_TaksitTipi45, 0 po_Odm_TaksitTipi46, 0 po_Odm_TaksitTipi47, 0 po_Odm_TaksitTipi48, 0 po_Odm_TaksitTipi49, 0 po_Odm_TaksitTipi50         
      , 0 po_OdemeNo1, '' po_ProvizyonKodu1, 0 po_ProvizyonTutari1, 0 po_OdemeNo2, '' po_ProvizyonKodu2, 0 po_ProvizyonTutari2, 0 po_OdemeNo3, '' po_ProvizyonKodu3, 0 po_ProvizyonTutari3        
      , 0 po_OdemeNo4, '' po_ProvizyonKodu4, 0 po_ProvizyonTutari4, 0 po_OdemeNo5, '' po_ProvizyonKodu5, 0 po_ProvizyonTutari5, 0 po_OdemeNo6, '' po_ProvizyonKodu6, 0 po_ProvizyonTutari6         
      , '' po_Tahsilat_evrakno_seri, 0 po_Tahsilat_evrakno_sira, 0 po_Tahsilat_Tutari, 0 po_ParaUstuOdemeTipi, 0 po_ParaUstuAnaDtut, 0 po_ParaUstuOrjDtut        
      , NEWID() po_EvrakID, 0 po_AdresNo, '' po_EArsivSeri, 0 po_EArsivSira, 0 po_ZNo, 0 po_FNo, 0 po_EJNo, '' po_OKCEvrakID, '' po_YolcuBeraberKod, '' po_YolcuBeraberIstisnaKodu, '' po_YolcuBeraberAraciKurumKodu        
   into #payment        
   from #SALE         
 -- print '5:'+convert(varchar(50), getdate(), 120);               
 declare @otable varchar(200)        
 set @otable = '[MikroDB_V16_MAKBUL'+substring(@datestring,3,2)+'_WORKDATA].[dbo].[O_'+@datestring+'_'+@store+']';        
 set @query = 'insert into '+@otable+' select * from #payment';        
 exec (@query);        
 -- print '6:'+convert(varchar(50), getdate(), 120);             
 INSERT INTO MIK_SALEEXPORTLOG VALUES (@StoreId, @Date, GETDATE());  
   
end;