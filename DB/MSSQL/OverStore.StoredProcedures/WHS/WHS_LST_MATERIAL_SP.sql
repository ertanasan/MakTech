-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_MATERIAL_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           M.MATERIALID,
           M.MATERIAL_NM,
           M.MIKRO_DSC,
           M.UNIT_CD,
           M.MATERIALCATEGORY
      FROM WHS_MATERIAL M (NOLOCK)
     ORDER BY MATERIAL_NM;

/*Section="End"*/
END;
