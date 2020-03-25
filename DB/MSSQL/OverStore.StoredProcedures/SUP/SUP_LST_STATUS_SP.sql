-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_LST_STATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.STATUSID,
           S.STATUS_NM,
           S.COMMENT_DSC
      FROM SUP_STATUS S (NOLOCK)
     ORDER BY STATUS_NM;

/*Section="End"*/
END;
