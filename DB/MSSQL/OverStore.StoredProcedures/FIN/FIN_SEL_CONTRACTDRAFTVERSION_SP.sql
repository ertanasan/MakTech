-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_CONTRACTDRAFTVERSION_SP
    @ContractDraftVersionId INT
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
           C.CONTRACTDRAFTVERSIONID,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.DRAFTDOCUMENT,
           C.CHANGEDETAIL_DSC      
      FROM FIN_CONTRACTDRAFTVERSION C (NOLOCK)
     WHERE C.CONTRACTDRAFTVERSIONID = @ContractDraftVersionId     
       AND (@Organization IS NULL OR C.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
