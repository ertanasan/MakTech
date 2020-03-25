CREATE PROCEDURE STR_DEL_REGIONMANAGERS_SP
    @RegionManagersId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_REGIONMANAGERSLOG
    (
        REGIONMANAGERSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        MANAGER_NM,
        TELNO_TXT,
        EMAIL_TXT,
        USERID,
        EXPENSEACCCODE_TXT,
		MIKROPROJECTCODE_TXT )
    SELECT
        REGIONMANAGERSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        MANAGER_NM,
        TELNO_TXT,
        EMAIL_TXT,
        USERID,
        EXPENSEACCCODE_TXT,
		MIKROPROJECTCODE_TXT
      FROM
        STR_REGIONMANAGERS R (NOLOCK)
     WHERE
        R.REGIONMANAGERSID = @RegionManagersId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_REGIONMANAGERS
     WHERE REGIONMANAGERSID = @RegionManagersId;

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