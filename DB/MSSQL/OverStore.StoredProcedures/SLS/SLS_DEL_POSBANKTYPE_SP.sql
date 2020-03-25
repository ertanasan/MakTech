-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_DEL_POSBANKTYPE_SP
    @PosBankTypeId INT
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
        BANKTYPE_NM    )    
    SELECT
        POSBANKTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        BANKTYPE_NM
      FROM
        SLS_POSBANKTYPE P (NOLOCK)
     WHERE
        P.POSBANKTYPEID = @PosBankTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM SLS_POSBANKTYPE
     WHERE POSBANKTYPEID = @PosBankTypeId;

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
