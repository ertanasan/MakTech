-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_COUNTINGTYPE_SP
    @CountingTypeId   INT,
    @CountingTypeName VARCHAR(100)
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
        COUNTINGTYPE_NM
    )    
    SELECT
        COUNTINGTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTINGTYPE_NM
      FROM
        WHS_COUNTINGTYPE C (NOLOCK)
     WHERE
        C.COUNTINGTYPEID = @CountingTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_COUNTINGTYPE
       SET
           COUNTINGTYPE_NM = @CountingTypeName
     WHERE COUNTINGTYPEID = @CountingTypeId;

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
