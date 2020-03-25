-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_SALE_SP
    @SalesId BIGINT
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
           S.SALEID,
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
           S.TRANSACTION_TXT,
           S.STORE,
           S.CASHIER_NM,
           S.CASHREGISTER,
           S.TRANSACTION_DT,
           S.TRANSACTION_TM,
           S.TOTALVAT_AMT,
           S.TOTAL_AMT,
           S.PRODUCTDISCOUNT_AMT,
           S.SALEDISCOUNT_AMT,
           S.PRODUCT_CNT,
           S.DURATION_CNT,
           S.CANCELLED_FL,
           S.TRANSACTIONTYPE
      FROM SLS_SALE S (NOLOCK)
     WHERE S.SALEID = @SalesId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
