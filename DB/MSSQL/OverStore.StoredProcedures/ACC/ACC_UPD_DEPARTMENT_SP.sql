-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_DEPARTMENT_SP
    @AccountingDepartmentId INT,
    @DepartmentName         VARCHAR(100),
    @Store                  INT,
    @ExpenseCenter          VARCHAR(50)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ACC_DEPARTMENTLOG
    (
        DEPARTMENTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        DEPARTMENT_NM,
        STORE,
        EXPENSECENTER_TXT
    )    
    SELECT
        DEPARTMENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        DEPARTMENT_NM,
        STORE,
        EXPENSECENTER_TXT
      FROM
        ACC_DEPARTMENT D (NOLOCK)
     WHERE
        D.DEPARTMENTID = @AccountingDepartmentId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_DEPARTMENT
       SET
           DEPARTMENT_NM = @DepartmentName,
           STORE = @Store,
           EXPENSECENTER_TXT = @ExpenseCenter
     WHERE DEPARTMENTID = @AccountingDepartmentId;

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
