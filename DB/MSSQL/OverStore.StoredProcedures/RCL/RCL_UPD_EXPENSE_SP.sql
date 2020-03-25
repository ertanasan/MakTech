-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_EXPENSE_SP
    @ExpenseId            BIGINT,
    @Event                INT,
    @Organization         INT,
    @ExpenseType          INT,
    @Store                INT,
    @ExpenseDate          DATETIME,
    @ExpenseAmount        NUMERIC(22,6),
    @ReceiptNo            VARCHAR(100),
    @OpenFlag             VARCHAR(1),
    @PayOffDate           DATETIME,
    @ExpenseDescription   VARCHAR(1000),
    @VATRate              NUMERIC(4,2),
    @MikroTransactionCode INT,
    @MikroTime            DATETIME,
    @StatusCode           INT,
    @StatusText           VARCHAR(1000),
    @MikroUser            INT,
    @HasReceipt           VARCHAR(1),
    @RegionManager        INT
AS
BEGIN

 INSERT INTO RCL_EXPENSELOG
    (
        EXPENSEID, LOG_DT, LOGUSER, LOGOPERATION_CD, LOGCHANNEL, LOGBRANCH, LOGSCREEN, 
		EXPENSETYPE, STORE, EXPENSE_DT, EXPENSE_AMT, RECEIPTNO_TXT, OPEN_FL, PAYOFF_DT,
		EXPENSE_DSC, VAT_RT
 )
    SELECT
        E.EXPENSEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EXPENSETYPE, STORE, EXPENSE_DT, EXPENSE_AMT, RECEIPTNO_TXT,
  OPEN_FL, PAYOFF_DT, EXPENSE_DSC, VAT_RT
      FROM
        RCL_EXPENSE E (NOLOCK)
     WHERE
        E.EXPENSEID = @ExpenseId;

    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_EXPENSE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           EXPENSETYPE = @ExpenseType,
           STORE = @Store,
           EXPENSE_DT = CAST(@ExpenseDate AS DATE),
           EXPENSE_AMT = @ExpenseAmount,
           RECEIPTNO_TXT = @ReceiptNo,
           OPEN_FL = @OpenFlag,
		   -- 3 saat eklenmesinin sebebi saat 21'den sonra yapılan ödemelerin 1 sonraki mutabakat için geçerli olabilmesi için.   
           PAYOFF_DT = CASE WHEN @OpenFlag = 'N' AND PAYOFF_DT IS NULL THEN CAST(GETDATE()+(3.0/24.0) AS date) ELSE PAYOFF_DT END,
           EXPENSE_DSC = @ExpenseDescription,
           VAT_RT = @VATRate,
           MIKRO_CD = @MikroTransactionCode,
           MIKRO_TM = @MikroTime,
           STATUS_CD = @StatusCode,
           STATUS_TXT = @StatusText,
           MIKROUSER = @MikroUser,
           HASRECEIPT_FL = @HasReceipt,
           REGIONMANAGER = @RegionManager
     WHERE EXPENSEID = @ExpenseId
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
