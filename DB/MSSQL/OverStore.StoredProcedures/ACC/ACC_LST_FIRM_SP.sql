-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_FIRM_SP
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
           F.FIRMID,
           F.ORGANIZATION,
           F.DELETED_FL,
           F.CREATE_DT,
           F.UPDATE_DT,
           F.CREATEUSER,
           F.UPDATEUSER,
           F.FIRM_NM,
           F.FIRMTYPE,
           F.COMMENT_DSC
      FROM ACC_FIRM F (NOLOCK)
     WHERE (@Organization IS NULL OR F.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY FIRM_NM;

/*Section="End"*/
END;
