-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_FINDVATGROUP_SP
    @VatRate NUMERIC(4,2)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           V.VATGROUPID,
           V.VAT_RT      
      FROM RCL_VATGROUP V (NOLOCK)
     WHERE V.VAT_RT = @VatRate;

/*Section="End"*/
END;
