-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_PRODUCTTYPE_SP
    @ProductTypeId INT,
    @Name          VARCHAR(100),
    @ProductFamily INT,
    @Comment       VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_PRODUCTTYPE
    (
        PRODUCTTYPEID,
        PRODUCTTYPE_NM,
        FAMILY,
        COMMENT_DSC
    )
    VALUES
    (
        @ProductTypeId,
        @Name,
        @ProductFamily,
        @Comment
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO PRD_PRODUCTTYPELOG
    (
        PRODUCTTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PRODUCTTYPE_NM,
        FAMILY,
        COMMENT_DSC
    )
    VALUES
    (
        @ProductTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name,
        @ProductFamily,
        @Comment);
/*Section="End"*/
END;
