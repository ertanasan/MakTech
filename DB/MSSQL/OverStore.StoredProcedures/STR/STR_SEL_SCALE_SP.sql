-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_SCALE_SP
    @StoreScalesId INT
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
           S.SCALEID,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.SCALE_NM,
           S.STORE,
           S.SCALEMODEL,
           S.PRICEFILEPATH_TXT,
           S.CURRENTPRICEVERSION,
           S.CURRENTPRICELOAD_TM,
           S.PRIVATEPRICEVERSION,
           S.PRIVATEPRICELOAD_TM,
           S.CREATEPRICEFILE_FL,
           S.IPADDRESS_TXT,
           S.STATUS_FL,
           S.STATUS_TXT,
           S.SERIAL_TXT,  
           S.SEALVALID_DT,
           SB.BRAND_NM
      FROM STR_SCALE S (NOLOCK)
      JOIN STR_SCALEMODEL SM ON SM.SCALEMODELID = S.SCALEMODEL
      JOIN STR_SCALEBRAND SB ON SB.SCALEBRANDID = SM.BRAND
     WHERE S.SCALEID = @StoreScalesId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
