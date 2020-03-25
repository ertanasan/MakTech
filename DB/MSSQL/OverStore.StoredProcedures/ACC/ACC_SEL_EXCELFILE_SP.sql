-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_EXCELFILE_SP
    @ExcelFileId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           E.EXCELFILEID,
           E.TRANSFER_NM,
           E.SHEET_NO,
           E.ROWSTART_NO,
           E.COLUMNSTART_NO,
           E.NUMBEROFCOLUMNS_QTY      
      FROM ACC_EXCELFILE E (NOLOCK)
     WHERE E.EXCELFILEID = @ExcelFileId;

    /*Section="End"*/
END;
