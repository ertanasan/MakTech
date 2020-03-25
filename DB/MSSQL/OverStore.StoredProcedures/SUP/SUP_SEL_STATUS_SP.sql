-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_SEL_STATUS_SP
    @StatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.STATUSID,
           S.STATUS_NM,
           S.COMMENT_DSC      
      FROM SUP_STATUS S (NOLOCK)
     WHERE S.STATUSID = @StatusId;

    /*Section="End"*/
END;
