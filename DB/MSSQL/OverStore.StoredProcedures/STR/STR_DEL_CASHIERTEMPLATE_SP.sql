-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_CASHIERTEMPLATE_SP
    @CashierTemplateId INT
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
        CASHIERTEMPLATE_NM    )    
    SELECT
        CASHIERTEMPLATEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CASHIERTEMPLATE_NM
      FROM
        STR_CASHIERTEMPLATE C (NOLOCK)
     WHERE
        C.CASHIERTEMPLATEID = @CashierTemplateId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_CASHIERTEMPLATE
     WHERE CASHIERTEMPLATEID = @CashierTemplateId;

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
