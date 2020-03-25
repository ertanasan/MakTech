CREATE PROCEDURE MIK_INS_STOCKTAKING_SP AS
BEGIN

	DECLARE @stockTakingScheduleId BIGINT 
	-- son sayımı bul
	SELECT @stockTakingScheduleId = MAX(STOCKTAKINGSCHEDULEID) 
	  FROM WHS_STOCKTAKINGSCHEDULE 
	 WHERE STORE = 999 AND COUNTINGTYPE = 1 AND DELETED_FL = 'N'

	-- malkabul ve sevk depo yu 1001'e at
	IF OBJECT_ID('tempdb..#COUNT') IS NOT NULL DROP TABLE #COUNT
	SELECT *, ROW_NUMBER() OVER (PARTITION BY SYMDEPONO ORDER BY CODE_NM) - 1 ROWNO 
	  INTO #COUNT
	  FROM (
	SELECT SS.ACTUAL_DT, P.CODE_NM, P.NAME_NM, 
		   CASE WHEN ST.ZONE IN (9,11) THEN 1001 WHEN ST.ZONE = 7 THEN 1004 END SYMDEPONO, 
		   SUM(COUNTINGVALUE_AMT) COUNTING
	  FROM WHS_STOCKTAKING ST
	  JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID
	  JOIN WHS_STOCKTAKINGSCHEDULE SS ON ST.STOCKTAKINGSCHEDULE = SS.STOCKTAKINGSCHEDULEID
	 WHERE STOCKTAKINGSCHEDULE = @stockTakingScheduleId
	   AND ST.ZONE IN (9, 11, 7)
	 GROUP BY SS.ACTUAL_DT, P.CODE_NM, P.NAME_NM,
	   CASE WHEN ST.ZONE IN (9,11) THEN 1001 WHEN ST.ZONE = 7 THEN 1004 END) A

	DECLARE @control INT 
	SELECT @control = COUNT(*)
	  FROM MIK_SAYIM_SYN S
	  JOIN #COUNT C ON S.sym_tarihi = C.ACTUAL_DT AND S.sym_depono = C.SYMDEPONO AND S.sym_Stokkodu COLLATE Turkish_100_CI_AS = C.CODE_NM

	IF @control = 0 
	BEGIN
		INSERT INTO MIK_SAYIM_SYN 
		( sym_Guid, sym_DBCno, sym_SpecRECno, sym_iptal, sym_fileid, sym_hidden, sym_kilitli, sym_degisti, sym_checksum
		, sym_create_user, sym_create_date, sym_lastup_user, sym_lastup_date, sym_special1, sym_special2, sym_special3
		, sym_tarihi, sym_depono, sym_evrakno, sym_satirno, sym_Stokkodu, sym_reyonkodu, sym_koridorkodu, sym_rafkodu
		, sym_miktar1, sym_miktar2, sym_miktar3, sym_miktar4, sym_miktar5, sym_birim_pntr, sym_barkod, sym_renkno
		, sym_bedenno, sym_parti_kodu, sym_lot_no, sym_serino)
		SELECT NEWID(), 0, 0, 0, 28, 0, 0, 0, 0 --  sym_checksum
			 , 21, GETDATE(), 21, GETDATE(), '', '', '' -- sym_special3
			 , ACTUAL_DT, SYMDEPONO /*sym_depono*/, 1, ROWNO, CODE_NM, 0, 0, 0 -- sym_rafkodu
			 , COUNTING, 0, 0, 0, 0, 1, '', 0 sym_renkno
			 , 0, '', 0, '' -- sym_serino
		  FROM #COUNT
	END
	ELSE
	BEGIN
		RAISERROR ('Mikroya önceden sayım aktarılmış.',16, 1);
	END

END