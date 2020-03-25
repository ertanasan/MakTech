-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_DEL_POSTRXTYPE_SP
    @PosTrxTypeId INT
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
        TRXTYPE_NM    )    
    SELECT
        POSTRXTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        TRXTYPE_NM
      FROM
        SLS_POSTRXTYPE P (NOLOCK)
     WHERE
        P.POSTRXTYPEID = @PosTrxTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM SLS_POSTRXTYPE
     WHERE POSTRXTYPEID = @PosTrxTypeId;

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
