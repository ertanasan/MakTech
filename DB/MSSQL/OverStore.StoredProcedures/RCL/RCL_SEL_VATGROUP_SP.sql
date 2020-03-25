-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_VATGROUP_SP
    @VatGroupId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           V.VATGROUPID,
           V.VAT_RT      
      FROM RCL_VATGROUP V (NOLOCK)
     WHERE V.VATGROUPID = @VatGroupId;

    /*Section="End"*/
END;
