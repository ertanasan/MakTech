-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_FIRM_SP
    @FirmId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_FIRMLOG
    (
        FIRMID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIRM_NM,
        FIRMTYPE,
        COMMENT_DSC    )    
    SELECT
        FIRMID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIRM_NM,
        FIRMTYPE,
        COMMENT_DSC
      FROM
        ACC_FIRM F (NOLOCK)
     WHERE
        F.FIRMID = @FirmId;
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
    UPDATE ACC_FIRM
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE(),
           FIRM_NM = LEFT(FIRM_NM, 99 - LEN(CONVERT(VARCHAR(20), FIRMID))) + '#' + CONVERT(VARCHAR(20), FIRMID)
     WHERE FIRMID = @FirmId
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
