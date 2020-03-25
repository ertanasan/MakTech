-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_SEL_FINDSTATUS_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.STATUSID,
           S.STATUS_NM,
           S.COMMENT_DSC      
      FROM SUP_STATUS S (NOLOCK)
     WHERE S.STATUS_NM = @Name;

/*Section="End"*/
END;
