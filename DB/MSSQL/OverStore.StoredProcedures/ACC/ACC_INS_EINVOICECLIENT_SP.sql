CREATE PROCEDURE ACC_INS_EINVOICECLIENT_SP
    @EInvoiceClientId INT OUT,
    @Identifier       BIGINT,
    @Alias            VARCHAR(200),
    @Title            VARCHAR(1000),
    @Type             VARCHAR(50),
    @FirstCreateTime  DATETIME,
    @AliasCreateTime  DATETIME,
    @Email            VARCHAR(200)
AS
BEGIN
	SET NOCOUNT OFF
	UPDATE ACC_EINVOICECLIENT
	   SET TITLE_DSC = @Title
	     , TYPE_NM = @Type
		 , FIRSTCREATE_TM = @FirstCreateTime
		 , ALIASCREATE_TM = @AliasCreateTime
		 , @EInvoiceClientId = EINVOICECLIENTID
	 WHERE IDENTIFIER_NO = @Identifier
	   AND ALIAS_DSC = @Alias 

    IF @@ROWCOUNT = 0
    BEGIN
		-- Insert record
		INSERT INTO ACC_EINVOICECLIENT
		(
			IDENTIFIER_NO,
			ALIAS_DSC,
			TITLE_DSC,
			TYPE_NM,
			FIRSTCREATE_TM,
			ALIASCREATE_TM,
			EMAIL_TXT
		)
		VALUES
		(
			@Identifier,
			@Alias,
			@Title,
			@Type,
			@FirstCreateTime,
			@AliasCreateTime,
			@Email
		);
		SELECT @EInvoiceClientId = SCOPE_IDENTITY();
    END;
    SET NOCOUNT ON;
END;