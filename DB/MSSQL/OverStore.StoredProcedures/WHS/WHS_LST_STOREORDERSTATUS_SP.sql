-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_STOREORDERSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.STOREORDERSTATUSID,
           S.STATUS_NM,
           S.COMMENT_DSC
      FROM WHS_STOREORDERSTATUS S (NOLOCK);

/*Section="End"*/
END;
