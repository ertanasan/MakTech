-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_SCALEBRAND_SP
    @ScaleBrandId INT OUT,
    @Name         VARCHAR(100),
    @Description  VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_SCALEBRAND
    (
        BRAND_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @Name,
        @Description
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
    SELECT @ScaleBrandId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_SCALEBRANDLOG
    (
        SCALEBRANDID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BRAND_NM,
        COMMENT_DSC
    )    
    VALUES
    (
        @ScaleBrandId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name,
        @Description);
/*Section="End"*/
END;
