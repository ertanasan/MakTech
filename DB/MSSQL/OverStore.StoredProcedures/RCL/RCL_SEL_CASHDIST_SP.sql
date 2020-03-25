-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_CASHDIST_SP
    @CashDistributionId BIGINT
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
           C.CASHDISTID,
           C.EVENT,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.CREATECHANNEL,
           C.CREATEBRANCH,
           C.CREATESCREEN,
           C.STOREREC,
           C.BANKNOTE,
           C.QUANTITY_QTY,
           C.GROUP_CD
      FROM RCL_CASHDIST C (NOLOCK)
     WHERE C.CASHDISTID = @CashDistributionId
       AND (@Organization IS NULL OR C.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
