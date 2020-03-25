-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_WORKINGHOURS_SP
    @WorkingHoursId BIGINT OUT,
    @Event          INT,
    @Organization   INT,
    @StoreCode      VARCHAR(50),
    @StoreName      VARCHAR(100),
    @OpeningTime    DATETIME,
    @ClosingTime    DATETIME,
    @OpenUserName   VARCHAR(100),
    @CloseUserName  VARCHAR(100),
    @Store          INT,
    @OpenUser       INT,
    @CloseUser      INT,
    @Note           VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_WORKINGHOURS
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STORECODE_TXT,
        STORE_NM,
        OPENING_TM,
        CLOSING_TM,
        OPENGUSER_NM,
        CLOSEUSER_NM,
        STORE,
        OPENUSER,
        CLOSEUSER,
        NOTE_DSC
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StoreCode,
        @StoreName,
        @OpeningTime,
        @ClosingTime,
        @OpenUserName,
        @CloseUserName,
        @Store,
        @OpenUser,
        @CloseUser,
        @Note
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
    SELECT @WorkingHoursId = SCOPE_IDENTITY();
/*Section="End"*/
END;
