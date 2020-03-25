-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_FIRMTYPE_SP
    @FirmTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_FIRMTYPELOG
    (
        FIRMTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIRMTYPE_NM    )    
    SELECT
        FIRMTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIRMTYPE_NM
      FROM
        ACC_FIRMTYPE F (NOLOCK)
     WHERE
        F.FIRMTYPEID = @FirmTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ACC_FIRMTYPE
     WHERE FIRMTYPEID = @FirmTypeId;

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
