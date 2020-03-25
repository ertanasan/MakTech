-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_TASK_SP
    @OverStoreTaskId   BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO OSM_TASK
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STATUS,
        TYPE,
        CONTENT_TXT,
        DEADLINE_TM,
        RESPONSIBLETYPE_CD,
        RESPONSIBLEUSER,
        RESPONSIBLEGROUP,
        RESPONSIBLEBRANCH,
        PROCESSINSTANCE_LNO,
        FORWARDABLE_FL,
        FOLDER
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
        @Status,
        @Type,
        @Content,
        @Deadline,
        @ResponsibleType,
        @ResponsibleUser,
        @ResponsibleGroup,
        @ResponsibleBranch,
        @ProcessInstance,
        @ForwardableFlag,
        @Folder
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
    SELECT @OverStoreTaskId = SCOPE_IDENTITY();
/*Section="End"*/
END;
