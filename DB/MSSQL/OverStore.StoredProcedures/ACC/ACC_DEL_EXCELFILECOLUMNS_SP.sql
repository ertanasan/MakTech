-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_EXCELFILECOLUMNS_SP
    @ExcelFileColumnsId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_EXCELFILECOLUMNSLOG
    (
        EXCELFILECOLUMNSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        EXCELFILE,
        COLUMN_NM,
        COLUMNINDEX_NO,
        COLUMNTYPE_CD,
        FORMAT_TXT    )
    SELECT
        EXCELFILECOLUMNSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EXCELFILE,
        COLUMN_NM,
        COLUMNINDEX_NO,
        COLUMNTYPE_CD,
        FORMAT_TXT
      FROM
        ACC_EXCELFILECOLUMNS E (NOLOCK)
     WHERE
        E.EXCELFILECOLUMNSID = @ExcelFileColumnsId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ACC_EXCELFILECOLUMNS
     WHERE EXCELFILECOLUMNSID = @ExcelFileColumnsId;

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
