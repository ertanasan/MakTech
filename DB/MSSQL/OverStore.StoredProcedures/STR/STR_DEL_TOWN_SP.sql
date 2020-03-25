-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_TOWN_SP
    @TownId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_TOWNLOG
    (
        TOWNID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CITY,
        TOWN_NM    )    
    SELECT
        TOWNID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CITY,
        TOWN_NM
      FROM
        STR_TOWN T (NOLOCK)
     WHERE
        T.TOWNID = @TownId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_TOWN
     WHERE TOWNID = @TownId;

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
