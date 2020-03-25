-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_MATERIALORDERDETAIL_SP
    @MaterialOrderDetailId BIGINT,
    @Event                 INT,
    @Organization          INT,
    @MaterialOrder         BIGINT,
    @Material              INT,
    @OrderQuantity         NUMERIC(22,6),
    @RevisedQuantity       NUMERIC(22,6),
    @ShippedQuantity       NUMERIC(22,6),
    @IntakeQuantity        NUMERIC(22,6),
    @Note                  VARCHAR(1000)
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
    UPDATE WHS_MATERIALORDERDETAIL
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           MATERIALORDER = @MaterialOrder,
           MATERIAL = @Material,
           ORDER_AMT = @OrderQuantity,
           REVISED_AMT = @RevisedQuantity,
           SHIPPED_AMT = @ShippedQuantity,
           INTAKE_AMT = @IntakeQuantity,
           NOTE_TXT = @Note
     WHERE MATERIALORDERDETAILID = @MaterialOrderDetailId     
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
