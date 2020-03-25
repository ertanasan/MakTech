-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_MATERIAL_SP
    @MaterialId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_MATERIALLOG
    (
        MATERIALID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        MATERIAL_NM,
        MIKRO_DSC,
        UNIT_CD,
        MATERIALCATEGORY    )    
    SELECT
        MATERIALID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        MATERIAL_NM,
        MIKRO_DSC,
        UNIT_CD,
        MATERIALCATEGORY
      FROM
        WHS_MATERIAL M (NOLOCK)
     WHERE
        M.MATERIALID = @MaterialId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_MATERIAL
     WHERE MATERIALID = @MaterialId;

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
