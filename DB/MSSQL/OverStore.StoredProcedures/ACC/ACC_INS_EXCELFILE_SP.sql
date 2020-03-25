-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_EXCELFILE_SP
    @ExcelFileId     INT OUT,
    @TransferName    VARCHAR(100),
    @SheetNo         INT,
    @RowStartNo      INT,
    @ColumnStartNo   INT,
    @NumberOfColumns INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_EXCELFILE
    (
        TRANSFER_NM,
        SHEET_NO,
        ROWSTART_NO,
        COLUMNSTART_NO,
        NUMBEROFCOLUMNS_QTY
    )
    VALUES
    (
        @TransferName,
        @SheetNo,
        @RowStartNo,
        @ColumnStartNo,
        @NumberOfColumns
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
    SELECT @ExcelFileId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @ExcelFileId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @TransferName,
        @SheetNo,
        @RowStartNo,
        @ColumnStartNo,
        @NumberOfColumns);
/*Section="End"*/
END;
