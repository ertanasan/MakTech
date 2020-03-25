CREATE PROCEDURE MIK_INS_PAYROLL_SP @Year INT, @Month INT AS  
BEGIN  
 -- DECLARE @Year INT = 2019
 -- DECLARE @Month INT = 11
 DECLARE @FisSiraNo INT, @FisYevmiyeNo INT, @TranNo BIGINT   
  
 DECLARE @emptyguid nvarchar(40)                        
 SET @emptyguid = '00000000-0000-0000-0000-000000000000';                        
 DECLARE @emptydate datetime, @today DATE;                        
 SET @emptydate = CONVERT(DATETIME, '18991230', 112);           
 SET @today = CAST(GETDATE() AS DATE)  
 DECLARE @evraktip INT = 33  
 DECLARE @Day DATE;  
 SELECT @Day = MAX(DATE_DT) FROM RPT_DATE WHERE YEAR_NO = @Year AND MONTH_NO = @Month  
 DECLARE @aciklama VARCHAR(4000)  
 SELECT @aciklama = CAST(@Year AS varchar)+' '+MONTHTR_ACK+' Bordro Tahakkuku ' FROM RPT_MONTH WHERE MONTHID = @Month  
  
 SELECT @TranNo = ISNULL(MAX(cha_evrakno_sira),0)+1 FROM MIK_CURRENTTRANSACTION19_SYN WHERE cha_evrakno_seri = 'MBDR'  
 SELECT @FisSiraNo = ISNULL(MAX(fis_sira_no), 0)+1 FROM MIK_ACCOUNTING19_SYN (NOLOCK)  WHERE fis_tarih = @Day;  -- fis_firmano = 0 AND fis_maliyil = YEAR(@today); -- AND   
 SELECT @FisYevmiyeNo = ISNULL(MAX(fis_yevmiye_no), 0)+1 FROM MIK_ACCOUNTING19_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@Day); -- AND fis_tarih = @today;    
 -- SELECT @TranNo, @FisSiraNo, @FisYevmiyeNo  
    
 IF OBJECT_ID('tempdb..#payroll') IS NOT NULL DROP TABLE #payroll  
 IF OBJECT_ID('tempdb..#transactions') IS NOT NULL DROP TABLE #transactions  
 IF OBJECT_ID('tempdb..#accrows') IS NOT NULL DROP TABLE #accrows  
  
 SELECT P.*, E.EMPLOYEE_NM, D.DEPARTMENT_NM, D.EXPENSECENTER_TXT, WORKINGTYPE_DSC  
   INTO #payroll  
   FROM ACC_PAYROLL P  
   JOIN STR_EMPLOYEE E ON P.EMPLOYEE = E.EMPLOYEEID  
   JOIN ACC_DEPARTMENT D ON E.DEPARTMENT_CD = D.DEPARTMENTID  
  WHERE P.YEAR_CD = @Year  
    AND P.MONTH_CD = @Month  
  
 -- SELECT SUM(ISNULL(PAY_AMT, 0)+ ISNULL(ANNUALLEAVEPAY_AMT, 0) + ISNULL(PAIDLEAVEWEXCUSEPAY_AMT, 0)) FROM #payroll  
 -- WHERE (ISNULL(PAY_AMT, 0) + ISNULL(ANNUALLEAVEPAY_AMT, 0) + ISNULL(PAIDLEAVEWEXCUSEPAY_AMT, 0)) > 0  
 
 SELECT *, ROW_NUMBER() OVER (ORDER BY ACCOUNTCODE DESC, EXPENSECENTER_TXT) ROWNO  
   INTO #transactions  
   FROM (  
  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.001' ELSE '760.01.001' END ACCOUNTCODE,   
		(ISNULL(PAY_AMT, 0) + ISNULL(ANNUALLEAVEPAY_AMT, 0) + ISNULL(PAIDLEAVEWEXCUSEPAY_AMT, 0)) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE (ISNULL(PAY_AMT, 0) + ISNULL(ANNUALLEAVEPAY_AMT, 0) + ISNULL(PAIDLEAVEWEXCUSEPAY_AMT, 0)) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.014' ELSE '760.01.014' END ACCOUNTCODE,   
		ISNULL(LEGALHOLIDAYPAY_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(LEGALHOLIDAYPAY_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.007' ELSE '760.01.007' END ACCOUNTCODE,   
		ISNULL(OVERTIMEPAY_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(OVERTIMEPAY_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.010' ELSE '760.01.010' END ACCOUNTCODE,   
		ISNULL(CASHINDEMNITY_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(CASHINDEMNITY_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.013' ELSE '760.01.013' END ACCOUNTCODE,   
		ISNULL(FOODALLOWANCE_AMT,0) + ISNULL(FOODALLOWANCEDAY_CNT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE (ISNULL(FOODALLOWANCE_AMT,0) + ISNULL(FOODALLOWANCEDAY_CNT,0)) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.006' ELSE '760.01.006' END ACCOUNTCODE,   
		ISNULL(LEAVEPAY_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(LEAVEPAY_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.004' ELSE '760.01.004' END ACCOUNTCODE,   
		ISNULL(SEVERANCEPAY_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(SEVERANCEPAY_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT,   
		CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001')   
			 THEN CASE WHEN WORKINGTYPE_DSC = 'EMEKLİ' THEN '770.01.0012' ELSE '770.01.002' END   
			 ELSE CASE WHEN WORKINGTYPE_DSC = 'EMEKLİ' THEN '760.01.0012' ELSE '760.01.002' END   
		END ACCOUNTCODE,   
		ISNULL(INSURANCECUTEMPLOYER_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(INSURANCECUTEMPLOYER_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, EXPENSECENTER_TXT, CASE WHEN EXPENSECENTER_TXT IN ('10202001', '10802001') THEN '770.01.003' ELSE '760.01.003' END ACCOUNTCODE,   
		ISNULL(UNEMPLOYMENTPREMIUMEMPLOYER_AMT,0) AMOUNT, EMPLOYEE_NM  
   FROM #payroll PR  
  WHERE ISNULL(UNEMPLOYMENTPREMIUMEMPLOYER_AMT,0) > 0  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '136.01.001' ACCOUNTCODE, AMOUNT, ''   
   FROM (  
 SELECT SUM(ISNULL(MINLIVINGALLOWANCE_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.002' ACCOUNTCODE, AMOUNT, ''
   FROM (  
 SELECT SUM(ISNULL(ADVANCE_AMT,0)) AMOUNT  
   FROM #payroll PR) A
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.006' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INSTALLMENTPAYCUT_AMT,0)+ISNULL(PAYCUT_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.007' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(CASHDEFICIT_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.003' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INSURANCECUT_AMT, 0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.004' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(ALIMONYCUT_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.005' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(EXECUTIONDEDUCTION1_AMT,0) + ISNULL(EXECUTIONDEDUCTION2_AMT,0) + ISNULL(EXECUTIONDEDUCTION3_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT CASE WHEN WORKINGTYPE_DSC = 'EMEKLİ' THEN '361.01.005' ELSE '361.01.001' END ACCOUNTCODE  
	  , SUM(ISNULL(TOTALINSURANCEPREM_AMT,0)) AMOUNT
   FROM #payroll PR  
  GROUP BY CASE WHEN WORKINGTYPE_DSC = 'EMEKLİ' THEN '361.01.005' ELSE '361.01.001' END) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '361.01.002' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(TOTALUNEMPLOYMENTPREM_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '360.01.004' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(STAMPTAX_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '602.03.001' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INCENTIVESHARE5510_AMT,0)) AMOUNT  
   FROM #payroll PR
 HAVING SUM(ISNULL(INCENTIVESHARE5510_AMT,0)) > 0) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '602.03.002' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INCENTIVESHARE6111_AMT,0)) AMOUNT  
   FROM #payroll PR
 HAVING SUM(ISNULL(INCENTIVESHARE6111_AMT,0)) > 0) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '602.03.006' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INCENTIVESHARE2828_AMT,0) + ISNULL(UNEMPLOYMENTINCENTIVESHARE_AMT,0)) AMOUNT  
   FROM #payroll PR
 HAVING SUM(ISNULL(INCENTIVESHARE2828_AMT,0) + ISNULL(UNEMPLOYMENTINCENTIVESHARE_AMT,0)) > 0) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '602.03.004' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INCENTIVESHARE27103_AMT,0) + ISNULL(INCOMETAXINCENTIVESHARE_AMT,0) + ISNULL(UNEMPLOYMENTINCENTIVE687_AMT,0)) AMOUNT  
   FROM #payroll PR
 HAVING SUM(ISNULL(INCENTIVESHARE27103_AMT,0) + ISNULL(INCOMETAXINCENTIVESHARE_AMT,0) + ISNULL(UNEMPLOYMENTINCENTIVE687_AMT,0)) > 0) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '602.03.003' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INCENTIVESHARE14857_AMT,0)) AMOUNT  
   FROM #payroll PR
 HAVING SUM(ISNULL(INCENTIVESHARE14857_AMT,0)) > 0) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '360.01.003' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(INCOMETAX_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
  UNION ALL  
 SELECT NEWID() GUID1, '' EXPENSECENTER_TXT, '335.01.001' ACCOUNTCODE, AMOUNT, ''    
   FROM (  
 SELECT SUM(ISNULL(NET_AMT,0)) AMOUNT  
   FROM #payroll PR) A  
 ) INNERTABLE  

 -- SELECT SUM(AMOUNT) FROM #transactions WHERE ACCOUNTCODE = '760.01.001'
 -- SELECT SUM(AMOUNT) FROM #transactions WHERE ACCOUNTCODE = '770.01.001'
       
 SELECT *, ROW_NUMBER() OVER (ORDER BY ACCOUNTCODE DESC, EXPENSECENTER_TXT) ROWNO  
   INTO #accrows  
   FROM (  
 SELECT *  
     -- CONVERT(NVARCHAR(120), 'Gn.Vir.Dek. : MPOS-'+CAST(@TranNo AS VARCHAR(20))+'/'+CONVERT(VARCHAR(30), @Day, 104)+'/KREDÝ KARTI SATIÞLARI/'+CHAKOD+'/'+STORE_NM, 120) DESC1  
   FROM (  
 SELECT ACCOUNTCODE, EXPENSECENTER_TXT, SUM(CASE WHEN LEFT(ACCOUNTCODE,1) IN ('1','7') THEN 1 ELSE -1 END * AMOUNT) AMOUNT, MIN(GUID1) TRANGUID  
   FROM #transactions  
  GROUP BY ACCOUNTCODE, EXPENSECENTER_TXT) A ) B  
  
  
 INSERT INTO MIK_CURRENTTRANSACTION19_SYN  
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
 SELECT GUID1, 0, GETDATE(), 'MBDR', @TranNo, ROWNO, @Day, @Day, ACCOUNTCODE, ' ' cha_kasa_hizkod,   
  ' ' cha_karsisrmrkkodu, AMOUNT, 0 cha_aratoplam, 0 cha_vergipntr, 0, 0, 0, 0,   
  CONVERT(NVARCHAR(40), LEFT(@aciklama+' '+EMPLOYEE_NM, 40)), @Day,  
  0,0,51,0,0,0,0,10 cha_create_user,10,GETDATE(),0,0, @evraktip cha_evrak_tip, CASE WHEN LEFT(ACCOUNTCODE,1) IN ('7','1') THEN 0 ELSE 1 END CHATIP,  
  5,0,0,0,' ',' ' cha_satici_kodu, ' ',' ',' ', CASE WHEN LEFT(ACCOUNTCODE,1) = '7' THEN 5 ELSE 6 END CHACARICINS,  
  ' ',0,1,5.7997 cha_altd_kur, 0 CHAGRUPNO, EXPENSECENTER_TXT, 0,0,1,0,0,0 cha_vade, -- (37)  
  0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,@FisSiraNo, -- (50)  
  null,0,@emptydate,0,0,0,0,0,@emptyguid,@emptyguid,@emptydate,  
  0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,null,@emptyguid,0,0,@emptydate,0  
   FROM #transactions;  
  
 INSERT INTO MIK_ACCOUNTING19_SYN  
 (fis_Guid, fis_DBCno, fis_SpecRECno, fis_iptal, fis_fileid, fis_hidden, fis_kilitli, fis_degisti, fis_checksum, fis_create_user, fis_create_date  
 , fis_lastup_user, fis_lastup_date, fis_firmano, fis_subeno, fis_maliyil, fis_tarih, fis_sira_no  
 , fis_tur, fis_hesap_kod, fis_satir_no, fis_aciklama1, fis_meblag0, fis_meblag1, fis_meblag2, fis_meblag3, fis_meblag4, fis_meblag5, fis_meblag6  
 , fis_sorumluluk_kodu, fis_ticari_tip, fis_ticari_uid, fis_kurfarkifl, fis_ticari_evraktip, fis_tic_evrak_seri, fis_tic_evrak_sira  
 , fis_tic_belgetarihi, fis_yevmiye_no, fis_katagori, fis_evrak_DBCno, fis_fmahsup_tipi, fis_aktif_pasif, fis_proje_kodu)  
 SELECT NEWID(), 0, 0, 0, 2, 0, 0, 0, 0, 10, GETDATE(), 10, GETDATE(), 0, 0, YEAR(@Day), @Day, @FisSiraNo, 0 fis_tur, ACCOUNTCODE, ROWNO,   
     'Gn.Vir.Dek. : MBDR-'+cast(@TranNo as varchar)+'/'+CONVERT(VARCHAR, @day, 104)+'/'+@aciklama+'/'+ACCOUNTCODE+'/'+ISNULL(PA.PAYROLLACCOUNT_NM,'') fis_aciklama1,   
     AMOUNT fis_meblag0, AMOUNT / 5.7997 fis_meblag1, AMOUNT fis_meblag2, 0, 0, 0, 0,   
     R.EXPENSECENTER_TXT fis_sorumluluk_kodu, 2, TRANGUID, 0, @evraktip, 'MBDR', @TranNo, @Day fis_tic_belgetarihi, @FisYevmiyeNo, 0, 0, 0, 0, ' '  
   from #accrows R  
   left join ACC_PAYROLLACCOUNT PA ON R.ACCOUNTCODE = PA.ACCOUNTCODE_TXT  
  
 DELETE FROM MIK_ACCOUNTINGDETAIL19_SYN WHERE mfd_evrak_seri = 'MBDR' and mfd_evrak_sira = @TranNo
 INSERT INTO MIK_ACCOUNTINGDETAIL19_SYN 
 (mfd_Guid, mfd_DBCno, mfd_SpecRECno, mfd_iptal, mfd_fileid, mfd_hidden, mfd_kilitli, mfd_degisti
 , mfd_checksum, mfd_create_user, mfd_create_date, mfd_lastup_user, mfd_lastup_date, mfd_ticari_tip
 , mfd_evraktip, mfd_evrak_seri, mfd_evrak_sira, mfd_bsbakonututar, mfd_bsbatabii, mfd_belgetarihi
 , mfd_tutarnereden, mfd_caritipi, mfd_belgeno, mfd_kdvid, mfd_kdvtutar, mfd_malhizmetmiktari, mfd_bsbakonuufrstutar
 , mfd_aciklama, mfd_caritutar, mfd_kisaevraktipi, mfd_satistipi, mfd_alistipi, mfd_tahtedtipi, mfd_digerevrakadi, mfd_evraktur)
 SELECT NEWID(), 0, 0, 0, 243, 0, 0, 0 mfd_degisti, 0, 10, GETDATE(), 10, GETDATE(), 2 mfd_ticari_tip	
 	 , @evraktip mfd_evraktip, 'MBDR', @TranNo, 0 mfd_bsbakonututar, 0, @Day, 0 mfd_tutarnereden, 0, '' mfd_belgeno
 	 , 0, 0, 0, 0, @aciklama, 0 mfd_caritutar, 5 mfd_kisaevraktipi, 0, 0, 0, N'Genel Amaçlý Virman Dekontu', 0
   
 -- INSERT INTO MIK_PAYROLL VALUES (@Year, @Month, GETDATE(), 'MBDR-'+CAST(2 AS varchar))  
  
END