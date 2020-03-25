-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_MATERIALCATEGORY_SP
    @MaterialCategoryId INT,
    @CategoryName       VARCHAR(100)
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
        CATEGORY_NM
    )    
    SELECT
        MATERIALCATEGORYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CATEGORY_NM
      FROM
        WHS_MATERIALCATEGORY M (NOLOCK)
     WHERE
        M.MATERIALCATEGORYID = @MaterialCategoryId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_MATERIALCATEGORY
       SET
           CATEGORY_NM = @CategoryName
     WHERE MATERIALCATEGORYID = @MaterialCategoryId;

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
