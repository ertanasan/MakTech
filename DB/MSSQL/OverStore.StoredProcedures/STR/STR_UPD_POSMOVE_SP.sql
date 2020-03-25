-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_POSMOVE_SP
    @PosMovementId INT,
    @PosId         INT,
    @MoveTime      DATETIME,
    @Store         INT
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_POSMOVE
       SET
           POSID = @PosId,
           MOVE_TM = @MoveTime,
           STORE = @Store,
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN()
     WHERE POSMOVEID = @PosMovementId     
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
