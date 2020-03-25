-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_BARCODETYPEINT_SP
    @BarcodeTypeID INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_BARCODETYPEINTLOG
    (
        BARCODETYPEINTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BARCODETYPE_NM,
        COMMENT_DSC    )
    SELECT
        BARCODETYPEINTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BARCODETYPE_NM,
        COMMENT_DSC
      FROM
        PRD_BARCODETYPEINT B (NOLOCK)
     WHERE
        B.BARCODETYPEINTID = @BarcodeTypeID;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_BARCODETYPEINT
     WHERE BARCODETYPEINTID = @BarcodeTypeID;

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
