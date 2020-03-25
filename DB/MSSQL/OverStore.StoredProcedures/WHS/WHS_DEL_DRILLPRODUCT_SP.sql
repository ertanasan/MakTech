-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_DRILLPRODUCT_SP
    @DrillProductId INT
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
        STORE    )
    SELECT
        DRILLPRODUCTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_DRILLPRODUCT
     WHERE DRILLPRODUCTID = @DrillProductId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
