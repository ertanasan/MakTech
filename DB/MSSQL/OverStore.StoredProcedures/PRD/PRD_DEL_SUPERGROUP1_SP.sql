-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_SUPERGROUP1_SP
    @SuperGroup1Id INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_SUPERGROUP1LOG
    (
        SUPERGROUP1ID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUPERGROUP1_NM,
        COMMENT_DSC    )    
    SELECT
        SUPERGROUP1ID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPERGROUP1_NM,
        COMMENT_DSC
      FROM
        PRD_SUPERGROUP1 S (NOLOCK)
     WHERE
        S.SUPERGROUP1ID = @SuperGroup1Id;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_SUPERGROUP1
     WHERE SUPERGROUP1ID = @SuperGroup1Id;

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
