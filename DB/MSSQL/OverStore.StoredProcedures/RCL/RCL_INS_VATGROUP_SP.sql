-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_VATGROUP_SP
    @VatGroupId INT OUT,
    @VatRate    NUMERIC(4,2)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_VATGROUP
    (
        VAT_RT
    )
    VALUES
    (
        @VatRate
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
    SELECT @VatGroupId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO RCL_VATGROUPLOG
    (
        VATGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        VAT_RT
    )    
    VALUES
    (
        @VatGroupId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @VatRate);
/*Section="End"*/
END;
