-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_EXPENSECENTER_SP
    @ExpenseCenterId    INT OUT,
    @ExpenseCenterName  VARCHAR(100),
    @ExpenseCenterCode  VARCHAR(50),
    @ExpenseCenterGroup INT,
    @RegionManager      INT,
    @Store              INT,
    @ActiveFlag         VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_EXPENSECENTER
    (
        EXPENSECENTER_NM,
        EXPENSECENTERCODE_TXT,
        CENTERGROUP_NO,
        REGIONMANAGER,
        STORE,
        ACTIVE_FL
    )
    VALUES
    (
        @ExpenseCenterName,
        @ExpenseCenterCode,
        @ExpenseCenterGroup,
        @RegionManager,
        @Store,
        @ActiveFlag
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
    SELECT @ExpenseCenterId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO ACC_EXPENSECENTERLOG
    (
        EXPENSECENTERID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        EXPENSECENTER_NM,
        EXPENSECENTERCODE_TXT,
        CENTERGROUP_NO,
        REGIONMANAGER,
        STORE,
        ACTIVE_FL
    )    
    VALUES
    (
        @ExpenseCenterId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ExpenseCenterName,
        @ExpenseCenterCode,
        @ExpenseCenterGroup,
        @RegionManager,
        @Store,
        @ActiveFlag);
/*Section="End"*/
END;
