﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_USERSSTORES_SP
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

    /*Section="Delete"*/
    SET NOCOUNT OFF;
    -- Perform deletion
    DELETE STR_USERSSTORES
      FROM STR_USERSSTORES (NOLOCK)
      JOIN SEC_USER [USER] (NOLOCK) ON STR_USERSSTORES.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
      JOIN STR_STORE STORE (NOLOCK) ON STR_USERSSTORES.STORE = STORE.STOREID AND (@Organization IS NULL OR STORE.ORGANIZATION = @Organization)
     WHERE STR_USERSSTORES.[USER] = @User
       AND STR_USERSSTORES.STORE = @Store;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
