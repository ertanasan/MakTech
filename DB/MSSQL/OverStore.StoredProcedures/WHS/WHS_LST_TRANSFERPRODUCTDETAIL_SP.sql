-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_TRANSFERPRODUCTDETAIL_SP
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
           T.TRANSFERPRODUCTDETAILID,
           T.EVENT,
           T.ORGANIZATION,
           T.DELETED_FL,
           T.CREATE_DT,
           T.UPDATE_DT,
           T.CREATEUSER,
           T.UPDATEUSER,
           T.CREATECHANNEL,
           T.CREATEBRANCH,
           T.CREATESCREEN,
           T.PRODUCT,
           T.TRANSFERPRODUCT,
           T.QUANTITY_QTY,
		   P.UNIT
      FROM WHS_TRANSFERPRODUCTDETAIL T (NOLOCK)
	  JOIN PRD_PRODUCT P ON P.PRODUCTID = T.PRODUCT
     WHERE (@Organization IS NULL OR T.ORGANIZATION = @Organization)
       AND T.DELETED_FL = 'N'
     ORDER BY TRANSFERPRODUCTDETAILID;

/*Section="End"*/
END;
