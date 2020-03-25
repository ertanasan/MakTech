-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_CASHIER_SP
    @CashierId             INT,
    @Store                 INT,
    @CashierName           VARCHAR(30),
    @CashierTemplateNumber INT,
    @CashierTitleNumber    INT,
    @Password              INT,
    @CashierFlag           VARCHAR(1),
    @IsActive              VARCHAR(1),
    @Salesman              VARCHAR(1),
    @WorkingType           INT,
    @Note                  VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_CASHIER
    (
        CASHIERID,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
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
    VALUES
    (
        @CashierId,
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Store,
        @CashierName,
        @CashierTemplateNumber,
        @CashierTitleNumber,
        @Password,
        @CashierFlag,
        @IsActive,
        @Salesman,
        @WorkingType,
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

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @CashierId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Store,
        @CashierName,
        @CashierTemplateNumber,
        @CashierTitleNumber,
        @Password,
        @CashierFlag,
        @IsActive,
        @Salesman,
        @WorkingType,
        @Note);
/*Section="End"*/
END;
