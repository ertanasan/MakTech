-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_UPD_TASKHISTORY_SP
    @OverStoreTaskHistoryId BIGINT,
    @Event                  INT,
    @Organization           INT,
    @OverStoreTask          BIGINT,
    @HistoryTime            DATETIME,
    @Status                 INT,
    @ChangeDetail           VARCHAR(1000),
    @ResponsibleType        INT,
    @ResponsibleUser        INT,
    @ResponsibleGroup       INT,
    @ResponsibleBranch      INT,
    @ForwardableFlag        VARCHAR(1)
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
    UPDATE OSM_TASKHISTORY
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           TASK = @OverStoreTask,
           HISTORY_TM = @HistoryTime,
           STATUS = @Status,
           CHANGEDETAIL_DSC = @ChangeDetail,
           RESPONSIBLETYPE_CD = @ResponsibleType,
           RESPONSIBLEUSER = @ResponsibleUser,
           RESPONSIBLEGROUP = @ResponsibleGroup,
           RESPONSIBLEBRANCH = @ResponsibleBranch,
           FORWARDABLE_FL = @ForwardableFlag
     WHERE TASKHISTORYID = @OverStoreTaskHistoryId
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
