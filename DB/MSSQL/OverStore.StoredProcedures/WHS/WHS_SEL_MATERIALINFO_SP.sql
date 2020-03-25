-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_MATERIALINFO_SP
    @MaterialInfoId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           M.MATERIALINFOID,
           M.MATERIAL,
           M.INFOSHORT_NM,
           M.INFO_NM      
      FROM WHS_MATERIALINFO M (NOLOCK)
     WHERE M.MATERIALINFOID = @MaterialInfoId;

    /*Section="End"*/
END;
