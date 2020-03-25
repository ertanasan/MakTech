-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_INS_NOTIFICATIONSTORE_SP
    @Notification    BIGINT,
    @Store           INT,
    @ProcessInstance BIGINT
AS
BEGIN
    /*Section="Insert"*/
    -- Insert record
    SET NOCOUNT OFF
    INSERT INTO ANN_NOTIFICATIONSTORE
    (
        NOTIFICATION,
        STORE,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        PROCESSINSTANCE_LNO
    )
    VALUES
    (
        @Notification,
        @Store,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ProcessInstance
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
END;
