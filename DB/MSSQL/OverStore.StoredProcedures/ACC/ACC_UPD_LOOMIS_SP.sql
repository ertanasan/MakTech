-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_LOOMIS_SP
    @LoomisId             BIGINT,
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
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_LOOMIS
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SALE_DT = CAST(@SaleDate AS DATE),
           STORE = @Store,
           SEAL_TXT = @SealNo,
           DECLARED_AMT = @DeclaredAmount,
           ACTUAL_AMT = @ActualAmount,
           FAKE_AMT = @FakeAmount,
           EXPLANATION_TXT = @Explanation,
           MIKRO_TM = @MikroTime,
           MIKROSTATUS_CD = @MikroStatusCode,
           MIKROTRANCODE_TXT = @MikroTransactionCode,
           LOOMIS_DT = CAST(@LoomisDate AS DATE)
     WHERE LOOMISID = @LoomisId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
