-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_ADJUSTMENT_SP
    @AdjustmentId BIGINT OUT,
    @Event        INT,
    @Organization INT,
    @Store        INT,
    @Amount       NUMERIC(22,6),
    @Description  VARCHAR(1000),
    @Date         DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_ADJUSTMENT
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STORE,
        AMOUNT_AMT,
        DESCRIPTION_DSC,
        DATE_DT
    )
    VALUES
    (
        1, --@Event,
        1, -- @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Store,
        @Amount,
        @Description,
        @Date
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
    SELECT @AdjustmentId = SCOPE_IDENTITY();
/*Section="End"*/
END;
