-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_PRODUCTRETURN_SP
    @ProductReturnId   BIGINT,
    @Event             INT,
    @Organization      INT,
    @ReturnDate        DATETIME,
    @WaybillDate       DATETIME,
    @Product           INT,
    @Supplier          VARCHAR(100),
    @ManufacturingDate DATETIME,
    @ExpireDate        DATETIME,
    @ReturnQuantity    NUMERIC(10,3),
    @PackageType       INT,
    @ReturnReasonText  VARCHAR(1000),
    @ReturnDestination INT,
    @StatusCode        INT,
    @ProcessInstance   BIGINT,
    @Store             INT,
    @IntakeAmount      NUMERIC(22,6),
    @IsCustomerReturn  VARCHAR(1),
    @ReusableFlag      VARCHAR(1),
    @SaleDetailId      BIGINT,
	@WaybillText	   VARCHAR(100)
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
    UPDATE WHS_PRODUCTRETURN
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           RETURN_DT = CAST(@ReturnDate AS DATE),
           WAYBILL_DT = CAST(@WaybillDate AS DATE),
           PRODUCT = @Product,
           SUPPLIER_TXT = @Supplier,
           MANUFACTURING_DT = CAST(@ManufacturingDate AS DATE),
           EXPIRE_DT = CAST(@ExpireDate AS DATE),
           RETURNQUANTITY_AMT = @ReturnQuantity,
           PACKAGETYPE = @PackageType,
           RETURNREASON_TXT = @ReturnReasonText,
           RETURNDESTINATION = @ReturnDestination,
           STATUS_CD = @StatusCode,
           PROCESSINSTANCE_LNO = @ProcessInstance,
           STORE = @Store,
           INTAKE_AMT = @IntakeAmount,
           CUSTOMERRETURN_FL = @IsCustomerReturn,
           REUSABLE_FL = @ReusableFlag,
           SALEDETAIL = @SaleDetailId,
		   WAYBILL_TXT = @WaybillText
     WHERE PRODUCTRETURNID = @ProductReturnId
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
