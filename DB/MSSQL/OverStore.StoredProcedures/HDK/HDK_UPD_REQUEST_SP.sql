-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_REQUEST_SP
    @HelpdeskRequestId  BIGINT,
    @Event              INT,
    @Organization       INT,
    @RequestDefinition  INT,
    @RequestDescription VARCHAR(1000),
    @StatusCode         INT,
    @ProcessInstance    BIGINT,
    @Store              INT,
    @RedirectionGroup   INT,
    @ContactPhoneNumber VARCHAR(100),
    @ResponsibleUser    INT
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
    UPDATE HDK_REQUEST
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           REQUESTDEFINITION = @RequestDefinition,
           REQUEST_DSC = @RequestDescription,
           STATUS_CD = @StatusCode,
           PROCESSINSTANCE_LNO = @ProcessInstance,
           STORE = @Store,
           REDIRECTIONGROUP = @RedirectionGroup,
           PHONENUMBER_TXT = @ContactPhoneNumber,
           RESPONSIBLEUSER = @ResponsibleUser
     WHERE REQUESTID = @HelpdeskRequestId
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
