-- Created by OverGenerator
/*Section="Main" isCustomized=true*/
CREATE PROCEDURE WHS_LST_GATHERINGPALLETPHOTO_SP @StoreOrder BIGINT, @GatheringPalletId BIGINT = NULL
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
           PH.GATHERINGPALLETPHOTOID,
           PH.EVENT,
           PH.ORGANIZATION,
           PH.DELETED_FL,
           PH.CREATE_DT,
           PH.UPDATE_DT,
           PH.CREATEUSER,
           PH.UPDATEUSER,
           PH.CREATECHANNEL,
           PH.CREATEBRANCH,
           PH.CREATESCREEN,
           PH.GATHERINGPALLET,
           PH.PHOTO,
           GP.PALLET_NO,
           GT.GATHERINGTYPE_NM GATHERINGTYPENAME
      FROM WHS_GATHERINGPALLETPHOTO PH (NOLOCK)
	  JOIN WHS_GATHERINGPALLET GP ON PH.GATHERINGPALLET = GP.GATHERINGPALLETID
	  JOIN WHS_GATHERING G ON GP.GATHERING = G.GATHERINGID
      JOIN WHS_GATHERINGTYPE GT ON G.GATHERINGTYPE = GT.GATHERINGTYPEID
     WHERE (@Organization IS NULL OR PH.ORGANIZATION = @Organization)
	   AND G.STOREORDER = @StoreOrder
	   AND (@GatheringPalletId IS NULL OR GP.GATHERINGPALLETID = @GatheringPalletId)
       AND PH.DELETED_FL = 'N'
     ORDER BY G.GATHERINGTYPE, GP.PALLET_NO, PH.GATHERINGPALLETPHOTOID;

/*Section="End"*/
END;
