-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_UNIT_SP
    @UnitId INT
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
        COMMENT_DSC    )    
    SELECT
        UNITID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        UNIT_NM,
        COMMENT_DSC
      FROM
        PRD_UNIT U (NOLOCK)
     WHERE
        U.UNITID = @UnitId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_UNIT
     WHERE UNITID = @UnitId;

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
