-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_POSBANKTYPE_SP
    @PosBankTypeId INT,
    @BankType      VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO SLS_POSBANKTYPELOG
    (
        POSBANKTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        BANKTYPE_NM
    )    
    SELECT
        POSBANKTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BANKTYPE_NM
      FROM
        SLS_POSBANKTYPE P (NOLOCK)
     WHERE
        P.POSBANKTYPEID = @PosBankTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SLS_POSBANKTYPE
       SET
           BANKTYPE_NM = @BankType
     WHERE POSBANKTYPEID = @PosBankTypeId;

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
