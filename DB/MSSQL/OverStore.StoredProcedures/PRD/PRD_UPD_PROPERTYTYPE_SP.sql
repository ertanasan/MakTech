-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_PROPERTYTYPE_SP
    @PropertyTypeId INT,
    @Name           VARCHAR(100),
    @Description    VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_PROPERTYTYPELOG
    (
        PROPERTYTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE_NM,
        COMMENT_DSC
    )
    SELECT
        PROPERTYTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROPERTYTYPE_NM,
        COMMENT_DSC
      FROM
        PRD_PROPERTYTYPE P (NOLOCK)
     WHERE
        P.PROPERTYTYPEID = @PropertyTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_PROPERTYTYPE
       SET
           PROPERTYTYPE_NM = @Name,
           COMMENT_DSC = @Description
     WHERE PROPERTYTYPEID = @PropertyTypeId;

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
