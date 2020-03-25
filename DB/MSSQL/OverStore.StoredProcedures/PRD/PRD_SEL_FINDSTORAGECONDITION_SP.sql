-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDSTORAGECONDITION_SP
    @Condition VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.STORAGECONDITIONID,
           S.CONDITION_TXT,
           S.COMMENT_DSC
      FROM PRD_STORAGECONDITION S (NOLOCK)
     WHERE S.CONDITION_TXT = @Condition;

/*Section="End"*/
END;
