-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_EXCELFILECOLUMNS_SP
    @ExcelFile INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           E.EXCELFILECOLUMNSID,
           E.EXCELFILE,
           E.COLUMN_NM,
           E.COLUMNINDEX_NO,
           E.COLUMNTYPE_CD,
           E.FORMAT_TXT
      FROM ACC_EXCELFILECOLUMNS E (NOLOCK)
     WHERE (@ExcelFile IS NULL OR E.EXCELFILE = @ExcelFile)
     ORDER BY COLUMNINDEX_NO;

/*Section="End"*/
END;
