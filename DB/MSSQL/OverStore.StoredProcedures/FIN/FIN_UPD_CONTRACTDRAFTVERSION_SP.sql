-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_CONTRACTDRAFTVERSION_SP
    @ContractDraftVersionId INT,
    @DocumentId             BIGINT,
    @ChangeDetails          VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        CONTRACTDRAFTVERSIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        DRAFTDOCUMENT,
        CHANGEDETAIL_DSC
      FROM
        FIN_CONTRACTDRAFTVERSION C (NOLOCK)
     WHERE
        C.CONTRACTDRAFTVERSIONID = @ContractDraftVersionId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE FIN_CONTRACTDRAFTVERSION
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           DRAFTDOCUMENT = @DocumentId,
           CHANGEDETAIL_DSC = @ChangeDetails
     WHERE CONTRACTDRAFTVERSIONID = @ContractDraftVersionId     
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
