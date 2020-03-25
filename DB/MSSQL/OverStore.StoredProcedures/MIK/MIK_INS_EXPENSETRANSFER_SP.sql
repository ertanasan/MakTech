CREATE PROCEDURE MIK_INS_EXPENSETRANSFER_SP
	@ExpenseId BIGINT,
    @Mikro NUMERIC(9),
    @Status INT,
    @StatusDescription VARCHAR(1000)
AS
BEGIN
    INSERT INTO MIK_EXPENSETRANSFER
    (
        EXPENSEID,
        CREATEUSER,
        CREATE_DT,
        MIKRO,
        [STATUS],
		STATUS_DSC
    )
    VALUES
    (
        @ExpenseId,
		dbo.SYS_GETCURRENTUSER_FN(),
        GETDATE(),
		@Mikro,
		@Status,
		@StatusDescription
    );
END
