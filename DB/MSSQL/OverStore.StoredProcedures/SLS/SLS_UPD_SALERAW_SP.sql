-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_SALERAW_SP
    @SaleRawId    BIGINT,
    @Event        INT,
    @Organization INT,
    @SaleID       BIGINT,
    @Line         VARCHAR(1000),
    @Position     INT
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
    UPDATE SLS_SALERAW
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           SALE = @SaleID,
           LINE_TXT = @Line,
           POSITION_NO = @Position
     WHERE SALERAWID = @SaleRawId
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
