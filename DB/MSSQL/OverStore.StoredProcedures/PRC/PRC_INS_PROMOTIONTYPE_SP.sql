-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_PROMOTIONTYPE_SP
    @PromotionTypeId INT OUT,
    @PromotionName   VARCHAR(100),
    @Description     VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_PROMOTIONTYPE
    (
        PROMOTIONTYPE_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @PromotionName,
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
    SELECT @PromotionTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO PRC_PROMOTIONTYPELOG
    (
        PROMOTIONTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROMOTIONTYPE_NM,
        COMMENT_DSC
    )    
    VALUES
    (
        @PromotionTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PromotionName,
        @Description);
/*Section="End"*/
END;
