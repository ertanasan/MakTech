-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_FIRM_SP
    @FirmId INT
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
     WHERE F.FIRMID = @FirmId     
       AND (@Organization IS NULL OR F.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
