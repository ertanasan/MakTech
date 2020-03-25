-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_DRILLPRODUCT_SP
    @DrillProductId INT OUT,
    @CountingDate   DATETIME,
    @Product        INT,
    @Store          INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_DRILLPRODUCT
    (
        COUNTING_DT,
        PRODUCT,
        STORE
    )
    VALUES
    (
        CAST(@CountingDate AS DATE),
        @Product,
        @Store
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
    SELECT @DrillProductId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_DRILLPRODUCTLOG
    (
        DRILLPRODUCTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTING_DT,
        PRODUCT,
        STORE
    )
    VALUES
    (
        @DrillProductId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CAST(@CountingDate AS DATE),
        @Product,
        @Store);
/*Section="End"*/
END;
