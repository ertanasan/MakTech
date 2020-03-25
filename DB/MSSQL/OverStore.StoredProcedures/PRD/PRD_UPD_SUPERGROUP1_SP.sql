-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_SUPERGROUP1_SP
    @SuperGroup1Id   INT,
    @SuperGroup1Name VARCHAR(100),
    @Comment         VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        SUPERGROUP1ID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUPERGROUP1_NM,
        COMMENT_DSC
      FROM
        PRD_SUPERGROUP1 S (NOLOCK)
     WHERE
        S.SUPERGROUP1ID = @SuperGroup1Id;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_SUPERGROUP1
       SET
           SUPERGROUP1_NM = @SuperGroup1Name,
           COMMENT_DSC = @Comment
     WHERE SUPERGROUP1ID = @SuperGroup1Id;

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
