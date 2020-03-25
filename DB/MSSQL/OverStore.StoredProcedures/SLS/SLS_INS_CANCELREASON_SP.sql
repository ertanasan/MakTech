-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_INS_CANCELREASON_SP
    @CancelReasonId      BIGINT OUT,
    @Event               INT,
    @Organization        INT,
    @StoreReconciliation BIGINT,
    @SaleDetail          BIGINT,
    @ReasonText          VARCHAR(1000),
    @CashierName         VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF

	UPDATE SLS_CANCELREASON
       SET UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STOREREC = @StoreReconciliation,
           REASON_TXT = @ReasonText,
           CASHIER_NM = @CashierName
     WHERE SALEDETAIL = @SaleDetail

	IF @@ROWCOUNT = 0
    BEGIN
		-- Insert record
		INSERT INTO SLS_CANCELREASON
		(
			EVENT,
			ORGANIZATION,
			DELETED_FL,
			CREATE_DT,
			CREATEUSER,
			CREATECHANNEL,
			CREATEBRANCH,
			CREATESCREEN,
			STOREREC,
			SALEDETAIL,
			REASON_TXT,
			CASHIER_NM
		)
		VALUES
		(
			@Event,
			@Organization,
			'N',
			GETDATE(),
			dbo.SYS_GETCURRENTUSER_FN(),
			dbo.SYS_GETCURRENTCHANNEL_FN(),
			dbo.SYS_GETCURRENTBRANCH_FN(),
			dbo.SYS_GETCURRENTSCREEN_FN(),
			@StoreReconciliation,
			@SaleDetail,
			@ReasonText,
			@CashierName
		);
		
		SELECT @CancelReasonId = SCOPE_IDENTITY();
    END
	ELSE 
	BEGIN
		SELECT TOP 1 @CancelReasonId = CANCELREASONID 
		  FROM SLS_CANCELREASON
		 WHERE SALEDETAIL = @SaleDetail
	END

    SET NOCOUNT ON;
END;
