-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_POSMOVE_SP
    @PosMovementId INT
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
           P.POSMOVEID,
           P.POSID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.MOVE_TM,
           P.STORE,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER      
      FROM STR_POSMOVE P (NOLOCK)
     WHERE P.POSMOVEID = @PosMovementId     
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
