-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_MATERIAL_SP
    @MaterialId   INT OUT,
    @MaterialName VARCHAR(100),
    @MikroCode    VARCHAR(100),
    @UnitCode     INT,
    @Category     INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_MATERIAL
    (
        MATERIAL_NM,
        MIKRO_DSC,
        UNIT_CD,
        MATERIALCATEGORY
    )
    VALUES
    (
        @MaterialName,
        @MikroCode,
        @UnitCode,
        @Category
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @MaterialId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @MaterialId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @MaterialName,
        @MikroCode,
        @UnitCode,
        @Category);
/*Section="End"*/
END;
