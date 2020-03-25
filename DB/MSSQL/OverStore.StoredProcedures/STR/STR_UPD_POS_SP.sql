-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_POS_SP
    @PosId            INT,
    @Store            INT,
    @PosCode          VARCHAR(1000),
    @Bank             INT,
    @CashRegisterCode VARCHAR(1000),
    @BankCode         VARCHAR(1000),
    @Description      VARCHAR(1000),
    @MobilFlag        VARCHAR(1),
    @OKCNumber        VARCHAR(50)
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
        OKC_TXT
    )
    SELECT
        POSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_POS
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           POSCODE_TXT = @PosCode,
           BANK = @Bank,
           CASHREGISTERCODE_TXT = @CashRegisterCode,
           BANKCODE_TXT = @BankCode,
           DESCRIPTION_TXT = @Description,
           MOBIL_FL = @MobilFlag,
           OKC_TXT = @OKCNumber
     WHERE POSID = @PosId
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
