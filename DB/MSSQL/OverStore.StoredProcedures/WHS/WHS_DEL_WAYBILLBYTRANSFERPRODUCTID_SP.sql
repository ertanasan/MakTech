CREATE PROCEDURE [dbo].[WHS_DEL_WAYBILLBYTRANSFERPRODUCTID_SP] @TransferProductId INT AS
BEGIN
	DECLARE @TransferDate DATE;
	
	SELECT @TransferDate = sth_create_date
	  FROM MIK_TRANSACTION20_SYN
	 WHERE sth_evrakno_seri = 'OMT' 
	   AND sth_evrakno_sira = @TransferProductId

	IF DATEDIFF(day, @TransferDate, GETDATE()) > 10
	BEGIN
		;THROW 100001, 'Transfer üstünden 10 gün geçmiş. Mikrodan URUNTRANSFER silme işlemi başarısız.', 1;
        RETURN;
	END
	
	DELETE 
	  FROM MIK_TRANSACTION20_SYN 
	 WHERE sth_evrakno_seri = 'OMT' 
	   AND sth_evrakno_sira = @TransferProductId
	
END