-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_FIXTURE_SP
    @StoreFixtureId     INT,
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
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_FIXTURE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           FIXTURE = @ProductFixture,
           PURCHASE_DT = @PurchaseDate,
           SERIALNO_TXT = @SerialNo,
           ENDOFGUARANTEE_DT = @EndOfGuaranteeDate,
           SUPPLIER = @Supplier,
           STORE = @Store,
           STOREFIXTURE_NM = @FixtureName,
           BRAND = @Brand,
           MODEL = @Model,
           QUANTITY_QTY = @Quantity
     WHERE FIXTUREID = @StoreFixtureId
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
