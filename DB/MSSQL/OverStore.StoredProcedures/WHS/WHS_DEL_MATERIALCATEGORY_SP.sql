-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_MATERIALCATEGORY_SP
    @MaterialCategoryId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_MATERIALCATEGORYLOG
    (
        MATERIALCATEGORYID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CATEGORY_NM    )    
    SELECT
        MATERIALCATEGORYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CATEGORY_NM
      FROM
        WHS_MATERIALCATEGORY M (NOLOCK)
     WHERE
        M.MATERIALCATEGORYID = @MaterialCategoryId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_MATERIALCATEGORY
     WHERE MATERIALCATEGORYID = @MaterialCategoryId;

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
