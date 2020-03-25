CREATE PROCEDURE [dbo].[SLS_LST_TRANSACTIONDETAILREPORT_SP]
    @Transaction INT = NULL
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

	/*Section="Parameter Modification" */
	IF @Transaction IS NULL
		SET @Transaction = (SELECT MAX(SALEID) FROM SLS_SALE)

   /*Section="Query"*/
   SELECT
           SD.SALEDETAILID,
           SD.TRANSACTION_DT,
		   S.STORE_NM,
           P.NAME_NM,           
           SD.PRICE,
           SD.QUANTITY_QTY,
           CASE WHEN SD.UNIT = 1 THEN 'KG' ELSE 'ADET' END [ADET_KILO],
           SD.UNITPRICE_AMT
      FROM SLS_SALEDETAIL SD (NOLOCK)
	  JOIN PRD_PRODUCT P (NOLOCK) ON SD.PRODUCT = P.PRODUCTID
	  LEFT JOIN STR_STORE S (NOLOCK) ON SD.STORE = S.STOREID
     WHERE (@Organization IS NULL OR SD.ORGANIZATION = @Organization)
		AND SD.SALE = @Transaction
        AND SD.DELETED_FL = 'N'
		AND SD.CANCEL_FL = 'N'
     ORDER BY PRODUCTCODE_NM;
          

    /*Section="End"*/
END;
