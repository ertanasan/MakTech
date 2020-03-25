CREATE PROCEDURE [dbo].[STR_LST_STORECASHIER_SP] @StoreId INT AS
BEGIN

    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    SELECT C.*
      FROM STR_CASHIER C (NOLOCK)
     WHERE (@Organization IS NULL OR C.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
	   AND C.STORE = @StoreId
     ORDER BY CASHIERID;

END
