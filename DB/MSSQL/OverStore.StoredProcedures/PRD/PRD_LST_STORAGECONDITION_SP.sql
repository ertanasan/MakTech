-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_STORAGECONDITION_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.STORAGECONDITIONID,
           S.CONDITION_TXT,
           S.COMMENT_DSC
      FROM PRD_STORAGECONDITION S (NOLOCK)
     ORDER BY STORAGECONDITIONID;

/*Section="End"*/
END;
