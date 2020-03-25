-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_DEL_PROMOTIONTYPE_SP
    @PromotionTypeId INT
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
        COMMENT_DSC    )    
    SELECT
        PROMOTIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROMOTIONTYPE_NM,
        COMMENT_DSC
      FROM
        PRC_PROMOTIONTYPE P (NOLOCK)
     WHERE
        P.PROMOTIONTYPEID = @PromotionTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRC_PROMOTIONTYPE
     WHERE PROMOTIONTYPEID = @PromotionTypeId;

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
