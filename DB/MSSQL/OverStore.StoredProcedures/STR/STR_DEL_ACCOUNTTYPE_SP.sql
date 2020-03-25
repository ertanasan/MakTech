-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_ACCOUNTTYPE_SP
    @StoreAccountTypeId INT
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
        ACCOUNTTYPE_NM    )    
    SELECT
        ACCOUNTTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ACCOUNTTYPE_NM
      FROM
        STR_ACCOUNTTYPE A (NOLOCK)
     WHERE
        A.ACCOUNTTYPEID = @StoreAccountTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_ACCOUNTTYPE
     WHERE ACCOUNTTYPEID = @StoreAccountTypeId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
