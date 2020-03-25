-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_BANKNOTE_SP
    @BanknoteId     INT,
    @BanknoteAmount NUMERIC(22,6),
    @CoinFlag       VARCHAR(1)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        BANKNOTEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BANKNOTE_AMT,
        COIN_FL
      FROM
        RCL_BANKNOTE B (NOLOCK)
     WHERE
        B.BANKNOTEID = @BanknoteId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_BANKNOTE
       SET
           BANKNOTE_AMT = @BanknoteAmount,
           COIN_FL = @CoinFlag
     WHERE BANKNOTEID = @BanknoteId;

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
