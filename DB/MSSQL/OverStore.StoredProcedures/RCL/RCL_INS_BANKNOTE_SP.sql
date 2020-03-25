-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_BANKNOTE_SP
    @BanknoteId     INT OUT,
    @BanknoteAmount NUMERIC(22,6),
    @CoinFlag       VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_BANKNOTE
    (
        BANKNOTE_AMT,
        COIN_FL
    )
    VALUES
    (
        @BanknoteAmount,
        @CoinFlag
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
    SELECT @BanknoteId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO RCL_BANKNOTELOG
    (
        BANKNOTEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BANKNOTE_AMT,
        COIN_FL
    )    
    VALUES
    (
        @BanknoteId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @BanknoteAmount,
        @CoinFlag);
/*Section="End"*/
END;
