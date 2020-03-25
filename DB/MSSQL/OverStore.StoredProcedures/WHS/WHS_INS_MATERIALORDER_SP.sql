CREATE PROCEDURE WHS_INS_MATERIALORDER_SP
    @MaterialOrderId       BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @OrderName             VARCHAR(100),
    @OrderDate             DATETIME,
    @OrderStatusCode       INT,
    @Store                 INT,
    @ProcessInstanceNumber BIGINT,
    @MikroStatusCode       INT,
    @MikroReference        VARCHAR(100),
    @MikroTime             DATETIME,
    @MikroUser             INT,
    @Material              INT,
    @MaterialInfo          INT,
    @OrderQuantity         NUMERIC(10,3),
    @RevisedQuantity       NUMERIC(10,3),
    @ShippedQuantity       NUMERIC(10,3),
    @IntakeQuantity        NUMERIC(10,3),
    @Note                  VARCHAR(1000)
AS
BEGIN
    SET NOCOUNT OFF
    INSERT INTO WHS_MATERIALORDER
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        ORDER_NM,
        ORDER_DT,
        ORDERSTATUS_CD,
        STORE,
        PROCESSINSTANCE_LNO,
        MIKROSTATUS_CD,
        MIKROREF_TXT,
        MIKRO_TM,
        MIKROUSER,
        MATERIAL,
        MATERIALINFO,
        ORDER_AMT,
        REVISED_AMT,
        SHIPPED_AMT,
        INTAKE_AMT,
        NOTE_TXT
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @OrderName,
        CAST(GETDATE() AS DATE),
        @OrderStatusCode,
        @Store,
        @ProcessInstanceNumber,
        @MikroStatusCode,
        @MikroReference,
        @MikroTime,
        @MikroUser,
        @Material,
        @MaterialInfo,
        @OrderQuantity,
        @RevisedQuantity,
        @ShippedQuantity,
        @IntakeQuantity,
        @Note
    );

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @MaterialOrderId = SCOPE_IDENTITY();

    UPDATE MO SET ORDER_NM = STORE_NM + '-' + MATERIAL_NM + '-' + CAST(@MaterialOrderId AS VARCHAR(20)) 
      FROM WHS_MATERIALORDER MO 
      JOIN STR_STORE ST ON MO.STORE = ST.STOREID
      JOIN WHS_MATERIAL M ON MO.MATERIAL = M.MATERIALID
     WHERE MATERIALORDERID = @MaterialOrderId;

	INSERT INTO WHS_MATERIALORDERSTATUSHIST
    (MATERIALORDER, CREATEUSER, STATUS_CD, HISTORY_TM)
    VALUES
    (@MaterialOrderId, ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1), @OrderStatusCode, GETDATE());
END;