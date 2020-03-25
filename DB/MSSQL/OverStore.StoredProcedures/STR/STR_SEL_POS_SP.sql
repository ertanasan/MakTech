-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_POS_SP
    @PosId INT
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
           P.POSID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.STORE,
           P.POSCODE_TXT,
           P.BANK,
           P.CASHREGISTERCODE_TXT,
           P.BANKCODE_TXT,
           P.DESCRIPTION_TXT,
           P.MOBIL_FL,
           P.OKC_TXT
      FROM STR_POS P (NOLOCK)
     WHERE P.POSID = @PosId
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
