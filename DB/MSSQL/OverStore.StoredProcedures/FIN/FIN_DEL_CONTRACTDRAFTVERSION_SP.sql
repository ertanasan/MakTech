-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_DEL_CONTRACTDRAFTVERSION_SP
    @ContractDraftVersionId INT
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
        CHANGEDETAIL_DSC    )    
    SELECT
        CONTRACTDRAFTVERSIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE FIN_CONTRACTDRAFTVERSION
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE CONTRACTDRAFTVERSIONID = @ContractDraftVersionId
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
