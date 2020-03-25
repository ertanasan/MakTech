-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_CASHREGISTERMODEL_SP
    @CashRegisterModelId INT OUT,
    @Brand               INT,
    @Name                VARCHAR(100),
    @Description         VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_CASHREGISTERMODEL
    (
        BRAND,
        MODEL_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @Brand,
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
    SELECT @CashRegisterModelId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_CASHREGISTERMODELLOG
    (
        CASHREGISTERMODELID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BRAND,
        MODEL_NM,
        COMMENT_DSC
    )    
    VALUES
    (
        @CashRegisterModelId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Brand,
        @Name,
        @Description);
/*Section="End"*/
END;
