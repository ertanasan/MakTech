-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_FIXTURE_SP
    @StoreFixtureId     INT OUT,
    @ProductFixture     INT,
    @PurchaseDate       DATETIME,
    @SerialNo           VARCHAR(100),
    @EndOfGuaranteeDate DATETIME,
    @Supplier           INT,
    @Store              INT,
    @FixtureName        VARCHAR(100),
    @Brand              INT,
    @Model              INT,
    @Quantity           INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_FIXTURE
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        FIXTURE,
        PURCHASE_DT,
        SERIALNO_TXT,
        ENDOFGUARANTEE_DT,
        SUPPLIER,
        STORE,
        STOREFIXTURE_NM,
        BRAND,
        MODEL,
        QUANTITY_QTY
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @ProductFixture,
        @PurchaseDate,
        @SerialNo,
        @EndOfGuaranteeDate,
        @Supplier,
        @Store,
        ISNULL(@FixtureName,'.'),
        @Brand,
        @Model,
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
    SELECT @StoreFixtureId = SCOPE_IDENTITY();
/*Section="End"*/
END;