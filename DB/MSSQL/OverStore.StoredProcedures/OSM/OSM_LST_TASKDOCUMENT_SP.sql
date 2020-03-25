-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_LST_TASKDOCUMENT_SP
    @OverStoreTask BIGINT,
    @Document BIGINT
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

    /*Section="Parameter Check"*/
    -- Check the parameter values
    IF @OverStoreTask IS NULL AND @Document IS NULL
    BEGIN
        DECLARE @ErrorMessage VARCHAR(250);
        SET @ErrorMessage='At least one parameter should not be null.';
        THROW 100002, @ErrorMessage, 1;
        RETURN;
    END

    /*Section="Query"*/
    -- Select all
    SELECT
           T.TASK,
           T.DOCUMENT,
           T.CREATE_DT,
           T.CREATEUSER,
           T.CREATECHANNEL,
           T.CREATEBRANCH,
           T.CREATESCREEN,
           OVERSTORETASK.TASKID "OVERSTORETASK.TASKID",
           DOCUMENT.DOCUMENT_NM "DOCUMENT.DOCUMENT_NM"
      FROM OSM_TASKDOCUMENT T (NOLOCK)
      JOIN OSM_TASK OVERSTORETASK (NOLOCK) ON T.TASK = OVERSTORETASK.TASKID AND (@Organization IS NULL OR OVERSTORETASK.ORGANIZATION = @Organization)
      JOIN DOC_DOCUMENT DOCUMENT (NOLOCK) ON T.DOCUMENT = DOCUMENT.DOCUMENTID AND (@Organization IS NULL OR DOCUMENT.ORGANIZATION = @Organization)
     WHERE (@OverStoreTask IS NULL OR T.TASK = @OverStoreTask)
       AND (@Document IS NULL OR T.DOCUMENT = @Document);

/*Section="End"*/
END;
