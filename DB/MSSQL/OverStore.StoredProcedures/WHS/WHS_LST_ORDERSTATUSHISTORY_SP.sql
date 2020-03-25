-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_ORDERSTATUSHISTORY_SP
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
           O.ORDERSTATUSHISTORYID,
           O.EVENT,
           O.ORGANIZATION,
           O.DELETED_FL,
           O.CREATE_DT,
           O.UPDATE_DT,
           O.CREATEUSER,
           O.UPDATEUSER,
           O.CREATECHANNEL,
           O.CREATEBRANCH,
           O.CREATESCREEN,
           O.RETURNORDER,
           O.STATUS,
           O.OPERATION_CD,
           O.COMMENT_TXT
      FROM WHS_ORDERSTATUSHISTORY O (NOLOCK)
     WHERE (@Organization IS NULL OR O.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N';

/*Section="End"*/
END;
