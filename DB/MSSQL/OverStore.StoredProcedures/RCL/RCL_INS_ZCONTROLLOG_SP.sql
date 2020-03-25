CREATE PROCEDURE RCL_INS_ZCONTROLLOG_SP
    @ZControlLogId		   BIGINT OUT,
    @Store                 INT,
    @ReconciliationDate    DATETIME,
    @ZetAmount             NUMERIC(22,6)
AS
BEGIN

    INSERT INTO RCL_ZCONTROLLOG
    (CREATE_DT, CREATEUSER, STORE, RECONCILIATION_DT, ZET_AMT)
    VALUES
    (GETDATE(), dbo.SYS_GETCURRENTUSER_FN(), @Store, CAST(@ReconciliationDate AS DATE), @ZetAmount);

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @ZControlLogId = SCOPE_IDENTITY();

END;