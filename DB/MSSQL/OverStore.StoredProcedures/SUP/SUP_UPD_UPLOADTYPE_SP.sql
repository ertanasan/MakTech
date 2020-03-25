-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_UPD_UPLOADTYPE_SP
    @UploadTypeId INT,
    @Name         VARCHAR(100),
    @Description  VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO SUP_UPLOADTYPELOG
    (
        UPLOADTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        UPLOADTYPE_NM,
        COMMENT_DSC
    )    
    SELECT
        UPLOADTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        UPLOADTYPE_NM,
        COMMENT_DSC
      FROM
        SUP_UPLOADTYPE U (NOLOCK)
     WHERE
        U.UPLOADTYPEID = @UploadTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SUP_UPLOADTYPE
       SET
           UPLOADTYPE_NM = @Name,
           COMMENT_DSC = @Description
     WHERE UPLOADTYPEID = @UploadTypeId;

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
