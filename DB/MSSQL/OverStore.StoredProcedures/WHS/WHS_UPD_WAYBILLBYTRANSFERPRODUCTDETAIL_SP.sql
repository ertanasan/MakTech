CREATE PROCEDURE [dbo].[WHS_UPD_WAYBILLBYTRANSFERPRODUCTDETAIL_SP] @TransferProductDetailId INT AS
BEGIN
	SET NOCOUNT OFF

	UPDATE MIK_TRANSACTION20_SYN 
	   SET sth_stok_kod = P.CODE_NM,
	       sth_miktar = TD.QUANTITY_QTY,
		   sth_lastup_date = GETDATE()
	  FROM WHS_TRANSFERPRODUCTDETAIL TD 
	  JOIN PRD_PRODUCT P ON TD.PRODUCT = P.PRODUCTID
	  JOIN MIK_TRANSACTION20_SYN M ON M.sth_evrakno_sira = TD.TRANSFERPRODUCT AND M.sth_stok_kod COLLATE Turkish_100_CI_AS = P.CODE_NM
	 WHERE sth_evrakno_seri = 'OMT' 
	   AND TD.TRANSFERPRODUCTDETAILID = @TransferProductDetailId
	   AND DATEDIFF(day, M.sth_create_date, GETDATE()) <= 10

	IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Ya transferin üzerinden 10 gün geçmiş, ya da Mikroda bu ürün transferine ait kayıt bulunmamakta. Mikrodan URUNTRANSFER güncelleme işlemi başarısız.', 1;
        RETURN;
    END;
	SET NOCOUNT ON;
	
	
	
END