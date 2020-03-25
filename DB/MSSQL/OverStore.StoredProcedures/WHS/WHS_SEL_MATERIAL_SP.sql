-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_MATERIAL_SP
    @MaterialId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           M.MATERIALID,
           M.MATERIAL_NM,
           M.MIKRO_DSC,
           M.UNIT_CD,
           M.MATERIALCATEGORY      
      FROM WHS_MATERIAL M (NOLOCK)
     WHERE M.MATERIALID = @MaterialId;

    /*Section="End"*/
END;
