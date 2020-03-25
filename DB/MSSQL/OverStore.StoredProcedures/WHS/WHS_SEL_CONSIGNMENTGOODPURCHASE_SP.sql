-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_CONSIGNMENTGOODPURCHASE_SP
    @ConsignmentGoodPurchaseId BIGINT
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
           C.CONSIGNMENTGOODPURCHASEID,
           C.EVENT,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.CREATECHANNEL,
           C.CREATEBRANCH,
           C.CREATESCREEN,
           C.STORE,
           C.PRODUCT,
           C.SUPPLIER,
           C.QUANTITY_QTY
      FROM WHS_CONSIGNMENTGOODPURCHASE C (NOLOCK)
     WHERE C.CONSIGNMENTGOODPURCHASEID = @ConsignmentGoodPurchaseId
       AND (@Organization IS NULL OR C.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
