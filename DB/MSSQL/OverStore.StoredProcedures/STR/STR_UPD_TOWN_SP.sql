-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_TOWN_SP
    @TownId   INT,
    @City     INT,
    @TownName VARCHAR(100)
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
        TOWN_NM
    )    
    SELECT
        TOWNID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CITY,
        TOWN_NM
      FROM
        STR_TOWN T (NOLOCK)
     WHERE
        T.TOWNID = @TownId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_TOWN
       SET
           CITY = @City,
           TOWN_NM = @TownName
     WHERE TOWNID = @TownId;

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
