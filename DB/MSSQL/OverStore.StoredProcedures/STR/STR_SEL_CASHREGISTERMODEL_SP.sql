-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_CASHREGISTERMODEL_SP
    @CashRegisterModelId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CASHREGISTERMODELID,
           C.BRAND,
           C.MODEL_NM,
           C.COMMENT_DSC      
      FROM STR_CASHREGISTERMODEL C (NOLOCK)
     WHERE C.CASHREGISTERMODELID = @CashRegisterModelId;

    /*Section="End"*/
END;
