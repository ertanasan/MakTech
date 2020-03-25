-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_LST_CONTRACTDRAFTVERSION_SP
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
           C.CONTRACTDRAFTVERSIONID,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.DRAFTDOCUMENT,
           C.CHANGEDETAIL_DSC
      FROM FIN_CONTRACTDRAFTVERSION C (NOLOCK)
     WHERE (@Organization IS NULL OR C.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY CONTRACTDRAFTVERSIONID;

/*Section="End"*/
END;
