-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_ATTRIBUTETYPE_SP
    @AttributeTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_ATTRIBUTETYPELOG
    (
        ATTRIBUTETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ATTRIBUTETYPE_NM    )    
    SELECT
        ATTRIBUTETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ATTRIBUTETYPE_NM
      FROM
        HDK_ATTRIBUTETYPE A (NOLOCK)
     WHERE
        A.ATTRIBUTETYPEID = @AttributeTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_ATTRIBUTETYPE
     WHERE ATTRIBUTETYPEID = @AttributeTypeId;

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
