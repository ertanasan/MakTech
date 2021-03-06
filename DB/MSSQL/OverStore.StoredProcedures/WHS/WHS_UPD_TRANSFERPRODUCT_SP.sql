﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_TRANSFERPRODUCT_SP
    @TransferProductId BIGINT,
    @Event             INT,
    @Organization      INT,
    @SourceStore       INT,
    @DestinationStore  INT,
    @ProcessInstance   BIGINT,
    @TransferStatus    INT,
    @WaybillNo         VARCHAR(50),
    @TargetWarehouse   INT = NULL
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
    UPDATE WHS_TRANSFERPRODUCT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SOURCESTORE = @SourceStore,
           DESTINATIONSTORE = @DestinationStore,
           PROCESSINSTANCE_LNO = @ProcessInstance,
           TRANSFERSTATUS = @TransferStatus,
           WAYBILL_TXT = @WaybillNo,
           RETURNDESTINATION = @TargetWarehouse
     WHERE TRANSFERPRODUCTID = @TransferProductId
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
