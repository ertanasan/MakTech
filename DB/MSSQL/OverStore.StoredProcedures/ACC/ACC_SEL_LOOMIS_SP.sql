-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_LOOMIS_SP
    @LoomisId BIGINT
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
           L.LOOMISID,
           L.EVENT,
           L.ORGANIZATION,
           L.DELETED_FL,
           L.CREATE_DT,
           L.UPDATE_DT,
           L.CREATEUSER,
           L.UPDATEUSER,
           L.CREATECHANNEL,
           L.CREATEBRANCH,
           L.CREATESCREEN,
           L.SALE_DT,
           L.STORE,
           L.SEAL_TXT,
           L.DECLARED_AMT,
           L.ACTUAL_AMT,
           L.FAKE_AMT,
           L.EXPLANATION_TXT,
           L.MIKRO_TM,
           L.MIKROSTATUS_CD,
           L.MIKROTRANCODE_TXT,
           L.LOOMIS_DT
      FROM ACC_LOOMIS L (NOLOCK)
     WHERE L.LOOMISID = @LoomisId
       AND (@Organization IS NULL OR L.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
