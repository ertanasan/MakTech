-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_EXCELFILE_SP
    @ExcelFileId INT
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
        NUMBEROFCOLUMNS_QTY    )    
    SELECT
        EXCELFILEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ACC_EXCELFILE
     WHERE EXCELFILEID = @ExcelFileId;

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
