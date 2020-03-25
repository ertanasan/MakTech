-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_DEL_VATGROUP_SP
    @VatGroupId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO RCL_VATGROUPLOG
    (
        VATGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        VAT_RT    )    
    SELECT
        VATGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        VAT_RT
      FROM
        RCL_VATGROUP V (NOLOCK)
     WHERE
        V.VATGROUPID = @VatGroupId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM RCL_VATGROUP
     WHERE VATGROUPID = @VatGroupId;

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
