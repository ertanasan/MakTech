-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_DEL_SALEZET_SP
    @SaleDailySummaryId BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

	INSERT INTO SLS_SALEZETLOG
    (
        SALEZETID, LOG_DT, LOGUSER, LOGOPERATION_CD, LOGCHANNEL, LOGBRANCH, LOGSCREEN, EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, UPDATE_DT, 
		CREATEUSER, UPDATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, STORE, TRANSACTION_DT, ZET_NO, RECEIPT_CNT, RECEIPTTOTAL_AMT, 
		REFUND_CNT, REFUND_AMT, CASH_AMT, CARD_AMT, CASHREGISTER, SLPTOTAL_AMT, SLP_CNT
	)
    SELECT
        S.SALEZETID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, UPDATE_DT, 
		CREATEUSER, UPDATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, STORE, TRANSACTION_DT, ZET_NO, RECEIPT_CNT, RECEIPTTOTAL_AMT, 
		REFUND_CNT, REFUND_AMT, CASH_AMT, CARD_AMT, CASHREGISTER, SLPTOTAL_AMT, SLP_CNT
      FROM
        SLS_SALEZET S (NOLOCK)
     WHERE
        S.SALEZETID = @SaleDailySummaryId;

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE SLS_SALEZET
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE(),
		   UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN()
     WHERE SALEZETID = @SaleDailySummaryId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
