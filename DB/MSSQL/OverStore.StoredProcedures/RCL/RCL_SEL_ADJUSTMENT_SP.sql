-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_ADJUSTMENT_SP
    @AdjustmentId BIGINT
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
           A.ADJUSTMENTID,
           A.EVENT,
           A.ORGANIZATION,
           A.DELETED_FL,
           A.CREATE_DT,
           A.UPDATE_DT,
           A.CREATEUSER,
           A.UPDATEUSER,
           A.CREATECHANNEL,
           A.CREATEBRANCH,
           A.CREATESCREEN,
           A.STORE,
           A.AMOUNT_AMT,
           A.DESCRIPTION_DSC,
           A.DATE_DT      
      FROM RCL_ADJUSTMENT A (NOLOCK)
     WHERE A.ADJUSTMENTID = @AdjustmentId     
       AND (@Organization IS NULL OR A.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
