-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_SALEDETAIL_SP
    @SaleDetailId BIGINT
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

    /*Section="Query"*/
    -- Select
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
           S.UNITPRICE_AMT
      FROM SLS_SALEDETAIL S (NOLOCK)
     WHERE S.SALEDETAILID = @SaleDetailId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
