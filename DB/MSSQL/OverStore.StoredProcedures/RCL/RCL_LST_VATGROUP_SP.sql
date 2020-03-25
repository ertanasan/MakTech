-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_VATGROUP_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           V.VATGROUPID,
           V.VAT_RT
      FROM RCL_VATGROUP V (NOLOCK)
     ORDER BY VAT_RT;

/*Section="End"*/
END;
