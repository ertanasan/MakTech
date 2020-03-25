-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_EINVOICECLIENT_SP
    @EInvoiceClientId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_EINVOICECLIENTLOG
    (
        EINVOICECLIENTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        IDENTIFIER_NO,
        ALIAS_DSC,
        TITLE_DSC,
        TYPE_NM,
        FIRSTCREATE_TM,
        ALIASCREATE_TM,
        EMAIL_TXT    )
    SELECT
        EINVOICECLIENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        IDENTIFIER_NO,
        ALIAS_DSC,
        TITLE_DSC,
        TYPE_NM,
        FIRSTCREATE_TM,
        ALIASCREATE_TM,
        EMAIL_TXT
      FROM
        ACC_EINVOICECLIENT E (NOLOCK)
     WHERE
        E.EINVOICECLIENTID = @EInvoiceClientId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ACC_EINVOICECLIENT
     WHERE EINVOICECLIENTID = @EInvoiceClientId;

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
