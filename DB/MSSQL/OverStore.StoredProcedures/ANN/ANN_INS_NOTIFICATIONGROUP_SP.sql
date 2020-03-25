-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_INS_NOTIFICATIONGROUP_SP
    @NotificationGroupId INT OUT,
    @GroupName           VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ANN_NOTIFICATIONGROUP
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        GROUP_NM
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @GroupName
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
    SELECT @NotificationGroupId = SCOPE_IDENTITY();
/*Section="End"*/
END;
