-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_STOREORDERHISTORY_SP
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
           S.STOREORDERHISTORYID,
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
           S.STOREORDER,
           S.HISTORY_TM,
           S.STATUS
      FROM WHS_STOREORDERHISTORY S (NOLOCK)
     WHERE (@Organization IS NULL OR S.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY STOREORDERHISTORYID;

/*Section="End"*/
END;
