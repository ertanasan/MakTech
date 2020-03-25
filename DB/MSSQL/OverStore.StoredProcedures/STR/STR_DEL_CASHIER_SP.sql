-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_CASHIER_SP
    @CashierId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_CASHIERLOG
    (
        CASHIERID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STORE,
        CASHIER_NM,
        CASHIERTEMPLATE,
        CASHIERTITLE,
        PASSWORD_NO,
        ISCASHIER_FL,
        ISACTIVE_FL,
        ISSALESMAN_FL,
        WORKINGTYPE_CD,
        NOTE_TXT    )
    SELECT
        CASHIERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE,
        CASHIER_NM,
        CASHIERTEMPLATE,
        CASHIERTITLE,
        PASSWORD_NO,
        ISCASHIER_FL,
        ISACTIVE_FL,
        ISSALESMAN_FL,
        WORKINGTYPE_CD,
        NOTE_TXT
      FROM
        STR_CASHIER C (NOLOCK)
     WHERE
        C.CASHIERID = @CashierId;
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
    UPDATE STR_CASHIER
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE CASHIERID = @CashierId
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
