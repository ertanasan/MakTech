-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_STORE_SP
    @StoreId            INT,
    @Name               VARCHAR(100),
    @OrganizationBranch INT,
    @IpAddress          VARCHAR(1000),
    @Advance            NUMERIC(22,6),
    @OpeningDate        DATETIME,
    @ClosingDate        DATETIME,
    @ActiveFlag         VARCHAR(1),
    @ProductionFlag     VARCHAR(1),
    @City               INT,
    @Town               INT,
    @Address            VARCHAR(1000),
    @RegionManager      INT,
    @InConstruction     VARCHAR(1)
AS
BEGIN

    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

	IF NOT EXISTS (SELECT * FROM STR_TERMINAL WHERE STORE = @StoreId) 
	BEGIN
		DECLARE @TerminalName VARCHAR(100)
		SELECT @TerminalName = dbo.SYS_CONVERTLATIN_FN (UPPER(@Name), 1)
		EXEC STR_INS_TERMINAL_SP @TerminalName, @StoreId
	END

    SET NOCOUNT OFF;
    UPDATE STR_STORE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE_NM = @Name,
           BRANCH = @OrganizationBranch,
           IPADDRESS_TXT = @IpAddress,
           ADVANCE_AMT = @Advance,
           OPENING_DT = CAST(@OpeningDate AS DATE),
           CLOSING_DT = CAST(@ClosingDate AS DATE),
           ACTIVE_FL = @ActiveFlag,
           PRODUCTION_FL = @ProductionFlag,
           CITY = @City,
           TOWN = @Town,
           ADDRESS_TXT = @Address,
           REGIONMANAGER = @RegionManager,
           INCONSTRUCTION_FL = @InConstruction
     WHERE STOREID = @StoreId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
