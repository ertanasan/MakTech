-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_CONSTRAINTEXCEPTION_SP
    @ConstraintExceptionId INT
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
        COEFFICIENT_RT    )    
    SELECT
        CONSTRAINTEXCEPTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_CONSTRAINTEXCEPTION
     WHERE CONSTRAINTEXCEPTIONID = @ConstraintExceptionId;

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
