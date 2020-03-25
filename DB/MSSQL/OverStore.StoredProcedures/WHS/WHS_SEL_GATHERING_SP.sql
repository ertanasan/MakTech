-- Created by OverGenerator
/*Section="Main", IsCustomized=true*/
CREATE PROCEDURE WHS_SEL_GATHERING_SP
    @GatheringId BIGINT
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
           G.GATHERINGID,
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
           G.STOREORDER,
           G.GATHERINGUSER,
           G.GATHERINGSTART_TM,
           G.GATHERINGEND_TM,
           G.GATHERINGSTATUS,
           G.GATHERINGTYPE,
		   G.PRIORITY_NO,
		   ST.STORE_NM STORENAME,
		   O.ORDER_DT, 
		   O.SHIPMENT_DT, 
		   O.ORDERCODE_NM, 
		   GT.GATHERINGTYPE_NM, 
		   U.USERFULL_NM GATHERINGUSER_NM
      FROM WHS_GATHERING G (NOLOCK)
	  JOIN WHS_STOREORDER O ON O.STOREORDERID = G.STOREORDER
	  JOIN STR_STORE ST (NOLOCK) ON ST.STOREID = O.STORE
	  JOIN WHS_GATHERINGTYPE GT ON G.GATHERINGTYPE = GT.GATHERINGTYPEID
	  LEFT JOIN SEC_USER U (NOLOCK) ON G.GATHERINGUSER = U.USERID
     WHERE (@Organization IS null OR G.ORGANIZATION = @Organization)
	   AND G.GATHERINGID = @GatheringId;

    /*Section="End"*/
END;
