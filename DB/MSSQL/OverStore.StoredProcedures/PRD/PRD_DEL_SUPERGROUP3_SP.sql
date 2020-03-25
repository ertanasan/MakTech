-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_SUPERGROUP3_SP
    @SuperGroup3Id INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_SUPERGROUP3LOG
    (
        SUPERGROUP3ID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUPERGROUP3_NM,
        COMMENT_DSC    )    
    SELECT
        SUPERGROUP3ID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPERGROUP3_NM,
        COMMENT_DSC
      FROM
        PRD_SUPERGROUP3 S (NOLOCK)
     WHERE
        S.SUPERGROUP3ID = @SuperGroup3Id;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_SUPERGROUP3
     WHERE SUPERGROUP3ID = @SuperGroup3Id;

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
