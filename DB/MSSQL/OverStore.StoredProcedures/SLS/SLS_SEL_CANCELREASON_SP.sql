-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_CANCELREASON_SP
    @CancelReasonId BIGINT
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
           C.CANCELREASONID,
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
           C.SALEDETAIL,
           C.REASON_TXT,
           C.CASHIER_NM      
      FROM SLS_CANCELREASON C (NOLOCK)
     WHERE C.CANCELREASONID = @CancelReasonId     
       AND (@Organization IS NULL OR C.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
