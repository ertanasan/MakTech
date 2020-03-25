-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_DEPARTMENT_SP
    @AccountingDepartmentId INT
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
        EXPENSECENTER_TXT    )    
    SELECT
        DEPARTMENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ACC_DEPARTMENT
     WHERE DEPARTMENTID = @AccountingDepartmentId;

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
