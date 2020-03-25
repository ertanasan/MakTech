-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_POSTRXTYPE_SP
    @PosTrxTypeId INT,
    @TrxType      VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO SLS_POSTRXTYPELOG
    (
        POSTRXTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        TRXTYPE_NM
    )    
    SELECT
        POSTRXTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TRXTYPE_NM
      FROM
        SLS_POSTRXTYPE P (NOLOCK)
     WHERE
        P.POSTRXTYPEID = @PosTrxTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SLS_POSTRXTYPE
       SET
           TRXTYPE_NM = @TrxType
     WHERE POSTRXTYPEID = @PosTrxTypeId;

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
