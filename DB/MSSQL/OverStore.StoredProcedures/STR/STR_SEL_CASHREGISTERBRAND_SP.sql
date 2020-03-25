-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_CASHREGISTERBRAND_SP
    @CashRegisterBrandId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CASHREGISTERBRANDID,
           C.BRAND_NM,
           C.COMMENT_DSC      
      FROM STR_CASHREGISTERBRAND C (NOLOCK)
     WHERE C.CASHREGISTERBRANDID = @CashRegisterBrandId;

    /*Section="End"*/
END;
