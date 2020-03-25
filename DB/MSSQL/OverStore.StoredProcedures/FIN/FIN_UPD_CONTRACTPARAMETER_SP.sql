-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_CONTRACTPARAMETER_SP
    @ContractParameterId INT,
    @ParameterName       VARCHAR(100),
    @Value               VARCHAR(1000)
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
        VALUE_TXT
    )    
    SELECT
        CONTRACTPARAMETERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PARAMETER_NM,
        VALUE_TXT
      FROM
        FIN_CONTRACTPARAMETER C (NOLOCK)
     WHERE
        C.CONTRACTPARAMETERID = @ContractParameterId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE FIN_CONTRACTPARAMETER
       SET
           PARAMETER_NM = @ParameterName,
           VALUE_TXT = @Value
     WHERE CONTRACTPARAMETERID = @ContractParameterId;

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
