-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_MATERIALINFO_SP
    @MaterialInfoId INT
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
        INFO_NM    )    
    SELECT
        MATERIALINFOID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_MATERIALINFO
     WHERE MATERIALINFOID = @MaterialInfoId;

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
