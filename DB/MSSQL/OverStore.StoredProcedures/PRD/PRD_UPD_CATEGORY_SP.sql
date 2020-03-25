-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_CATEGORY_SP
    @CategoryID INT,
    @Category   VARCHAR(100),
    @Comment    VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        CATEGORYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CATEGORY_NM,
        COMMENT_DSC
      FROM
        PRD_CATEGORY C (NOLOCK)
     WHERE
        C.CATEGORYID = @CategoryID;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_CATEGORY
       SET
           CATEGORY_NM = @Category,
           COMMENT_DSC = @Comment
     WHERE CATEGORYID = @CategoryID;

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
