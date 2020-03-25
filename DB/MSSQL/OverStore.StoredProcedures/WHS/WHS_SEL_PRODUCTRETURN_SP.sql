-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_PRODUCTRETURN_SP
    @ProductReturnId BIGINT
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
           P.PRODUCTRETURNID,
           P.EVENT,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           P.RETURN_DT,
           P.WAYBILL_DT,
           P.PRODUCT,
           P.SUPPLIER_TXT,
           P.MANUFACTURING_DT,
           P.EXPIRE_DT,
           P.RETURNQUANTITY_AMT,
           P.PACKAGETYPE,
           P.RETURNREASON_TXT,
           P.RETURNDESTINATION,
           P.STATUS_CD,
           P.PROCESSINSTANCE_LNO,
           P.STORE,
           P.INTAKE_AMT,
           P.CUSTOMERRETURN_FL,
           P.REUSABLE_FL,
           P.SALEDETAIL,
		   P.WAYBILL_TXT
      FROM WHS_PRODUCTRETURN P (NOLOCK)
     WHERE P.PRODUCTRETURNID = @ProductReturnId
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
