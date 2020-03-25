CREATE PROCEDURE ACC_FIX_EINVOCE99Z_SP AS
BEGIN

	DECLARE ACC_CUR CURSOR FOR   
	SELECT I.INVOICEID
	  FROM ACC_INVOICE I
	  JOIN (select fis_tic_evrak_sira, max(fis_tarih) fis_tarih, count(*) satiradet 
			  from  MIK_ACCOUNTING20_SYN group by fis_tic_evrak_sira) A2 ON I.SALE = A2.fis_tic_evrak_sira -- AND A2.fis_hesap_kod like '100%'
	  LEFT JOIN MIK_ACCOUNTING20_SYN A ON I.SALE = A.fis_tic_evrak_sira AND A.fis_hesap_kod = '99Z'
	  LEFT JOIN MIK_ACCOUNTING20_SYN A3 ON I.SALE = A3.fis_tic_evrak_sira AND A3.fis_hesap_kod like '689%'
	 WHERE MIKRO_FL = 'Y'
	   AND A.fis_tarih IS NOT NULL

	DECLARE @invoiceId BIGINT

	OPEN ACC_CUR    
	FETCH NEXT FROM ACC_CUR INTO @invoiceId

	WHILE @@FETCH_STATUS = 0    
	BEGIN   
		EXEC MIK_FIX_EINVOICE_SP @invoiceId
		FETCH NEXT FROM ACC_CUR INTO @invoiceId
	END

	CLOSE ACC_CUR    
	DEALLOCATE ACC_CUR

END