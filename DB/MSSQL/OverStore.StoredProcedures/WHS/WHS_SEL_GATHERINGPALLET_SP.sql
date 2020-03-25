-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_GATHERINGPALLET_SP
    @GatheringPalletId INT
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
           G.GATHERINGPALLETID,
           G.DELETED_FL,
           G.CREATE_DT,
           G.CREATEUSER,
           G.UPDATEUSER,
           G.UPDATE_DT,
           G.GATHERING,
           G.ORGANIZATION,
           G.PALLET_NO,
           G.CONTROLUSER,
           G.CONTROLSTART_TM,
           G.CONTROLEND_TM,
           G.GATHERINGPALLETSTATUS
      FROM WHS_GATHERINGPALLET G (NOLOCK)
     WHERE G.GATHERINGPALLETID = @GatheringPalletId
       AND (@Organization IS NULL OR G.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
