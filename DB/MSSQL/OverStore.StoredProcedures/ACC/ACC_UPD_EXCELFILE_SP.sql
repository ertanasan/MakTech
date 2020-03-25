-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_EXCELFILE_SP
    @ExcelFileId     INT,
    @TransferName    VARCHAR(100),
    @SheetNo         INT,
    @RowStartNo      INT,
    @ColumnStartNo   INT,
    @NumberOfColumns INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_EXCELFILELOG
    (
        EXCELFILEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        TRANSFER_NM,
        SHEET_NO,
        ROWSTART_NO,
        COLUMNSTART_NO,
        NUMBEROFCOLUMNS_QTY
    )    
    SELECT
        EXCELFILEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TRANSFER_NM,
        SHEET_NO,
        ROWSTART_NO,
        COLUMNSTART_NO,
        NUMBEROFCOLUMNS_QTY
      FROM
        ACC_EXCELFILE E (NOLOCK)
     WHERE
        E.EXCELFILEID = @ExcelFileId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_EXCELFILE
       SET
           TRANSFER_NM = @TransferName,
           SHEET_NO = @SheetNo,
           ROWSTART_NO = @RowStartNo,
           COLUMNSTART_NO = @ColumnStartNo,
           NUMBEROFCOLUMNS_QTY = @NumberOfColumns
     WHERE EXCELFILEID = @ExcelFileId;

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
