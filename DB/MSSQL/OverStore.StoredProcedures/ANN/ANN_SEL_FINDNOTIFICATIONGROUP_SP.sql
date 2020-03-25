-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_FINDNOTIFICATIONGROUP_SP
    @GroupName VARCHAR(100)
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
           N.NOTIFICATIONGROUPID,
           N.ORGANIZATION,
           N.DELETED_FL,
           N.CREATE_DT,
           N.UPDATE_DT,
           N.CREATEUSER,
           N.UPDATEUSER,
           N.GROUP_NM      
      FROM ANN_NOTIFICATIONGROUP N (NOLOCK)
     WHERE N.GROUP_NM = @GroupName
       AND (@Organization IS NULL OR N.ORGANIZATION = @Organization);

/*Section="End"*/
END;
