-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_WORKINGHOURS_SP
    @WorkingHoursId BIGINT,
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
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_WORKINGHOURS
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORECODE_TXT = @StoreCode,
           STORE_NM = @StoreName,
           OPENING_TM = @OpeningTime,
           CLOSING_TM = @ClosingTime,
           OPENGUSER_NM = @OpenUserName,
           CLOSEUSER_NM = @CloseUserName,
           STORE = @Store,
           OPENUSER = @OpenUser,
           CLOSEUSER = @CloseUser,
           NOTE_DSC = @Note
     WHERE WORKINGHOURSID = @WorkingHoursId
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
