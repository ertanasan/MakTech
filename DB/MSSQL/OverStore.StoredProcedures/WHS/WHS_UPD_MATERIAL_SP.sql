-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_MATERIAL_SP
    @MaterialId   INT,
    @MaterialName VARCHAR(100),
    @MikroCode    VARCHAR(100),
    @UnitCode     INT,
    @Category     INT
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
        MATERIALCATEGORY
    )    
    SELECT
        MATERIALID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_MATERIAL
       SET
           MATERIAL_NM = @MaterialName,
           MIKRO_DSC = @MikroCode,
           UNIT_CD = @UnitCode,
           MATERIALCATEGORY = @Category
     WHERE MATERIALID = @MaterialId;

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
