CREATE PROCEDURE [dbo].[MIK_LST_WAYBILL_SP]
  @TransactionDate DATE,
  @DocumentSerial VARCHAR(30),
  @DocumentNo INT AS
BEGIN
  SELECT sth_tarih TRANSACTIONDATE
       , sth_evrakno_seri DOCUMENTSERIAL
	   , sth_evrakno_sira DOCUMENTNO
	   , sth_satirno DOCUMENTROWNO
	   , sth_belge_no DOCUMENTINFO
	   , sth_tip TRANSACTIONTYPE
	   , sth_cins TRANSACTIONKIND
	   , CASE WHEN sth_normal_iade = 0 THEN 'N' ELSE 'Y' END ISREFUND
	   , sth_evraktip DOCUMENTTYPE
	   , sth_belge_tarih DOCUMENTDATE
	   , sth_stok_kod PRODUCTCODE
	   , sth_miktar QUANTITY
	   , sth_vergi_pntr VATCODE
	   , sth_aciklama [DESCRIPTION]
	   , sth_giris_depo_no RECEIVERWAREHOUSE
	   , sth_cikis_depo_no SENDERWAREHOUSE
	   , sth_malkbl_sevk_tarihi INTAKESHIPMENTDATE
    FROM MIK_TRANSACTION20_SYN
   WHERE sth_tarih = @TransactionDate
     AND sth_evrakno_seri = @DocumentSerial
	 AND sth_evrakno_sira = @DocumentNo
END