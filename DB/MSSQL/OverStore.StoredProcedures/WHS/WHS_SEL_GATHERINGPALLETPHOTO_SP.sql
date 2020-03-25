-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_GATHERINGPALLETPHOTO_SP
    @GatheringPalletPhotoId BIGINT
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
           G.GATHERINGPALLETPHOTOID,
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
           G.GATHERINGPALLET,
           G.PHOTO      
      FROM WHS_GATHERINGPALLETPHOTO G (NOLOCK)
     WHERE G.GATHERINGPALLETPHOTOID = @GatheringPalletPhotoId     
       AND (@Organization IS NULL OR G.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
