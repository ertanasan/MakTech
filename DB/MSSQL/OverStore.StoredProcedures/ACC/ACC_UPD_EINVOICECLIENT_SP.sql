-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_EINVOICECLIENT_SP
    @EInvoiceClientId INT,
    @Identifier       INT,
    @Alias            VARCHAR(200),
    @Title            VARCHAR(1000),
    @Type             VARCHAR(50),
    @FirstCreateTime  DATETIME,
    @AliasCreateTime  DATETIME,
    @Email            VARCHAR(200)
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
        EMAIL_TXT
    )
    SELECT
        EINVOICECLIENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_EINVOICECLIENT
       SET
           IDENTIFIER_NO = @Identifier,
           ALIAS_DSC = @Alias,
           TITLE_DSC = @Title,
           TYPE_NM = @Type,
           FIRSTCREATE_TM = @FirstCreateTime,
           ALIASCREATE_TM = @AliasCreateTime,
           EMAIL_TXT = @Email
     WHERE EINVOICECLIENTID = @EInvoiceClientId;

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
