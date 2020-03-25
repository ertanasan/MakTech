-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_LST_TASK_SP
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
    END;
    /*Section="Query"*/
    -- Select all
    
    WITH PREVCOMM AS (
		SELECT T.TASKID, A.PROCESSINSTANCE, ISNULL(A.USERCOMMENT_DSC, ' ') USERCOMMENT_DSC, T.STATUS
		     , ROW_NUMBER() OVER (PARTITION BY T.TASKID ORDER BY A.CREATE_DT DESC) ROWNO
		  FROM BPA_ACTION (NOLOCK) A
          JOIN OSM_TASK (NOLOCK) T ON A.PROCESSINSTANCE = T.PROCESSINSTANCE_LNO
         WHERE T.STATUS > 1
	)
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
           P.USERCOMMENT_DSC PREVIOUSACTIONCOMMENT_DSC
      FROM OSM_TASK T (NOLOCK)
      LEFT JOIN PREVCOMM P ON T.TASKID = P.TASKID AND P.ROWNO = 2
     WHERE (@Organization IS NULL OR T.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY TASKID;

/*Section="End"*/
END;
