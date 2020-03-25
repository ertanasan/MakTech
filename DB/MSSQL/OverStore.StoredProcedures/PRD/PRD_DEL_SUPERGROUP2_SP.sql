-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_SUPERGROUP2_SP
    @SuperGroup2Id INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_SUPERGROUP2LOG
    (
        SUPERGROUP2ID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUPERGROUP2_NM,
        COMMENT_DSC    )    
    SELECT
        SUPERGROUP2ID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPERGROUP2_NM,
        COMMENT_DSC
      FROM
        PRD_SUPERGROUP2 S (NOLOCK)
     WHERE
        S.SUPERGROUP2ID = @SuperGroup2Id;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_SUPERGROUP2
     WHERE SUPERGROUP2ID = @SuperGroup2Id;

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
