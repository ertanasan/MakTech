-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_PRODUCTRETURNREASON_SP
    @ProductReturnReasonId BIGINT
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
           P.PRODUCTRETURNREASONID,
           P.EVENT,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           P.PRODUCTRETURN,
           P.RETURNREASON      
      FROM WHS_PRODUCTRETURNREASON P (NOLOCK)
     WHERE P.PRODUCTRETURNREASONID = @ProductReturnReasonId     
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
