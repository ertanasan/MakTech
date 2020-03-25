-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_EXCELFILE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           E.EXCELFILEID,
           E.TRANSFER_NM,
           E.SHEET_NO,
           E.ROWSTART_NO,
           E.COLUMNSTART_NO,
           E.NUMBEROFCOLUMNS_QTY
      FROM ACC_EXCELFILE E (NOLOCK)
     ORDER BY TRANSFER_NM;

/*Section="End"*/
END;
