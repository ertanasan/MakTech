-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_SHIPMENTUNIT_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SHIPMENTUNITID,
           S.UNIT_NM,
           S.PACKAGE_QTY,
           S.COMMENT_DSC
      FROM WHS_SHIPMENTUNIT S (NOLOCK)
     ORDER BY UNIT_NM;

/*Section="End"*/
END;
