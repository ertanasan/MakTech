-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_PRODUCT_SP
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
           P.PRODUCTID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CODE_NM,
           P.NAME_NM,
           P.PURCHASEVAT_RT,
           P.SALEVAT_RT,
           P.SUBGROUP,
           P.SUPERGROUP1,
           P.SUPERGROUP2,
           P.SUPERGROUP3,
           P.UNIT,
           P.BARCODETYPE,
           P.SEASONTYPE,
           P.OLDCODE_NM,
           P.PRIVATELABEL_FL,
           P.ETRADE_FL,
           P.GTIPCODE_TXT,
           P.PHOTO_IMG,
           P.SHORTNAME_NM,
           P.DOMESTIC_FL,
           P.COUNTRY,
           P.CONTENT_TXT,
           P.WARNING,
           P.STORAGECONDITION,
           P.EXPIRESIN_CNT,
           P.SHELFLIFE_CNT,
           P.COMMENT_DSC,
           P.CAMPAIGN,
           P.WEIGHT_AMT,
           P.WEIGHTUNIT,
           P.ACTIVE_FL,
           P.LOADORDER_TXT,
           P.PARENT,
           P.INITIALPRICE_AMT,
		   SU.PACKAGE_QTY
      FROM PRD_PRODUCT P (NOLOCK)
	  LEFT JOIN WHS_PRODUCTSHIPMENTUNIT SU (NOLOCK) ON SU.SHIPMENTTYPE = 1 AND SU.PRODUCT = P.PRODUCTID
     WHERE (@Organization IS NULL OR P.ORGANIZATION = @Organization)
       AND P.DELETED_FL = 'N'
     ORDER BY P.CODE_NM;

/*Section="End"*/
END;
