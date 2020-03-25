-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_POS_SP
    @PosId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_POSLOG
    (
        POSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STORE,
        POSCODE_TXT,
        BANK,
        CASHREGISTERCODE_TXT,
        BANKCODE_TXT,
        DESCRIPTION_TXT,
        MOBIL_FL,
        OKC_TXT    )
    SELECT
        POSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE,
        POSCODE_TXT,
        BANK,
        CASHREGISTERCODE_TXT,
        BANKCODE_TXT,
        DESCRIPTION_TXT,
        MOBIL_FL,
        OKC_TXT
      FROM
        STR_POS P (NOLOCK)
     WHERE
        P.POSID = @PosId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    DELETE FROM STR_POS
     WHERE POSID = @PosId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
