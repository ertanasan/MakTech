-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_DEL_CONTRACTPARAMETER_SP
    @ContractParameterId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO FIN_CONTRACTPARAMETERLOG
    (
        CONTRACTPARAMETERID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PARAMETER_NM,
        VALUE_TXT    )    
    SELECT
        CONTRACTPARAMETERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PARAMETER_NM,
        VALUE_TXT
      FROM
        FIN_CONTRACTPARAMETER C (NOLOCK)
     WHERE
        C.CONTRACTPARAMETERID = @ContractParameterId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM FIN_CONTRACTPARAMETER
     WHERE CONTRACTPARAMETERID = @ContractParameterId;

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
