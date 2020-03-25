-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_UPD_PACKAGETYPE_SP
    @PackageTypeId   INT,
    @PackageTypeName VARCHAR(100),
    @Comment         VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRC_PACKAGETYPELOG
    (
        PACKAGETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PACKAGETYPE_NM,
        COMMENT_DSC
    )    
    SELECT
        PACKAGETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PACKAGETYPE_NM,
        COMMENT_DSC
      FROM
        PRC_PACKAGETYPE P (NOLOCK)
     WHERE
        P.PACKAGETYPEID = @PackageTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRC_PACKAGETYPE
       SET
           PACKAGETYPE_NM = @PackageTypeName,
           COMMENT_DSC = @Comment
     WHERE PACKAGETYPEID = @PackageTypeId;

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
