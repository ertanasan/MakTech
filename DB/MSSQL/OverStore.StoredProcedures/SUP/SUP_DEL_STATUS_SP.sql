-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_DEL_STATUS_SP
    @StatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO SUP_STATUSLOG
    (
        STATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STATUS_NM,
        COMMENT_DSC    )    
    SELECT
        STATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM,
        COMMENT_DSC
      FROM
        SUP_STATUS S (NOLOCK)
     WHERE
        S.STATUSID = @StatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM SUP_STATUS
     WHERE STATUSID = @StatusId;

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
