-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_DEL_TASKDOCUMENT_SP
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

    /*Section="Delete"*/
    SET NOCOUNT OFF;
    -- Perform deletion
    DELETE OSM_TASKDOCUMENT
      FROM OSM_TASKDOCUMENT (NOLOCK)
      JOIN OSM_TASK OVERSTORETASK (NOLOCK) ON OSM_TASKDOCUMENT.TASK = OVERSTORETASK.TASKID AND (@Organization IS NULL OR OVERSTORETASK.ORGANIZATION = @Organization)
      JOIN DOC_DOCUMENT DOCUMENT (NOLOCK) ON OSM_TASKDOCUMENT.DOCUMENT = DOCUMENT.DOCUMENTID AND (@Organization IS NULL OR DOCUMENT.ORGANIZATION = @Organization)
     WHERE OSM_TASKDOCUMENT.TASK = @OverStoreTask
       AND OSM_TASKDOCUMENT.DOCUMENT = @Document;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
