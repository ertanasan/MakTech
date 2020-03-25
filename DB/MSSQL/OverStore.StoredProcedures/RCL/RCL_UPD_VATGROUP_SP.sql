-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_VATGROUP_SP
    @VatGroupId INT,
    @VatRate    NUMERIC(4,2)
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
        VAT_RT
    )    
    SELECT
        VATGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        VAT_RT
      FROM
        RCL_VATGROUP V (NOLOCK)
     WHERE
        V.VATGROUPID = @VatGroupId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_VATGROUP
       SET
           VAT_RT = @VatRate
     WHERE VATGROUPID = @VatGroupId;

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
