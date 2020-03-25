-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_FIRMTYPE_SP
    @FirmTypeId INT,
    @Name       VARCHAR(100)
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
        FIRMTYPE_NM
    )    
    SELECT
        FIRMTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        FIRMTYPE_NM
      FROM
        ACC_FIRMTYPE F (NOLOCK)
     WHERE
        F.FIRMTYPEID = @FirmTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_FIRMTYPE
       SET
           FIRMTYPE_NM = @Name
     WHERE FIRMTYPEID = @FirmTypeId;

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
