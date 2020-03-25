-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_LST_NOTIFICATIONGROUP_SP
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
           N.NOTIFICATIONGROUPID,
           N.ORGANIZATION,
           N.DELETED_FL,
           N.CREATE_DT,
           N.UPDATE_DT,
           N.CREATEUSER,
           N.UPDATEUSER,
           N.GROUP_NM
      FROM ANN_NOTIFICATIONGROUP N (NOLOCK)
     WHERE (@Organization IS NULL OR N.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY GROUP_NM;

/*Section="End"*/
END;
