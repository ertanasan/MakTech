-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDSUPERGROUP2_SP
    @SuperGroup2Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPERGROUP2ID,
           S.SUPERGROUP2_NM,
           S.COMMENT_DSC      
      FROM PRD_SUPERGROUP2 S (NOLOCK)
     WHERE S.SUPERGROUP2_NM = @SuperGroup2Name;

/*Section="End"*/
END;
