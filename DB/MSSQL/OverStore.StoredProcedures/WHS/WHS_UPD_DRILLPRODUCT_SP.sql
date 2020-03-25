-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_DRILLPRODUCT_SP
    @DrillProductId INT,
    @CountingDate   DATETIME,
    @Product        INT,
    @Store          INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_DRILLPRODUCTLOG
    (
        DRILLPRODUCTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTING_DT,
        PRODUCT,
        STORE
    )
    SELECT
        DRILLPRODUCTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        COUNTING_DT,
        PRODUCT,
        STORE
      FROM
        WHS_DRILLPRODUCT D (NOLOCK)
     WHERE
        D.DRILLPRODUCTID = @DrillProductId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_DRILLPRODUCT
       SET
           COUNTING_DT = CAST(@CountingDate AS DATE),
           PRODUCT = @Product,
           STORE = @Store
     WHERE DRILLPRODUCTID = @DrillProductId;

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
