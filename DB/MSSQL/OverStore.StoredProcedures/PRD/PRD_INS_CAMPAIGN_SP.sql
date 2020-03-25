-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_CAMPAIGN_SP
    @ProductCampaignId INT,
    @Name              VARCHAR(100),
    @ImagePath         VARCHAR(200),
    @Active            VARCHAR(1),
    @Comment           VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_CAMPAIGN
    (
        CAMPAIGNID,
        NAME_NM,
        IMAGEPATH_TXT,
        ACTIVE_FL,
        COMMENT_DSC
    )
    VALUES
    (
        @ProductCampaignId,
        @Name,
        @ImagePath,
        @Active,
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
    INSERT INTO PRD_CAMPAIGNLOG
    (
        CAMPAIGNID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        NAME_NM,
        IMAGEPATH_TXT,
        ACTIVE_FL,
        COMMENT_DSC
    )    
    VALUES
    (
        @ProductCampaignId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name,
        @ImagePath,
        @Active,
        @Comment);
/*Section="End"*/
END;
