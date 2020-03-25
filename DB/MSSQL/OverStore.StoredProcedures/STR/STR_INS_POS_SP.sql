-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_POS_SP
    @PosId            INT OUT,
    @Store            INT,
    @PosCode          VARCHAR(100),
    @Bank             INT,
    @CashRegisterCode VARCHAR(100),
    @BankCode         VARCHAR(100),
    @Description      VARCHAR(1000),
    @MobilFlag        VARCHAR(1),
    @OKCNumber        VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_POS
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        STORE,
        POSCODE_TXT,
        BANK,
        CASHREGISTERCODE_TXT,
        BANKCODE_TXT,
        DESCRIPTION_TXT,
        MOBIL_FL,
        OKC_TXT
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Store,
        @PosCode,
        @Bank,
        @CashRegisterCode,
        @BankCode,
        @Description,
        @MobilFlag,
        @OKCNumber
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
    SELECT @PosId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
        OKC_TXT
    )
    VALUES
    (
        @PosId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Store,
        @PosCode,
        @Bank,
        @CashRegisterCode,
        @BankCode,
        @Description,
        @MobilFlag,
        @OKCNumber);
/*Section="End"*/
END;
