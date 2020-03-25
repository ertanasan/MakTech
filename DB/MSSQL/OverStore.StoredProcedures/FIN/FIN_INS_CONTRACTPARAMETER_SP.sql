-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_CONTRACTPARAMETER_SP
    @ContractParameterId INT OUT,
    @ParameterName       VARCHAR(100),
    @Value               VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO FIN_CONTRACTPARAMETER
    (
        PARAMETER_NM,
        VALUE_TXT
    )
    VALUES
    (
        @ParameterName,
        @Value
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
    SELECT @ContractParameterId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @ContractParameterId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ParameterName,
        @Value);
/*Section="End"*/
END;
