-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_GATHERINGDETAIL_SP
    @GatheringDetailId BIGINT
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
           G.GATHERINGDETAILID,
           G.EVENT,
           G.ORGANIZATION,
           G.DELETED_FL,
           G.CREATE_DT,
           G.UPDATE_DT,
           G.CREATEUSER,
           G.UPDATEUSER,
           G.CREATECHANNEL,
           G.CREATEBRANCH,
           G.CREATESCREEN,
           G.STOREORDERDETAIL,
           G.GATHERING_TM,
           G.GATHERING,
           G.GATHERED_QTY,
		   G.PALLET_NO,
		   G.CONTROL_QTY,
           G.CONTROL_TM,
		   P.NAME_NM PRODUCTNAME,
		   P.CODE_NM PRODUCTCODE,
		   U.UNIT_NM
      FROM WHS_GATHERINGDETAIL G (NOLOCK)
	  JOIN WHS_STOREORDERDETAIL (NOLOCK) OD ON OD.STOREORDERDETAILID = G.STOREORDERDETAIL AND OD.DELETED_FL = 'N'
	  JOIN PRD_PRODUCT (NOLOCK) P ON OD.PRODUCT = P.PRODUCTID 
	  JOIN PRD_UNIT (NOLOCK) U ON P.UNIT = U.UNITID
     WHERE G.GATHERINGDETAILID = @GatheringDetailId
       AND (@Organization IS NULL OR G.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
