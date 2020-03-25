-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_STOREORDERDETAIL_SP
    @StoreOrderDetailId BIGINT
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
           S.STOREORDERDETAILID,
           S.EVENT,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.CREATECHANNEL,
           S.CREATEBRANCH,
           S.CREATESCREEN,
           S.PRODUCT,
           S.ORDER_QTY,
           S.REVISED_QTY,
           S.SHIPPED_QTY,
           S.ORDERUNIT_QTY,
           S.STOREORDER,
           S.INTAKE_QTY,
		   S.SUGGESTION_QTY
      FROM WHS_STOREORDERDETAIL S (NOLOCK)
     WHERE S.STOREORDERDETAILID = @StoreOrderDetailId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
