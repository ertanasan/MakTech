-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_CONSTRAINTEXCEPTION_SP
    @ConstraintExceptionId INT,
    @Store                 INT,
    @StartDate             DATETIME,
    @EndDate               DATETIME,
    @Category              INT,
    @SubGroup              INT,
    @Product               INT,
    @Coefficient           NUMERIC(4,2)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_CONSTRAINTEXCEPTIONLOG
    (
        CONSTRAINTEXCEPTIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STORE,
        STARTDATE_DT,
        ENDDATE_DT,
        CATEGORY,
        SUBGROUP,
        PRODUCT,
        COEFFICIENT_RT
    )    
    SELECT
        CONSTRAINTEXCEPTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE,
        STARTDATE_DT,
        ENDDATE_DT,
        CATEGORY,
        SUBGROUP,
        PRODUCT,
        COEFFICIENT_RT
      FROM
        WHS_CONSTRAINTEXCEPTION C (NOLOCK)
     WHERE
        C.CONSTRAINTEXCEPTIONID = @ConstraintExceptionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_CONSTRAINTEXCEPTION
       SET
           STORE = @Store,
           STARTDATE_DT = @StartDate,
           ENDDATE_DT = @EndDate,
           CATEGORY = @Category,
           SUBGROUP = @SubGroup,
           PRODUCT = @Product,
           COEFFICIENT_RT = @Coefficient
     WHERE CONSTRAINTEXCEPTIONID = @ConstraintExceptionId;

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
