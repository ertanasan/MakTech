-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_CONTRACTDRAFTVERSION_SP
    @ContractDraftVersionId INT OUT,
    @DocumentId             BIGINT,
    @ChangeDetails          VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO FIN_CONTRACTDRAFTVERSION
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        DRAFTDOCUMENT,
        CHANGEDETAIL_DSC
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @DocumentId,
        @ChangeDetails
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
    SELECT @ContractDraftVersionId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO FIN_CONTRACTDRAFTVERSIONLOG
    (
        CONTRACTDRAFTVERSIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        DRAFTDOCUMENT,
        CHANGEDETAIL_DSC
    )    
    VALUES
    (
        @ContractDraftVersionId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @DocumentId,
        @ChangeDetails);
/*Section="End"*/
END;
