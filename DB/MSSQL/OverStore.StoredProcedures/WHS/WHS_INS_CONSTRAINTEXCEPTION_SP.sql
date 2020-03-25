-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_CONSTRAINTEXCEPTION_SP
    @ConstraintExceptionId INT OUT,
    @Store                 INT,
    @StartDate             DATETIME,
    @EndDate               DATETIME,
    @Category              INT,
    @SubGroup              INT,
    @Product               INT,
    @Coefficient           NUMERIC(4,2)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_CONSTRAINTEXCEPTION
    (
        STORE,
        STARTDATE_DT,
        ENDDATE_DT,
        CATEGORY,
        SUBGROUP,
        PRODUCT,
        COEFFICIENT_RT
    )
    VALUES
    (
        @Store,
        @StartDate,
        @EndDate,
        @Category,
        @SubGroup,
        @Product,
        @Coefficient
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
    SELECT @ConstraintExceptionId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @ConstraintExceptionId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Store,
        @StartDate,
        @EndDate,
        @Category,
        @SubGroup,
        @Product,
        @Coefficient);
/*Section="End"*/
END;
