-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_ASSIGNUSER_SP
    @AssignUserId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           A.ASSIGNUSERID,
           A.GROUP_NM,
           A.RESPONSIBLEUSER,
           A.ADMIN_FL      
      FROM HDK_ASSIGNUSER A (NOLOCK)
     WHERE A.ASSIGNUSERID = @AssignUserId;

    /*Section="End"*/
END;
