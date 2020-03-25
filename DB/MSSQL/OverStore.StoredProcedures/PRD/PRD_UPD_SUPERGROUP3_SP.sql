-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_SUPERGROUP3_SP
    @SuperGroup3Id   INT,
    @SuperGroup3Name VARCHAR(100),
    @Comment         VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        SUPERGROUP3ID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPERGROUP3_NM,
        COMMENT_DSC
      FROM
        PRD_SUPERGROUP3 S (NOLOCK)
     WHERE
        S.SUPERGROUP3ID = @SuperGroup3Id;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_SUPERGROUP3
       SET
           SUPERGROUP3_NM = @SuperGroup3Name,
           COMMENT_DSC = @Comment
     WHERE SUPERGROUP3ID = @SuperGroup3Id;

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
