-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_MATERIALCATEGORY_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           M.MATERIALCATEGORYID,
           M.CATEGORY_NM
      FROM WHS_MATERIALCATEGORY M (NOLOCK)
     ORDER BY CATEGORY_NM;

/*Section="End"*/
END;
