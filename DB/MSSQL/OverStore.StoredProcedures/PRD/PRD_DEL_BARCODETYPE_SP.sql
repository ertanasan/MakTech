﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_BARCODETYPE_SP
    @BarcodeTypeId INT
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
        COMMENT_DSC    )    
    SELECT
        BARCODETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BARCODETYPE_NM,
        COMMENT_DSC
      FROM
        PRD_BARCODETYPE B (NOLOCK)
     WHERE
        B.BARCODETYPEID = @BarcodeTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_BARCODETYPE
     WHERE BARCODETYPEID = @BarcodeTypeId;

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
