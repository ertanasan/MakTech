-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_EXCELFILECOLUMNS_SP
    @ExcelFileColumnsId INT OUT,
    @ExcelFile          INT,
    @ColumnName         VARCHAR(100),
    @ColumnIndex        INT,
    @ColumnType         INT,
    @ColumnFormat       VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_EXCELFILECOLUMNS
    (
        EXCELFILE,
        COLUMN_NM,
        COLUMNINDEX_NO,
        COLUMNTYPE_CD,
        FORMAT_TXT
    )
    VALUES
    (
        @ExcelFile,
        @ColumnName,
        @ColumnIndex,
        @ColumnType,
        @ColumnFormat
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
    SELECT @ExcelFileColumnsId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @ExcelFileColumnsId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ExcelFile,
        @ColumnName,
        @ColumnIndex,
        @ColumnType,
        @ColumnFormat);
/*Section="End"*/
END;
