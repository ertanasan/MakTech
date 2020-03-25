-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_STOREORDER_SP
    @StoreOrderId BIGINT,
    @Event        INT,
    @Organization INT,
    @Store        INT,
    @OrderCode    VARCHAR(100),
    @Status       INT,
    @OrderDate    DATETIME,
    @ShipmentDate DATETIME
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

	DECLARE @StatusChanged INT;
	SELECT @StatusChanged = COUNT(*)
	  FROM WHS_STOREORDER
	 WHERE STOREORDERID = @StoreOrderId
	   AND STATUS != @Status;

	IF @StatusChanged > 0 
	BEGIN
		INSERT INTO WHS_STOREORDERHISTORY
		(
			EVENT,
			ORGANIZATION,
			DELETED_FL,
			CREATE_DT,
			CREATEUSER,
			CREATECHANNEL,
			CREATEBRANCH,
			CREATESCREEN,
			STOREORDER,
			HISTORY_TM,
			STATUS
		)
		VALUES
		(
			@Event,
			3,
			'N',
			GETDATE(),
			dbo.SYS_GETCURRENTUSER_FN(),
			dbo.SYS_GETCURRENTCHANNEL_FN(),
			dbo.SYS_GETCURRENTBRANCH_FN(),
			dbo.SYS_GETCURRENTSCREEN_FN(),
			@StoreOrderId,
			GETDATE(),
			@Status
		);	
	END;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_STOREORDER
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           ORDERCODE_NM = @OrderCode,
           STATUS = @Status,
           ORDER_DT = CAST(@OrderDate AS DATE),
           SHIPMENT_DT = CAST(@ShipmentDate AS DATE)
     WHERE STOREORDERID = @StoreOrderId     
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
