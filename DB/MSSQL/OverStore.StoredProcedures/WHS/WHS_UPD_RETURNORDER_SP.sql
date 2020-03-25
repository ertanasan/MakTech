-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_RETURNORDER_SP
    @ReturnOrderId   BIGINT,
    @Event           INT,
    @Organization    INT,
    @Store           INT,
    @Status          INT,
    @ProcessInstance BIGINT
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
    UPDATE WHS_RETURNORDER
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           STATUS = @Status,
           PROCESSINSTANCE_LNO = @ProcessInstance
     WHERE RETURNORDERID = @ReturnOrderId
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
