-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_PRODUCTRETURN_SP
    @ProductReturnId   BIGINT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_PRODUCTRETURN
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        RETURN_DT,
        WAYBILL_DT,
        PRODUCT,
        SUPPLIER_TXT,
        MANUFACTURING_DT,
        EXPIRE_DT,
        RETURNQUANTITY_AMT,
        PACKAGETYPE,
        RETURNREASON_TXT,
        RETURNDESTINATION,
        STATUS_CD,
        PROCESSINSTANCE_LNO,
        STORE,
        INTAKE_AMT,
        CUSTOMERRETURN_FL,
        REUSABLE_FL,
        SALEDETAIL,
		WAYBILL_TXT
    )
    VALUES
    (
        1,
        1,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CAST(@ReturnDate AS DATE),
        CAST(@WaybillDate AS DATE),
        @Product,
        @Supplier,
        CAST(@ManufacturingDate AS DATE),
        CAST(@ExpireDate AS DATE),
        @ReturnQuantity,
        @PackageType,
        @ReturnReasonText,
        @ReturnDestination,
        @StatusCode,
        @ProcessInstance,
        @Store,
        @IntakeAmount,
        @IsCustomerReturn,
        @ReusableFlag,
        @SaleDetailId,
		@WaybillText
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
    SELECT @ProductReturnId = SCOPE_IDENTITY();
/*Section="End"*/
END;
