CREATE PROCEDURE STR_INS_STORE_SP
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

    SELECT @StoreId = MAX(STOREID) + 1 FROM STR_STORE WHERE STOREID != 1000

    SET NOCOUNT OFF
    INSERT INTO STR_STORE
    (
        STOREID,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        STORE_NM,
        BRANCH,
        IPADDRESS_TXT,
        ADVANCE_AMT,
        OPENING_DT,
        CLOSING_DT,
        ACTIVE_FL,
        PRODUCTION_FL,
        CITY,
        TOWN,
        ADDRESS_TXT,
        REGIONMANAGER,
        INCONSTRUCTION_FL
    )
    VALUES
    (
        @StoreId,
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Name,
        @OrganizationBranch,
        @IpAddress,
        @Advance,
        @OpeningDate,
        @ClosingDate,
        @ActiveFlag,
        @ProductionFlag,
        @City,
        @Town,
        @Address,
        @RegionManager,
        @InConstruction
    );

	IF NOT EXISTS (SELECT * FROM STR_TERMINAL WHERE STORE = @StoreId) 
	BEGIN
		DECLARE @TerminalName VARCHAR(100)
		SELECT @TerminalName = dbo.SYS_CONVERTLATIN_FN (UPPER(@Name), 1)
		EXEC STR_INS_TERMINAL_SP @TerminalName, @StoreId
	END

	DECLARE @ShipmentScheduleId INT;
	EXEC WHS_INS_SHIPMENTSCHEDULE_SP @ShipmentScheduleId, @Name, @StoreId, '0-0-0-0-0-0-0', NULL

    SET NOCOUNT ON;
END;