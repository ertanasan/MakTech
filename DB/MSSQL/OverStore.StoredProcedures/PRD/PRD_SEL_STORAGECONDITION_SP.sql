-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_STORAGECONDITION_SP
    @StorageConditionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.STORAGECONDITIONID,
           S.CONDITION_TXT,
           S.COMMENT_DSC
      FROM PRD_STORAGECONDITION S (NOLOCK)
     WHERE S.STORAGECONDITIONID = @StorageConditionId;

    /*Section="End"*/
END;
