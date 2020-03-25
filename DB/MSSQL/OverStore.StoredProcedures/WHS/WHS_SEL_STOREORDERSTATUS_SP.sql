-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_STOREORDERSTATUS_SP
    @StoreOrderStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.STOREORDERSTATUSID,
           S.STATUS_NM,
           S.COMMENT_DSC      
      FROM WHS_STOREORDERSTATUS S (NOLOCK)
     WHERE S.STOREORDERSTATUSID = @StoreOrderStatusId;

    /*Section="End"*/
END;
