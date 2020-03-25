-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_USERSSTORES_SP
    @User INT,
    @Store INT
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
           U.[USER],
           U.STORE,
           U.CREATE_DT,
           U.CREATEUSER,
           U.CREATECHANNEL,
           U.CREATEBRANCH,
           U.CREATESCREEN,
           [USER].USER_NM "USER.USER_NM",
           STORE.STORE_NM "STORE.STORE_NM"
      FROM STR_USERSSTORES U (NOLOCK)
      JOIN SEC_USER [USER] (NOLOCK) ON U.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
      JOIN STR_STORE STORE (NOLOCK) ON U.STORE = STORE.STOREID AND (@Organization IS NULL OR STORE.ORGANIZATION = @Organization)
     WHERE U.[USER] = @User
       AND U.STORE = @Store;

/*Section="End"*/
END;
