-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_PRODUCTSHIPMENTUNIT_SP
    @ProductShipmentUnitId INT
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
           P.PRODUCTSHIPMENTUNITID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.PRODUCT,
           P.SHIPMENTTYPE,
           P.PACKAGE_QTY,
           P.PACKAGETYPE,
           P.LOCATION_TXT      
      FROM WHS_PRODUCTSHIPMENTUNIT P (NOLOCK)
     WHERE P.PRODUCTSHIPMENTUNITID = @ProductShipmentUnitId     
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
