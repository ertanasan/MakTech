-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_RECONCILIATION_SP
    @StoreReconciliationId BIGINT
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

    /*Section="Query"*/
    -- Select
    SELECT
           R.RECONCILIATIONID,
           R.EVENT,
           R.ORGANIZATION,
           R.DELETED_FL,
           R.CREATE_DT,
           R.UPDATE_DT,
           R.CREATEUSER,
           R.UPDATEUSER,
           R.CREATECHANNEL,
           R.CREATEBRANCH,
           R.CREATESCREEN,
           R.TRANSACTION_DT,
           R.STORE,
           R.PREVIOUSDAYADVANCE_AMT,
           R.SALETOTAL_AMT,
           R.CASHTOTAL_AMT,
           R.CARDTOTAL_AMT,
           R.TOBANK_AMT,
           R.DIFFERENCE_AMT,
           R.DIFFERENCE_DSC,
           R.COMPLETED_AMT,
           R.EODADVANCE_AMT,
           R.RECONCILIATED_FL,
           R.APPROVED_FL
      FROM RCL_RECONCILIATION R (NOLOCK)
     WHERE R.RECONCILIATIONID = @StoreReconciliationId
       AND (@Organization IS NULL OR R.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
