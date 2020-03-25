-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_REGIONMANAGERS_SP
    @RegionManagersId   INT OUT,
    @RegionManagerName  VARCHAR(100),
    @TelNo              VARCHAR(100),
    @Email              VARCHAR(100),
    @RegionUser         INT,
    @ExpenseAccountCode VARCHAR(100),
	@MikroProjectCode VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_REGIONMANAGERS
    (
        MANAGER_NM,
        TELNO_TXT,
        EMAIL_TXT,
        USERID,
        EXPENSEACCCODE_TXT,
		MIKROPROJECTCODE_TXT
    )
    VALUES
    (
        @RegionManagerName,
        @TelNo,
        @Email,
        @RegionUser,
        @ExpenseAccountCode,
		@MikroProjectCode 
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @RegionManagersId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_REGIONMANAGERSLOG
    (
        REGIONMANAGERSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        MANAGER_NM,
        TELNO_TXT,
        EMAIL_TXT,
        USERID,
        EXPENSEACCCODE_TXT,
		MIKROPROJECTCODE_TXT
    )
    VALUES
    (
        @RegionManagersId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @RegionManagerName,
        @TelNo,
        @Email,
        @RegionUser,
        @ExpenseAccountCode,
		@MikroProjectCode);
/*Section="End"*/
END;