-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_INS_DATAUPLOAD_SP
    @DataUploadId INT OUT,
    @Organization INT,
    @Event        INT,
    @UploadType   INT,
    @Status       INT,
    @Document     BIGINT,
    @UploadDate   DATETIME,
    @ProcessDate  DATETIME,
    @SourceRef    VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SUP_DATAUPLOAD
    (
        ORGANIZATION,
        EVENT,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        TYPE,
        STATUS,
        DOCUMENT,
        UPLOAD_DT,
        PROCESS_DT,
        SOURCE_REF
    )
    VALUES
    (
        @Organization,
        @Event,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @UploadType,
        @Status,
        @Document,
        @UploadDate,
        @ProcessDate,
        @SourceRef
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
    SELECT @DataUploadId = SCOPE_IDENTITY();
/*Section="End"*/
END;
