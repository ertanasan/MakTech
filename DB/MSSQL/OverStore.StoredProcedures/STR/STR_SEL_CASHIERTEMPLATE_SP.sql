-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_CASHIERTEMPLATE_SP
    @CashierTemplateId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CASHIERTEMPLATEID,
           C.CASHIERTEMPLATE_NM      
      FROM STR_CASHIERTEMPLATE C (NOLOCK)
     WHERE C.CASHIERTEMPLATEID = @CashierTemplateId;

    /*Section="End"*/
END;
