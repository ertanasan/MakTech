CREATE PROCEDURE WHS_UPD_GATHERINGDETAIL_SP
    @GatheringDetailId BIGINT,
    @Event             INT,
    @Organization      INT,
    @StoreOrderDetail  BIGINT,
    @GatheringTime     DATETIME = NULL,
    @Gathering         BIGINT,
    @GatheredQuantity  NUMERIC(12,6) = NULL,
    @PalletNo          INT,
	@ControlQuantity   NUMERIC(12,6),
    @ControlTime       DATETIME
AS
BEGIN
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    SET NOCOUNT OFF;
    UPDATE WHS_GATHERINGDETAIL
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STOREORDERDETAIL = @StoreOrderDetail,
           GATHERING_TM = CASE WHEN @ControlQuantity IS NULL AND @GatheredQuantity IS NOT NULL THEN GETDATE() ELSE GATHERING_TM END, -- @GatheringTime
           GATHERING = @Gathering,
           GATHERED_QTY = @GatheredQuantity,
           PALLET_NO = @PalletNo,
           CONTROL_QTY = @ControlQuantity,
           CONTROL_TM = CASE WHEN @ControlQuantity IS NOT NULL THEN GETDATE() ELSE CONTROL_TM END -- @ControlTime
     WHERE GATHERINGDETAILID = @GatheringDetailId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

END