-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_EXCELFILECOLUMNS_SP
    @ExcelFileColumnsId INT,
    @ExcelFile          INT,
    @ColumnName         VARCHAR(100),
    @ColumnIndex        INT,
    @ColumnType         INT,
    @ColumnFormat       VARCHAR(50)
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
        FORMAT_TXT
    )
    SELECT
        EXCELFILECOLUMNSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_EXCELFILECOLUMNS
       SET
           EXCELFILE = @ExcelFile,
           COLUMN_NM = @ColumnName,
           COLUMNINDEX_NO = @ColumnIndex,
           COLUMNTYPE_CD = @ColumnType,
           FORMAT_TXT = @ColumnFormat
     WHERE EXCELFILECOLUMNSID = @ExcelFileColumnsId;

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
