-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_MATERIALINFO_SP
    @MaterialInfoId INT,
    @Material       INT,
    @ShortName      VARCHAR(100),
    @InfoName       VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_MATERIALINFOLOG
    (
        MATERIALINFOID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        MATERIAL,
        INFOSHORT_NM,
        INFO_NM
    )    
    SELECT
        MATERIALINFOID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        MATERIAL,
        INFOSHORT_NM,
        INFO_NM
      FROM
        WHS_MATERIALINFO M (NOLOCK)
     WHERE
        M.MATERIALINFOID = @MaterialInfoId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_MATERIALINFO
       SET
           MATERIAL = @Material,
           INFOSHORT_NM = @ShortName,
           INFO_NM = @InfoName
     WHERE MATERIALINFOID = @MaterialInfoId;

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
