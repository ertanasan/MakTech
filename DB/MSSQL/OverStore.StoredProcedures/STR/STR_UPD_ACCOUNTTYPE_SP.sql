-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_ACCOUNTTYPE_SP
    @StoreAccountTypeId INT,
    @AccountTypeName    VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_ACCOUNTTYPELOG
    (
        ACCOUNTTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ACCOUNTTYPE_NM
    )    
    SELECT
        ACCOUNTTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ACCOUNTTYPE_NM
      FROM
        STR_ACCOUNTTYPE A (NOLOCK)
     WHERE
        A.ACCOUNTTYPEID = @StoreAccountTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_ACCOUNTTYPE
       SET
           ACCOUNTTYPE_NM = @AccountTypeName
     WHERE ACCOUNTTYPEID = @StoreAccountTypeId;

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
