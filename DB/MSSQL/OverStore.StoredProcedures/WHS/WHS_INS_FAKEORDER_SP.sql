-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_FAKEORDER_SP
    @FakeOrderId  BIGINT OUT,
    @Event        INT,
    @Organization INT,
    @OrderDate    DATETIME,
    @Store        INT,
    @Product      INT,
    @SentAmount   NUMERIC(10,3)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_FAKEORDER
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        ORDER_DT,
        STORE,
        PRODUCT,
        SENT_AMT
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
        @OrderDate,
        @Store,
        @Product,
        @SentAmount
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
    SELECT @FakeOrderId = SCOPE_IDENTITY();
/*Section="End"*/
END;
