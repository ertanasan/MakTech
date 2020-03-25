-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_CASHREGISTERMODEL_SP
    @CashRegisterModelId INT,
    @Brand               INT,
    @Name                VARCHAR(100),
    @Description         VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_CASHREGISTERMODELLOG
    (
        CASHREGISTERMODELID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BRAND,
        MODEL_NM,
        COMMENT_DSC
    )    
    SELECT
        CASHREGISTERMODELID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BRAND,
        MODEL_NM,
        COMMENT_DSC
      FROM
        STR_CASHREGISTERMODEL C (NOLOCK)
     WHERE
        C.CASHREGISTERMODELID = @CashRegisterModelId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_CASHREGISTERMODEL
       SET
           BRAND = @Brand,
           MODEL_NM = @Name,
           COMMENT_DSC = @Description
     WHERE CASHREGISTERMODELID = @CashRegisterModelId;

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
