-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_CASHREGISTERMODEL_SP
    @CashRegisterModelId INT
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
        COMMENT_DSC    )    
    SELECT
        CASHREGISTERMODELID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_CASHREGISTERMODEL
     WHERE CASHREGISTERMODELID = @CashRegisterModelId;

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
