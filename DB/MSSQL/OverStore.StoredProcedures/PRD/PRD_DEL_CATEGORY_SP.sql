-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_CATEGORY_SP
    @CategoryID INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_CATEGORYLOG
    (
        CATEGORYID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CATEGORY_NM,
        COMMENT_DSC    )    
    SELECT
        CATEGORYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CATEGORY_NM,
        COMMENT_DSC
      FROM
        PRD_CATEGORY C (NOLOCK)
     WHERE
        C.CATEGORYID = @CategoryID;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_CATEGORY
     WHERE CATEGORYID = @CategoryID;

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
