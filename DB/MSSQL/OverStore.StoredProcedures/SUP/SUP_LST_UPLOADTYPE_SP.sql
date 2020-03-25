-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_LST_UPLOADTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           U.UPLOADTYPEID,
           U.UPLOADTYPE_NM,
           U.COMMENT_DSC
      FROM SUP_UPLOADTYPE U (NOLOCK)
     ORDER BY UPLOADTYPE_NM;

/*Section="End"*/
END;
