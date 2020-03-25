
-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_INS_DOCUMENTDOWNLOADLOG_SP
    @Document            BIGINT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO OSM_DOCUMENTDOWNLOADLOG
    (
        ORGANIZATION,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        DOCUMENT
    )
    VALUES
    (
        1,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Document
    );
/*Section="End"*/
END;
GO