-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_TRANSFERPRODUCTDETAIL_SP
    @TransferProductDetailId BIGINT
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
           T.QUANTITY_QTY      
      FROM WHS_TRANSFERPRODUCTDETAIL T (NOLOCK)
     WHERE T.TRANSFERPRODUCTDETAILID = @TransferProductDetailId     
       AND (@Organization IS NULL OR T.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
