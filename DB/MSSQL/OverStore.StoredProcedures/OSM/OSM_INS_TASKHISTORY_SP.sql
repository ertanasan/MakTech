-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_TASKHISTORY_SP
    @OverStoreTaskHistoryId BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO OSM_TASKHISTORY
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        TASK,
        HISTORY_TM,
        STATUS,
        CHANGEDETAIL_DSC,
        RESPONSIBLETYPE_CD,
        RESPONSIBLEUSER,
        RESPONSIBLEGROUP,
        RESPONSIBLEBRANCH,
        FORWARDABLE_FL
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @OverStoreTask,
        @HistoryTime,
        @Status,
        @ChangeDetail,
        @ResponsibleType,
        @ResponsibleUser,
        @ResponsibleGroup,
        @ResponsibleBranch,
        @ForwardableFlag
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @OverStoreTaskHistoryId = SCOPE_IDENTITY();
/*Section="End"*/
END;
