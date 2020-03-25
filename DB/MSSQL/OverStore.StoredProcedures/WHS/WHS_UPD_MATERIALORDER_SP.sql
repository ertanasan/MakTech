CREATE PROCEDURE WHS_UPD_MATERIALORDER_SP
    @MaterialOrderId       BIGINT,
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

    DECLARE @StatusChanged INT;
	SELECT @StatusChanged = COUNT(*)
	  FROM WHS_MATERIALORDER
	 WHERE MATERIALORDERID = @MaterialOrderId
	   AND ORDERSTATUS_CD != @OrderStatusCode;

	IF @StatusChanged > 0 
	BEGIN
		INSERT INTO WHS_MATERIALORDERSTATUSHIST
        (MATERIALORDER, CREATEUSER, STATUS_CD, HISTORY_TM)
        VALUES
        (@MaterialOrderId, ISNULL(dbo.SYS_GETCURRENTUSER_FN(),1), @OrderStatusCode, GETDATE());
	END;

    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    SET NOCOUNT OFF;
    UPDATE WHS_MATERIALORDER
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           ORDER_NM = @OrderName,
           ORDER_DT = @OrderDate,
           ORDERSTATUS_CD = @OrderStatusCode,
           STORE = @Store,
           PROCESSINSTANCE_LNO = @ProcessInstanceNumber,
           MIKROSTATUS_CD = @MikroStatusCode,
           MIKROREF_TXT = @MikroReference,
           MIKRO_TM = @MikroTime,
           MIKROUSER = @MikroUser,
           MATERIAL = @Material,
           MATERIALINFO = @MaterialInfo,
           ORDER_AMT = @OrderQuantity,
           REVISED_AMT = @RevisedQuantity,
           SHIPPED_AMT = @ShippedQuantity,
           INTAKE_AMT = @IntakeQuantity,
           NOTE_TXT = @Note
     WHERE MATERIALORDERID = @MaterialOrderId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
