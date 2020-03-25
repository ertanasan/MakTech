-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_CASHIERTEMPLATE_SP
    @CashierTemplateId   INT,
    @CashierTemplateName VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_CASHIERTEMPLATELOG
    (
        CASHIERTEMPLATEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CASHIERTEMPLATE_NM
    )    
    SELECT
        CASHIERTEMPLATEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CASHIERTEMPLATE_NM
      FROM
        STR_CASHIERTEMPLATE C (NOLOCK)
     WHERE
        C.CASHIERTEMPLATEID = @CashierTemplateId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_CASHIERTEMPLATE
       SET
           CASHIERTEMPLATE_NM = @CashierTemplateName
     WHERE CASHIERTEMPLATEID = @CashierTemplateId;

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
