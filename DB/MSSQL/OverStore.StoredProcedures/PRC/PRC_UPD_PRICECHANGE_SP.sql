-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_UPD_PRICECHANGE_SP 
    @PriceChangeHistoryId BIGINT
AS
BEGIN
    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRC_PRICECHANGE
       SET
           UPDATE_DT = GETDATE(),
           STATUS_CD = 1
     WHERE PRICECHANGEID = @PriceChangeHistoryId

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
