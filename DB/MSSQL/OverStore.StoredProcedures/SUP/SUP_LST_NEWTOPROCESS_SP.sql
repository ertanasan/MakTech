CREATE PROCEDURE SUP_LST_NEWTOPROCESS_SP
AS
BEGIN
    DECLARE @SelectedDataUploads SYS_LONGS;
    DECLARE @Count INT = 0;

    -- Select
    BEGIN TRANSACTION TRX;
    INSERT INTO @SelectedDataUploads
        SELECT TOP 3 DATAUPLOADID
          FROM SUP_DATAUPLOAD WITH (UPDLOCK, ROWLOCK, READPAST) 
         WHERE STATUS IN (1) -- UploadStatus.New
		 ORDER BY CREATE_DT DESC;

    -- Read the data upload count
    SELECT @Count = COUNT(*)
      FROM @SelectedDataUploads;

    SELECT
           D.DATAUPLOADID,
           D.ORGANIZATION,
           D.EVENT,
           D.DELETED_FL,
           D.CREATE_DT,
           D.UPDATE_DT,
           D.CREATEUSER,
           D.UPDATEUSER,
           D.CREATECHANNEL,
           D.CREATEBRANCH,
           D.CREATESCREEN,
           D.TYPE,
           D.STATUS,
           D.DOCUMENT,
           D.UPLOAD_DT,
           D.PROCESS_DT,
           D.SOURCE_REF
      FROM SUP_DATAUPLOAD D (NOLOCK)
     WHERE D.DATAUPLOADID IN (SELECT Value FROM @SelectedDataUploads);

    -- Update selected data uploads to 'Processing' status so nobody can select it
    IF @Count > 0
    BEGIN
        UPDATE SUP_DATAUPLOAD
           SET STATUS = 2 -- UploadStatus.Processing
         WHERE DATAUPLOADID IN (SELECT Value FROM @SelectedDataUploads);
    END;
    COMMIT TRANSACTION TRX;
END;
