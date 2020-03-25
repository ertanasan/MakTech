-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE [dbo].[STR_LST_SCALE_SP]
    @Store INT = NULL
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
    -- Select all
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
		   M.MODEL_NM,
		   B.SCALEBRANDID,
		   B.BRAND_NM,
		   S.IPADDRESS_TXT,
		   S.STATUS_FL,
           S.STATUS_TXT,
		   S.SERIAL_TXT,
		   S.SEALVALID_DT
      FROM STR_SCALE S (NOLOCK)
	  JOIN STR_SCALEMODEL M (NOLOCK) on S.SCALEMODEL = M.SCALEMODELID
	  JOIN STR_SCALEBRAND B (NOLOCK) on M.BRAND = B.SCALEBRANDID
     WHERE (@Store IS NULL OR S.STORE = @Store)
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY SCALE_NM;

/*Section="End"*/
END;