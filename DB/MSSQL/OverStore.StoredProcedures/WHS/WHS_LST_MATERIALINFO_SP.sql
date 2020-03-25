-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_MATERIALINFO_SP
    @Material INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           M.MATERIALINFOID,
           M.MATERIAL,
           M.INFOSHORT_NM,
           M.INFO_NM
      FROM WHS_MATERIALINFO M (NOLOCK)
     WHERE (@Material IS NULL OR M.MATERIAL = @Material);

/*Section="End"*/
END;
