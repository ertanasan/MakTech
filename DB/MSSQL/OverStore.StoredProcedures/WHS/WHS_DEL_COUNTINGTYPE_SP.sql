-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_COUNTINGTYPE_SP
    @CountingTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_COUNTINGTYPELOG
    (
        COUNTINGTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTINGTYPE_NM    )    
    SELECT
        COUNTINGTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTINGTYPE_NM
      FROM
        WHS_COUNTINGTYPE C (NOLOCK)
     WHERE
        C.COUNTINGTYPEID = @CountingTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_COUNTINGTYPE
     WHERE COUNTINGTYPEID = @CountingTypeId;

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
