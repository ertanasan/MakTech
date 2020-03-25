-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_BARCODETYPE_SP
    @BarcodeTypeId INT,
    @BarcodeType   VARCHAR(100),
    @Comment       VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_BARCODETYPELOG
    (
        BARCODETYPEID,
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
        BARCODETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BARCODETYPE_NM,
        COMMENT_DSC
      FROM
        PRD_BARCODETYPE B (NOLOCK)
     WHERE
        B.BARCODETYPEID = @BarcodeTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_BARCODETYPE
       SET
           BARCODETYPE_NM = @BarcodeType,
           COMMENT_DSC = @Comment
     WHERE BARCODETYPEID = @BarcodeTypeId;

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
