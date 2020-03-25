CREATE PROCEDURE MIK_DEL_INVOICE_SP @SaleId BIGINT AS
BEGIN
	DELETE FROM MIK_ACCOUNTINGDETAIL20_SYN
	 WHERE mfd_evrak_seri IN ('MPA', 'MPE')
	   AND mfd_evrak_sira = @SaleId

	DELETE FROM MIK_CURRENTTRANSACTION20_SYN
	 WHERE cha_evrakno_seri IN ('MPA', 'MPE')
	   AND cha_evrakno_sira = @SaleId

	DELETE FROM MIK_ACCOUNTING20_SYN
	 WHERE fis_tic_evrak_seri IN ('MPA', 'MPE')
	   AND fis_tic_evrak_sira = @SaleId

	DELETE FROM MIK_TRANSACTION20_SYN
	 WHERE sth_evrakno_seri IN ('MPA', 'MPE')
	   AND sth_evrakno_sira = @SaleId

	DELETE ED
	-- SELECT ED.*
	  FROM MIK_EFATURADETAYLARI_SYN ED
	  JOIN MIK_EFATURAISLEMLERI_SYN E ON ED.efd_uuid = E.efi_uuid
	 WHERE E.efi_evrakno_seri IN ('MPA', 'MPE')
	   AND E.efi_evrakno_sira = @SaleId

	DELETE E
	  FROM MIK_EFATURAISLEMLERI_SYN E
	 WHERE E.efi_evrakno_seri IN ('MPA', 'MPE')
	   AND E.efi_evrakno_sira = @SaleId
END