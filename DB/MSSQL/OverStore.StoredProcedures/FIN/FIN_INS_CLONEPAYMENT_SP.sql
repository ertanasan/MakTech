CREATE PROCEDURE [dbo].[FIN_INS_CLONEPAYMENT_SP]
	@TemplateRecordId BIGINT, @ClonedRecordId BIGINT OUT
AS
	/*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
	INSERT INTO FIN_RENTPAYMENTPLAN 
	(
		   ORGANIZATION, 
		   DELETED_FL, 
		   CREATE_DT, 
		   CREATEUSER, 
		   ESTATERENTPERIOD, 
		   PAYMENTORDER_NO, 
		   DUE_DT, 
		   PAYMENT_AMT, 
		   CURRENCY_TXT, 
		   ADDITIONALPAYMENT_AMT, 
		   ADDPAYMENTCURRENCY_TXT
	)
	SELECT ORGANIZATION,
		   'N',
		   GETDATE(),
		   dbo.SYS_GETCURRENTUSER_FN(),
		   ESTATERENTPERIOD,
		   PAYMENTORDER_NO + 1,
		   DATEADD(MONTH, 1, DUE_DT),
		   PAYMENT_AMT,
		   CURRENCY_TXT,
		   ADDITIONALPAYMENT_AMT,
		   ADDPAYMENTCURRENCY_TXT
	  FROM FIN_RENTPAYMENTPLAN PP
	 WHERE PP.RENTPAYMENTPLANID = @TemplateRecordId;

	 /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @ClonedRecordId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO FIN_RENTPAYMENTPLANLOG
    (
            RENTPAYMENTPLANID,
            LOG_DT,
            LOGUSER,
            LOGOPERATION_CD,
            LOGCHANNEL,
            LOGBRANCH,
            LOGSCREEN,
            ESTATERENTPERIOD, 
		    PAYMENTORDER_NO, 
		    DUE_DT, 
		    PAYMENT_AMT, 
		    CURRENCY_TXT, 
		    ADDITIONALPAYMENT_AMT, 
		    ADDPAYMENTCURRENCY_TXT
    )
    SELECT
            @ClonedRecordId,
            GETDATE(),
            dbo.SYS_GETCURRENTUSER_FN(),
            'INS',
            dbo.SYS_GETCURRENTCHANNEL_FN(),
            dbo.SYS_GETCURRENTBRANCH_FN(),
            dbo.SYS_GETCURRENTSCREEN_FN(),
            ESTATERENTPERIOD, 
		    PAYMENTORDER_NO, 
		    DUE_DT, 
		    PAYMENT_AMT, 
		    CURRENCY_TXT, 
		    ADDITIONALPAYMENT_AMT, 
		    ADDPAYMENTCURRENCY_TXT
       FROM FIN_RENTPAYMENTPLAN PP
      WHERE PP.RENTPAYMENTPLANID = @ClonedRecordId;
/*Section="End"*/

