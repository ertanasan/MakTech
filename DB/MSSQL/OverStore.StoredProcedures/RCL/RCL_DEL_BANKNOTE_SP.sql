-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_DEL_BANKNOTE_SP
    @BanknoteId INT
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
        COIN_FL    )    
    SELECT
        BANKNOTEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BANKNOTE_AMT,
        COIN_FL
      FROM
        RCL_BANKNOTE B (NOLOCK)
     WHERE
        B.BANKNOTEID = @BanknoteId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM RCL_BANKNOTE
     WHERE BANKNOTEID = @BanknoteId;

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
