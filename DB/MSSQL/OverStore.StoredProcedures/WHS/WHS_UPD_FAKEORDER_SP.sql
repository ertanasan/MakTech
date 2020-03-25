-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_FAKEORDER_SP
    @FakeOrderId  BIGINT,
    @Event        INT,
    @Organization INT,
    @OrderDate    DATETIME,
    @Store        INT,
    @Product      INT,
    @SentAmount   NUMERIC(10,3)
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
    UPDATE WHS_FAKEORDER
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           ORDER_DT = @OrderDate,
           STORE = @Store,
           PRODUCT = @Product,
           SENT_AMT = @SentAmount
     WHERE FAKEORDERID = @FakeOrderId     
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
