-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_INTAKESTATUS_SP
    @IntakeStatusId     BIGINT,
    @Event              INT,
    @Organization       INT,
    @StoreOrderDetail   BIGINT,
    @IntakeStatusType   INT,
    @Description        VARCHAR(1000),
    @IsTransferred      VARCHAR(1),
    @MikroTransferTime  DATETIME,
    @QuantityDifference NUMERIC(10,2)
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
    UPDATE WHS_INTAKESTATUS
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STOREORDERDETAIL = @StoreOrderDetail,
           INTAKESTATUSTYPE = @IntakeStatusType,
           DESCRIPTION_DSC = @Description,
           MIKROTRANSFER_FL = @IsTransferred,
           MIKROTRANSFER_TM = @MikroTransferTime,
           QUANTITYDIF_QTY = @QuantityDifference
     WHERE INTAKESTATUSID = @IntakeStatusId
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
