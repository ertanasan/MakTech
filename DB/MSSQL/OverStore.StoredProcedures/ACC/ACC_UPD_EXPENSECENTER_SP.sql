-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_EXPENSECENTER_SP
    @ExpenseCenterId    INT,
    @ExpenseCenterName  VARCHAR(100),
    @ExpenseCenterCode  VARCHAR(50),
    @ExpenseCenterGroup INT,
    @RegionManager      INT,
    @Store              INT,
    @ActiveFlag         VARCHAR(1)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        EXPENSECENTERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EXPENSECENTER_NM,
        EXPENSECENTERCODE_TXT,
        CENTERGROUP_NO,
        REGIONMANAGER,
        STORE,
        ACTIVE_FL
      FROM
        ACC_EXPENSECENTER E (NOLOCK)
     WHERE
        E.EXPENSECENTERID = @ExpenseCenterId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_EXPENSECENTER
       SET
           EXPENSECENTER_NM = @ExpenseCenterName,
           EXPENSECENTERCODE_TXT = @ExpenseCenterCode,
           CENTERGROUP_NO = @ExpenseCenterGroup,
           REGIONMANAGER = @RegionManager,
           STORE = @Store,
           ACTIVE_FL = @ActiveFlag
     WHERE EXPENSECENTERID = @ExpenseCenterId;

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
