-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_MATERIALCATEGORY_SP
    @MaterialCategoryId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           M.MATERIALCATEGORYID,
           M.CATEGORY_NM      
      FROM WHS_MATERIALCATEGORY M (NOLOCK)
     WHERE M.MATERIALCATEGORYID = @MaterialCategoryId;

    /*Section="End"*/
END;
