-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_UPD_PROMOTIONTYPE_SP
    @PromotionTypeId INT,
    @PromotionName   VARCHAR(100),
    @Description     VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        PROMOTIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROMOTIONTYPE_NM,
        COMMENT_DSC
      FROM
        PRC_PROMOTIONTYPE P (NOLOCK)
     WHERE
        P.PROMOTIONTYPEID = @PromotionTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRC_PROMOTIONTYPE
       SET
           PROMOTIONTYPE_NM = @PromotionName,
           COMMENT_DSC = @Description
     WHERE PROMOTIONTYPEID = @PromotionTypeId;

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
