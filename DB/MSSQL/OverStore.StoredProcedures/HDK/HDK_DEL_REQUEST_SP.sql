-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_REQUEST_SP
    @HelpdeskRequestId BIGINT
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

	UPDATE PIN SET STATUS_CD = 10
	  FROM HDK_REQUEST R
	  JOIN BPM_PROCESSINSTANCE PIN ON R.PROCESSINSTANCE_LNO = PIN.PROCESSINSTANCEID
	 WHERE REQUESTID = @HelpdeskRequestId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE HDK_REQUEST
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE REQUESTID = @HelpdeskRequestId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
