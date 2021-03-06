﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_CONSIGNMENTGOODPURCHASE_SP
    @ConsignmentGoodPurchaseId BIGINT OUT,
    @Event                     INT,
    @Organization              INT,
    @Store                     INT,
    @Product                   INT,
    @Supplier                  INT,
    @Quantity                  NUMERIC(9,2)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_CONSIGNMENTGOODPURCHASE
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
        PRODUCT,
        SUPPLIER,
        QUANTITY_QTY
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
        @Store,
        @Product,
        @Supplier,
        @Quantity
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
    SELECT @ConsignmentGoodPurchaseId = SCOPE_IDENTITY();
/*Section="End"*/
END;
