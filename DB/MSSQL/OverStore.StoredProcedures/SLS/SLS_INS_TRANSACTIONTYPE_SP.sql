-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_TRANSACTIONTYPE_SP
    @TransactionTypeId INT,
    @TransactionName   VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SLS_TRANSACTIONTYPE
    (
        TRANSACTIONTYPEID,
        TRANSACTION_NM
    )
    VALUES
    (
        @TransactionTypeId,
        @TransactionName
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
    VALUES
    (
        @TransactionTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @TransactionName);
/*Section="End"*/
END;
