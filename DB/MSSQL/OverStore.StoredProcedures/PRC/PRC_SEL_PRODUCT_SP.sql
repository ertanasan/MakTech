-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_PRODUCT_SP
    @ProductPriceId INT
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
           P.PRODUCTID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.PRICE_AMT,
           P.PRODUCT,
           P.PACKAGE,
           P.TOPPRICE_AMT,
           P.PRINTTOPPRICE_FL,
           P.PACKAGEVERSION
      FROM PRC_PRODUCT P (NOLOCK)
     WHERE P.PRODUCTID = @ProductPriceId
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
