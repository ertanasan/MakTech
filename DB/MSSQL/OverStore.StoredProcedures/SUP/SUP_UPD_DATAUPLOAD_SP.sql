-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_UPD_DATAUPLOAD_SP
    @DataUploadId INT,
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
    UPDATE SUP_DATAUPLOAD
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           TYPE = @UploadType,
           STATUS = @Status,
           DOCUMENT = @Document,
           UPLOAD_DT = @UploadDate,
           PROCESS_DT = @ProcessDate,
           SOURCE_REF = @SourceRef
     WHERE DATAUPLOADID = @DataUploadId
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
