-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_ZETIMAGE_SP
	@ReconciliationId BIGINT 
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
           Z.ZETIMAGEID,
           Z.EVENT,
           Z.ORGANIZATION,
           Z.DELETED_FL,
           Z.CREATE_DT,
           Z.UPDATE_DT,
           Z.CREATEUSER,
           Z.UPDATEUSER,
           Z.CREATECHANNEL,
           Z.CREATEBRANCH,
           Z.CREATESCREEN,
           Z.STOREREC,
           Z.CASHREGISTER
      FROM RCL_ZETIMAGE Z (NOLOCK)
     WHERE (@Organization IS NULL OR Z.ORGANIZATION = @Organization)
	   AND Z.STOREREC = @ReconciliationId  
       AND DELETED_FL = 'N';

/*Section="End"*/
END;
