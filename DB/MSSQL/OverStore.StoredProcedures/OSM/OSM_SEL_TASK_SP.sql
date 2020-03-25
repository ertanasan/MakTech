-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_TASK_SP
    @OverStoreTaskId BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Get last action comment
	DECLARE @PreviousActionComment VARCHAR(4000);
	 SELECT TOP(1) @PreviousActionComment = ISNULL(A.USERCOMMENT_DSC, ' ')
	   FROM BPA_ACTION (NOLOCK) A
	   JOIN OSM_TASK (NOLOCK) T ON A.PROCESSINSTANCE = T.PROCESSINSTANCE_LNO
	  WHERE T.TASKID = @OverStoreTaskId
	    AND A.CHOICE_TXT IS NOT NULL
      ORDER BY A.CREATE_DT DESC; 

    -- Select
    SELECT
           T.TASKID,
           T.EVENT,
           T.ORGANIZATION,
           T.DELETED_FL,
           T.CREATE_DT,
           T.UPDATE_DT,
           T.CREATEUSER,
           T.UPDATEUSER,
           T.CREATECHANNEL,
           T.CREATEBRANCH,
           T.CREATESCREEN,
           T.STATUS,
           T.TYPE,
           T.CONTENT_TXT,
           T.DEADLINE_TM,
           T.RESPONSIBLETYPE_CD,
           T.RESPONSIBLEUSER,
           T.RESPONSIBLEGROUP,
           T.RESPONSIBLEBRANCH,
           T.PROCESSINSTANCE_LNO,
           T.FORWARDABLE_FL,
           T.FOLDER,
           @PreviousActionComment PREVIOUSACTIONCOMMENT_DSC
      FROM OSM_TASK T (NOLOCK)
     WHERE T.TASKID = @OverStoreTaskId
       AND (@Organization IS NULL OR T.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
