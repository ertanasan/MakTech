-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_CASHREGISTER_SP
    @StoreCashRegisterId INT
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
           C.CASHREGISTERID,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.CASHREGISTER_NM,
           C.STORE,
           C.CASHREGISTERMODEL,
           C.PRICEFILEPATH_TXT,
           C.SALEFILEPATH1_TXT,
           C.SALEFILEPATH2_TXT,
           C.SALEFILEPATH3_TXT,
           C.CURRENTPRICEVERSION,
           C.CURRENTPRICELOAD_TM,
           C.PRIVATEPRICEVERSION,
           C.PRIVATEPRICELOAD_TM,
           C.CREATEPRICEFILE_FL,
           C.IPADDRESS_TXT,
           C.STATUS_FL,
           C.STATUS_TXT,
           C.GIBDEVICENO_TXT,
           C.SERIALNO_TXT,
           RB.BRAND_NM
      FROM STR_CASHREGISTER C (NOLOCK)
      JOIN STR_CASHREGISTERMODEL RM ON RM.CASHREGISTERMODELID = C.CASHREGISTERMODEL
      JOIN STR_CASHREGISTERBRAND RB ON RB.CASHREGISTERBRANDID = RM.BRAND
     WHERE C.CASHREGISTERID = @StoreCashRegisterId
       AND (@Organization IS NULL OR C.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
