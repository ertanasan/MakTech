-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_STORE_SP
    @StoreId INT
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
           S.STOREID,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.STORE_NM,
           S.BRANCH,
           S.IPADDRESS_TXT,
           S.ADVANCE_AMT,
           S.OPENING_DT,
           S.CLOSING_DT,
           S.ACTIVE_FL,
           S.PRODUCTION_FL,
           S.CITY,
           S.TOWN,
           S.ADDRESS_TXT,
           S.REGIONMANAGER,
           S.INCONSTRUCTION_FL
      FROM STR_STORE S (NOLOCK)
     WHERE S.STOREID = @StoreId
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
