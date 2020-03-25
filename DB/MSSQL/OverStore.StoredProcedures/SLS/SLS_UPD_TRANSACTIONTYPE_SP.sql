-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_TRANSACTIONTYPE_SP
    @TransactionTypeId INT,
    @TransactionName   VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO SLS_TRANSACTIONTYPELOG
    (
        TRANSACTIONTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        TRANSACTION_NM
    )    
    SELECT
        TRANSACTIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TRANSACTION_NM
      FROM
        SLS_TRANSACTIONTYPE T (NOLOCK)
     WHERE
        T.TRANSACTIONTYPEID = @TransactionTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SLS_TRANSACTIONTYPE
       SET
           TRANSACTION_NM = @TransactionName
     WHERE TRANSACTIONTYPEID = @TransactionTypeId;

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
