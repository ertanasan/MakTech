-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_GATHERINGTYPE_SP
    @GatheringTypeId   INT,
    @GatheringTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_GATHERINGTYPE
    (
        GATHERINGTYPEID,
        GATHERINGTYPE_NM
    )
    VALUES
    (
        @GatheringTypeId,
        @GatheringTypeName
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_GATHERINGTYPELOG
    (
        GATHERINGTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GATHERINGTYPE_NM
    )
    VALUES
    (
        @GatheringTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @GatheringTypeName);
/*Section="End"*/
END;
