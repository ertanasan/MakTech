-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_POSMOVE_SP
    @PosMovementId INT OUT,
    @PosId         INT,
    @MoveTime      DATETIME,
    @Store         INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_POSMOVE
    (
        POSID,
        ORGANIZATION,
        DELETED_FL,
        MOVE_TM,
        STORE,
        CREATE_DT,
        CREATEUSER
    )
    VALUES
    (
        @PosId,
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        @MoveTime,
        @Store,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN()
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @PosMovementId = SCOPE_IDENTITY();
/*Section="End"*/
END;
