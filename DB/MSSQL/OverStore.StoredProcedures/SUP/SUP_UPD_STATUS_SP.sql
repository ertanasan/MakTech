-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_UPD_STATUS_SP
    @StatusId    INT,
    @Name        VARCHAR(100),
    @Description VARCHAR(1000)
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
        COMMENT_DSC
    )    
    SELECT
        STATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STATUS_NM,
        COMMENT_DSC
      FROM
        SUP_STATUS S (NOLOCK)
     WHERE
        S.STATUSID = @StatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SUP_STATUS
       SET
           STATUS_NM = @Name,
           COMMENT_DSC = @Description
     WHERE STATUSID = @StatusId;

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
