-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_BARCODETYPEINT_SP
    @BarcodeTypeID INT,
    @BarcodeType   VARCHAR(100),
    @Comment       VARCHAR(1000)
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
        COMMENT_DSC
    )
    SELECT
        BARCODETYPEINTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BARCODETYPE_NM,
        COMMENT_DSC
      FROM
        PRD_BARCODETYPEINT B (NOLOCK)
     WHERE
        B.BARCODETYPEINTID = @BarcodeTypeID;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_BARCODETYPEINT
       SET
           BARCODETYPE_NM = @BarcodeType,
           COMMENT_DSC = @Comment
     WHERE BARCODETYPEINTID = @BarcodeTypeID;

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
