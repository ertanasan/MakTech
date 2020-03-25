-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_UPD_TASK_SP
    @OverStoreTaskId   BIGINT,
    @Event             INT,
    @Organization      INT,
    @Status            INT,
    @Type              INT,
    @Content           VARCHAR(1000),
    @Deadline          DATETIME,
    @ResponsibleType   INT,
    @ResponsibleUser   INT,
    @ResponsibleGroup  INT,
    @ResponsibleBranch INT,
    @ProcessInstance   BIGINT,
    @ForwardableFlag   VARCHAR(1),
    @Folder            BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE OSM_TASK
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STATUS = @Status,
           TYPE = @Type,
           CONTENT_TXT = @Content,
           DEADLINE_TM = @Deadline,
           RESPONSIBLETYPE_CD = @ResponsibleType,
           RESPONSIBLEUSER = @ResponsibleUser,
           RESPONSIBLEGROUP = @ResponsibleGroup,
           RESPONSIBLEBRANCH = @ResponsibleBranch,
           PROCESSINSTANCE_LNO = @ProcessInstance,
           FORWARDABLE_FL = @ForwardableFlag,
           FOLDER = @Folder
     WHERE TASKID = @OverStoreTaskId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
