-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_TASKHISTORY_SP
    @OverStoreTaskHistoryId BIGINT
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
    -- Select
    SELECT
           T.TASKHISTORYID,
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
           T.TASK,
           T.HISTORY_TM,
           T.STATUS,
           T.CHANGEDETAIL_DSC,
           T.RESPONSIBLETYPE_CD,
           T.RESPONSIBLEUSER,
           T.RESPONSIBLEGROUP,
           T.RESPONSIBLEBRANCH,
           T.FORWARDABLE_FL
      FROM OSM_TASKHISTORY T (NOLOCK)
     WHERE T.TASKHISTORYID = @OverStoreTaskHistoryId
       AND (@Organization IS NULL OR T.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
