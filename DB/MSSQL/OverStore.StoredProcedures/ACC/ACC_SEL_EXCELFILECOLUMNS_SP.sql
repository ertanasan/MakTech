-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_EXCELFILECOLUMNS_SP
    @ExcelFileColumnsId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           E.EXCELFILECOLUMNSID,
           E.EXCELFILE,
           E.COLUMN_NM,
           E.COLUMNINDEX_NO,
           E.COLUMNTYPE_CD,
           E.FORMAT_TXT
      FROM ACC_EXCELFILECOLUMNS E (NOLOCK)
     WHERE E.EXCELFILECOLUMNSID = @ExcelFileColumnsId;

    /*Section="End"*/
END;
