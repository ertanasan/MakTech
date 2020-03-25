-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_DEL_UPLOADTYPE_SP
    @UploadTypeId INT
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
        COMMENT_DSC    )    
    SELECT
        UPLOADTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        UPLOADTYPE_NM,
        COMMENT_DSC
      FROM
        SUP_UPLOADTYPE U (NOLOCK)
     WHERE
        U.UPLOADTYPEID = @UploadTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM SUP_UPLOADTYPE
     WHERE UPLOADTYPEID = @UploadTypeId;

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
