CREATE PROCEDURE MIK_INS_EXPENSE_SP @RegionManagerId INT, @ExpenseIdList VARCHAR(MAX), @TranNo BIGINT OUT AS
BEGIN
	-- RETURN;
	-- DECLARE @ExpenseIdList VARCHAR(MAX) = '79444,79471,79522,79743,79746,79815,79816,79882,79901,79982,79985,79995,79997,80142,80143,80161,80195,80197,80227,80228,80229,80230,80241,80242,80244,80277,80291,80296,80388,80426'
	-- DECLARE @RegionManagerId INT = 323
	-- DECLARE @TranNo BIGINT
	-- DECLARE @StartDate DATE = CONVERT(DATE, '20190615', 112);
	DECLARE @FisSiraNo INT, @FisYevmiyeNo INT;

	DECLARE @emptyguid nvarchar(40)                      
	SET @emptyguid = '00000000-0000-0000-0000-000000000000';                      
	DECLARE @emptydate datetime, @today DATE;                      
	SET @emptydate = CONVERT(DATETIME, '18991230', 112);         
	SET @today = CAST(GETDATE() AS DATE)
	
	SELECT @TranNo = ISNULL(MAX(cha_evrakno_sira),0)+1 FROM MIK_CURRENTTRANSACTION20_SYN WHERE cha_evrakno_seri = 'MBS'
	SELECT @FisSiraNo = ISNULL(MAX(fis_sira_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_tarih = @today;  -- fis_firmano = 0 AND fis_maliyil = YEAR(@today); -- AND 
	SELECT @FisYevmiyeNo = ISNULL(MAX(fis_yevmiye_no), 0)+1 FROM MIK_ACCOUNTING20_SYN (NOLOCK)  WHERE fis_firmano = 0 AND fis_maliyil = YEAR(@today); -- AND fis_tarih = @today;  
	-- SELECT @TranNo, @FisSiraNo, @FisYevmiyeNo
	 
	IF OBJECT_ID('tempdb..#expenses') IS NOT NULL DROP TABLE #expenses
	IF OBJECT_ID('tempdb..#accrows') IS NOT NULL DROP TABLE #accrows;

	WITH STOREREGIONS AS (
	SELECT STOREID, STORE_NM, RU.USERID, RM.EXPENSEACCCODE_TXT, RM.MANAGER_NM, RM.MIKROPROJECTCODE_TXT
	  FROM STR_STORE ST 
	  JOIN ORG_BRANCH B ON ST.BRANCH = B.BRANCHID
	  JOIN SEC_USER RU ON RU.BRANCH = B.PARENT
	  JOIN STR_REGIONMANAGERS RM ON RU.USERID = RM.USERID)
	SELECT NEWID() GUID1, E.EXPENSE_AMT, E.PAYOFF_DT, E.STORE, E.VAT_RT, EXPENSE_AMT * 100.0/(100 + VAT_RT) EXPENSEWOVAT, 
		   E.EXPENSE_DSC, E.EXPENSE_DT, E.EXPENSETYPE, ET.EXPENSETYPE_NM, ET.ACCOUNTCODE_TXT, COALESCE(SRM.EXPENSEACCCODE_TXT, SR.EXPENSEACCCODE_TXT) RMCODE_TXT,
		   @TranNo EXPENSENO, ROW_NUMBER() OVER (ORDER BY E.CREATE_DT) ROWNO,
		   -- '201' + RIGHT('00000' + CAST(E.STORE AS VARCHAR(5)), 5)  STORECODE,
		   COALESCE(ECR.EXPENSECENTERCODE_TXT, EC.EXPENSECENTERCODE_TXT) STORECODE,
		   CASE VAT_RT WHEN 0 THEN 1 WHEN 1 THEN 2 WHEN 8 THEN 3 WHEN 18 THEN 4 END TAXPNTR,
		   COALESCE(SRM.MANAGER_NM, SR.MANAGER_NM) MANAGER_NM, E.EXPENSEID, 
		   COALESCE(SRM.MIKROPROJECTCODE_TXT, SR.MIKROPROJECTCODE_TXT) MIKROPROJECTCODE_TXT
	  INTO #expenses
	  FROM [dbo].[SYS_CSVTOTABLE_SP] (@ExpenseIdList,',') A
	  JOIN RCL_EXPENSE E ON A.String = E.EXPENSEID
	  JOIN RCL_EXPENSETYPE ET ON E.EXPENSETYPE = ET.EXPENSETYPEID
	  LEFT JOIN STOREREGIONS SR ON E.STORE = SR.STOREID
	  LEFT JOIN STR_REGIONMANAGERS SRM ON E.REGIONMANAGER = SRM.REGIONMANAGERSID
	  LEFT JOIN ACC_EXPENSECENTER EC ON E.STORE = EC.STORE
	  LEFT JOIN ACC_EXPENSECENTER ECR ON E.REGIONMANAGER = ECR.REGIONMANAGER
	 WHERE COALESCE(SRM.USERID, SR.USERID) = @RegionManagerId
	   AND OPEN_FL = 'N'
	   AND E.DELETED_FL = 'N'
	   AND E.STATUS_CD IS NULL 
	
	DECLARE @expenseNo INT, @RmCode VARCHAR(20), @ManagerName VARCHAR(100), @firstguid nvarchar(40), @projectCode nvarchar(50)
	SELECT @expenseNo = MAX(EXPENSENO), @RmCode = MAX(RMCODE_TXT), @ManagerName = MAX(MANAGER_NM), @firstguid = MIN(GUID1), @projectCode = MAX(MIKROPROJECTCODE_TXT)
	  FROM #expenses
	
	SELECT ACCCODE, ROW_NUMBER() OVER (ORDER BY ROWNO, ACCCODE DESC) - 1 ROWNO, AMOUNT, DESC1, BASE, STORECODE, TRANGUID
	  INTO #accrows
	  FROM (             
	SELECT '195.01.001' ACCCODE, 0 ROWNO, -1*SUM(EXPENSE_AMT) AMOUNT, 0 BASE, '' STORECODE, @firstguid TRANGUID,
		   'Al.fat. : MBS-'+CAST(@expenseNo AS VARCHAR(10))+'/'+convert(char(10), @today, 104)+'/'+@RmCode+'/'+@ManagerName DESC1
	  FROM #expenses
	 UNION ALL
	SELECT ACCOUNTCODE_TXT, ROW_NUMBER() OVER (ORDER BY GUID1), EXPENSEWOVAT, 0 BASE, STORECODE, GUID1,
		   'Al.fat. : MBS-'+CAST(@expenseNo AS VARCHAR(10))+'/'+convert(char(10), @today, 104)+'/'+ACCOUNTCODE_TXT+'/'+EXPENSETYPE_NM
	  FROM #expenses
	 UNION ALL
	SELECT CASE TAXPNTR WHEN 2 THEN '191.01.001' WHEN 3 THEN '191.01.008' WHEN 4 THEN '191.01.018' END, 
		   ROW_NUMBER() OVER (ORDER BY GUID1),
		   EXPENSE_AMT - EXPENSEWOVAT, EXPENSEWOVAT BASE, '' STORECODE, GUID1,
		   'Al.fat. : MBS-'+CAST(@expenseNo AS VARCHAR(10))+'/'+convert(char(10), @today, 104)
	  FROM #expenses WHERE TAXPNTR IN (2,3,4)) A
	-- SELECT * FROM #accrows

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
	SELECT GUID1, 0, GETDATE(), 'MBS', EXPENSENO, ROWNO, @today, EXPENSE_DT, RMCODE_TXT, ACCOUNTCODE_TXT, -- cha_kasa_hizkod
	 STORECODE, EXPENSE_AMT, EXPENSEWOVAT, TAXPNTR, -- cha_vergipntr
	 CASE WHEN TAXPNTR = 1 THEN EXPENSE_AMT - EXPENSEWOVAT ELSE 0 END,
	 CASE WHEN TAXPNTR = 2 THEN EXPENSE_AMT - EXPENSEWOVAT ELSE 0 END,
	 CASE WHEN TAXPNTR = 3 THEN EXPENSE_AMT - EXPENSEWOVAT ELSE 0 END,
	 CASE WHEN TAXPNTR = 4 THEN EXPENSE_AMT - EXPENSEWOVAT ELSE 0 END,
	 CONVERT(NVARCHAR(40), LEFT(EXPENSE_DSC, 40)), EXPENSE_DT, -- cha_fis_tarih
	 0,0,51,0,0,0,0,10, -- cha_create_user
	 10,GETDATE(),0,0,0, -- cha_evrak_tip
	 1,8,0,0,0,' ',' ', -- cha_satici_kodu
	 ' ',@projectCode,' ',0,RMCODE_TXT,0,1,5.8354, -- cha_altd_kur
	 0,' ',5,0,1,0,1,0, --cha_vade (37)
	 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,@FisSiraNo, -- (50)
	 null,0,@emptydate,0,0,0,0,0,@emptyguid,@emptyguid,@emptydate,
	 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,null,@emptyguid,1,0,@emptydate,0
	  FROM #expenses;

	INSERT INTO MIK_ACCOUNTING20_SYN
	(fis_Guid, fis_DBCno, fis_SpecRECno, fis_iptal, fis_fileid, fis_hidden, fis_kilitli, fis_degisti, fis_checksum, fis_create_user, fis_create_date
	, fis_lastup_user, fis_lastup_date, fis_firmano, fis_subeno, fis_maliyil, fis_tarih, fis_sira_no
	, fis_tur, fis_hesap_kod, fis_satir_no, fis_aciklama1, fis_meblag0
	, fis_meblag1, fis_meblag2, fis_meblag3, fis_meblag4, fis_meblag5, fis_meblag6
	, fis_sorumluluk_kodu, fis_ticari_tip, fis_ticari_uid, fis_kurfarkifl, fis_ticari_evraktip, fis_tic_evrak_seri, fis_tic_evrak_sira
	, fis_tic_belgetarihi, fis_yevmiye_no, fis_katagori, fis_evrak_DBCno, fis_fmahsup_tipi, fis_aktif_pasif, fis_proje_kodu)
	SELECT NEWID(), 0, 0, 0, 2, 0, 0, 0, 0, 10, GETDATE(), -- fis_create_date
		   10, GETDATE(), 0, 0, YEAR(@today), @today, @FisSiraNo, -- fis_sira_no
		   0 fis_tur, ACCCODE, ROWNO, DESC1, AMOUNT, -- fis_meblag0
		   0, AMOUNT, 0, BASE, 0, 0, -- fis_meblag6
		   STORECODE, 2, TRANGUID, 0, 0, 'MBS', @expenseNo, -- fis_tic_evrak_sira
		   @today, @FisYevmiyeNo, 0, 0, 0, 0, @projectCode -- fis_proje_kodu
	  from #accrows
	
	
	INSERT INTO MIK_ACCOUNTINGDETAIL20_SYN 
	(mfd_Guid, mfd_DBCno, mfd_SpecRECno, mfd_iptal, mfd_fileid, mfd_hidden, mfd_kilitli, mfd_degisti
	, mfd_checksum, mfd_create_user, mfd_create_date, mfd_lastup_user, mfd_lastup_date, mfd_ticari_tip
	, mfd_evraktip, mfd_evrak_seri, mfd_evrak_sira, mfd_bsbakonututar, mfd_bsbatabii, mfd_belgetarihi
	, mfd_tutarnereden, mfd_caritipi, mfd_kdvid, mfd_kdvtutar, mfd_malhizmetmiktari, mfd_bsbakonuufrstutar
	, mfd_caritutar, mfd_kisaevraktipi, mfd_satistipi, mfd_alistipi, mfd_tahtedtipi, mfd_digerevrakadi, mfd_evraktur)
	SELECT NEWID(), 0, 0, 0, 243, 0, 0, 0, 0, 10, GETDATE(), 10, GETDATE(), 2, 0, 'MBS'
		 , @expenseNo, SUM(EXPENSEWOVAT), 1, @today, 5, 0, 0, SUM(EXPENSE_AMT)-SUM(EXPENSEWOVAT), 0, 0, SUM(EXPENSE_AMT), 2, 0, 0, 0, 'Alış faturası', 0
	  from #expenses
	
	/*
	INSERT INTO MIK_EXPENSETRANSFER
	(EXPENSEID, CREATEUSER, CREATE_DT, MIKRO)
	SELECT EXPENSEID, ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1),  GETDATE(), @TranNo
	  FROM #expenses
	*/
	UPDATE E 
	   SET E.MIKRO_CD = @TranNo,
		   E.MIKRO_TM = GETDATE(),
		   E.MIKROUSER = ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1),
		   E.STATUS_CD = 1
	  FROM RCL_EXPENSE E
	  JOIN #expenses X ON E.EXPENSEID = X.EXPENSEID

END