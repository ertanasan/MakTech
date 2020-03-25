-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REQUEST_SP
    @HelpdeskRequestId  BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REQUEST
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        REQUESTDEFINITION,
        REQUEST_DSC,
        STATUS_CD,
        PROCESSINSTANCE_LNO,
        STORE,
        REDIRECTIONGROUP,
        PHONENUMBER_TXT,
        RESPONSIBLEUSER
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
        @RequestDefinition,
        @RequestDescription,
        @StatusCode,
        @ProcessInstance,
        @Store,
        @RedirectionGroup,
        @ContactPhoneNumber,
        @ResponsibleUser
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
    SELECT @HelpdeskRequestId = SCOPE_IDENTITY();
/*Section="End"*/
END;
