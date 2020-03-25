-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_UNIT_SP
    @UnitId  INT,
    @Name    VARCHAR(100),
    @Comment VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_UNITLOG
    (
        UNITID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        UNIT_NM,
        COMMENT_DSC
    )
    SELECT
        UNITID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        UNIT_NM,
        COMMENT_DSC
      FROM
        PRD_UNIT U (NOLOCK)
     WHERE
        U.UNITID = @UnitId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_UNIT
       SET
           UNIT_NM = @Name,
           COMMENT_DSC = @Comment
     WHERE UNITID = @UnitId;

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
