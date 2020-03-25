-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_FIRM_SP
    @FirmId   INT,
    @Name     VARCHAR(100),
    @FirmType INT,
    @Comment  VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        FIRMID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_FIRM
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           FIRM_NM = @Name,
           FIRMTYPE = @FirmType,
           COMMENT_DSC = @Comment
     WHERE FIRMID = @FirmId     
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
