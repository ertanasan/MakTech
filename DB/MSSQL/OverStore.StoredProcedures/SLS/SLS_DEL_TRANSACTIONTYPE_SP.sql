-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_DEL_TRANSACTIONTYPE_SP
    @TransactionTypeId INT
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
        TRANSACTION_NM    )    
    SELECT
        TRANSACTIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TRANSACTION_NM
      FROM
        SLS_TRANSACTIONTYPE T (NOLOCK)
     WHERE
        T.TRANSACTIONTYPEID = @TransactionTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM SLS_TRANSACTIONTYPE
     WHERE TRANSACTIONTYPEID = @TransactionTypeId;

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
