-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_CASHIER_SP
    @CashierId             INT,
    @Store                 INT,
    @CashierName           VARCHAR(30),
    @CashierTemplateNumber INT,
    @CashierTitleNumber    INT,
    @Password              INT,
    @CashierFlag           VARCHAR(1),
    @IsActive              VARCHAR(1),
    @Salesman              VARCHAR(1),
    @WorkingType           VARCHAR(1),
    @Note                  VARCHAR(1000)
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
        NOTE_TXT
    )
    SELECT
        CASHIERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_CASHIER
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           CASHIER_NM = @CashierName,
           CASHIERTEMPLATE = @CashierTemplateNumber,
           CASHIERTITLE = @CashierTitleNumber,
           PASSWORD_NO = @Password,
           ISCASHIER_FL = @CashierFlag,
           ISACTIVE_FL = @IsActive,
           ISSALESMAN_FL = @Salesman,
           WORKINGTYPE_CD = @WorkingType,
           NOTE_TXT = @Note
     WHERE CASHIERID = @CashierId
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
