-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_LOOMIS_SP
    @LoomisId             BIGINT OUT,
    @Event                INT,
    @Organization         INT,
    @SaleDate             DATETIME,
    @Store                INT,
    @SealNo               VARCHAR(100),
    @DeclaredAmount       NUMERIC(22,6),
    @ActualAmount         NUMERIC(22,6),
    @FakeAmount           NUMERIC(22,6),
    @Explanation          VARCHAR(1000),
    @MikroTime            DATETIME,
    @MikroStatusCode      INT,
    @MikroTransactionCode VARCHAR(100),
    @LoomisDate           DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_LOOMIS
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        SALE_DT,
        STORE,
        SEAL_TXT,
        DECLARED_AMT,
        ACTUAL_AMT,
        FAKE_AMT,
        EXPLANATION_TXT,
        MIKRO_TM,
        MIKROSTATUS_CD,
        MIKROTRANCODE_TXT,
        LOOMIS_DT
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CAST(@SaleDate AS DATE),
        @Store,
        @SealNo,
        @DeclaredAmount,
        @ActualAmount,
        @FakeAmount,
        @Explanation,
        @MikroTime,
        @MikroStatusCode,
        @MikroTransactionCode,
        CAST(@LoomisDate AS DATE)
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
    SELECT @LoomisId = SCOPE_IDENTITY();
/*Section="End"*/
END;
