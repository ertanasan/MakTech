-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_CASHREGISTERBRAND_SP
    @CashRegisterBrandId INT OUT,
    @Name                VARCHAR(100),
    @Description         VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_CASHREGISTERBRAND
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
    SELECT @CashRegisterBrandId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
        COMMENT_DSC
    )    
    VALUES
    (
        @CashRegisterBrandId,
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
