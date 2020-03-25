-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_FIXTURE_SP
    @Store INT = NULL
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
           F.FIXTUREID,
           F.ORGANIZATION,
           F.DELETED_FL,
           F.CREATE_DT,
           F.UPDATE_DT,
           F.CREATEUSER,
           F.UPDATEUSER,
           F.FIXTURE,
           F.PURCHASE_DT,
           F.SERIALNO_TXT,
           F.ENDOFGUARANTEE_DT,
           F.SUPPLIER,
           F.STORE,
           F.STOREFIXTURE_NM,
           F.BRAND,
           F.MODEL,
           F.QUANTITY_QTY
      FROM STR_FIXTURE F (NOLOCK)
     WHERE (@Store IS NULL OR F.STORE = @Store)
       AND (@Organization IS NULL OR F.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY STOREFIXTURE_NM;

/*Section="End"*/
END;
