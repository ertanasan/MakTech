-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_CASHIER_SP
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
           C.CASHIERID,
           C.ORGANIZATION,
           C.DELETED_FL,
           C.CREATE_DT,
           C.UPDATE_DT,
           C.CREATEUSER,
           C.UPDATEUSER,
           C.STORE,
           C.CASHIER_NM,
           C.CASHIERTEMPLATE,
           C.CASHIERTITLE,
           C.PASSWORD_NO,
           C.ISCASHIER_FL,
           C.ISACTIVE_FL,
           C.ISSALESMAN_FL,
           C.WORKINGTYPE_CD,
           C.NOTE_TXT
      FROM STR_CASHIER C (NOLOCK)
     WHERE (@Organization IS NULL OR C.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY CASHIERID;

/*Section="End"*/
END;
