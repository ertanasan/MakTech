-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_CASHREGISTERBRAND_SP
    @CashRegisterBrandId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_CASHREGISTERBRANDLOG
    (
        CASHREGISTERBRANDID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BRAND_NM,
        COMMENT_DSC    )    
    SELECT
        CASHREGISTERBRANDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BRAND_NM,
        COMMENT_DSC
      FROM
        STR_CASHREGISTERBRAND C (NOLOCK)
     WHERE
        C.CASHREGISTERBRANDID = @CashRegisterBrandId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_CASHREGISTERBRAND
     WHERE CASHREGISTERBRANDID = @CashRegisterBrandId;

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
