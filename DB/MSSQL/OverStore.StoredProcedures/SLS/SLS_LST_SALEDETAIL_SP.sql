CREATE PROCEDURE SLS_LST_SALEDETAIL_SP @SaleId INT AS
BEGIN
    SELECT
           S.SALEDETAILID,
           S.EVENT,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.CREATECHANNEL,
           S.CREATEBRANCH,
           S.CREATESCREEN,
           S.SALE,
           S.TRANSACTION_TXT,
           S.TRANSACTION_DT,
           S.BARCODE_TXT,
           S.PRODUCT,
           S.PRODUCTCODE_NM,
           S.STORE,
           S.PRICE,
           S.VAT_RT,
           S.QUANTITY_QTY,
           S.UNIT,
           S.CANCEL_FL,
           S.UNITPRICE_AMT, 
           P.NAME_NM PRODUCT_NM,
           CASE WHEN S.UNIT = 1 THEN S.QUANTITY_QTY / 1000.0 ELSE S.QUANTITY_QTY END KG_QTY
      FROM SLS_SALEDETAIL S (NOLOCK)
      LEFT JOIN PRD_PRODUCT P (NOLOCK) ON S.PRODUCT = P.PRODUCTID
     WHERE S.SALE = @SaleId
       AND S.DELETED_FL = 'N'
     ORDER BY SALEDETAILID;

END;