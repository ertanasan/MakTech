-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_STORE_SP
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
    -- Select all
    SELECT
           S.STORERECID,
           S.EVENT,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.CREATECHANNEL,
           S.CREATEBRANCH,
           S.CREATESCREEN,
           S.STORE,
           S.RECONCILIATION_DT,
           S.ZET_AMT,
           S.DEFINEDADVANCE_AMT,
           S.EXPENSE_AMT,
           S.CASH_AMT,
           S.CARD_AMT,
           S.RECOVERED_AMT,
           S.ADJUSTMENT_AMT,
           S.NETOFF_AMT,
           S.BANK_AMT,
           S.CURRENTADVANCE_AMT,
           S.EXPENSERETURN_AMT,
           S.DIFFREASONCODES_TXT,
           S.DIFFREASON_TXT,
           S.LASTSTEP_NO,
           S.COMPLETE_FL,
           S.ADJUSTMENT_DSC,
           S.DEFICITCYCLE_CNT
      FROM RCL_STORE S (NOLOCK)
     WHERE (@Organization IS NULL OR S.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY STORERECID;

/*Section="End"*/
END;
