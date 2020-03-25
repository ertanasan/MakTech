-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_MATERIALINFO_SP
    @MaterialInfoId INT OUT,
    @Material       INT,
    @ShortName      VARCHAR(100),
    @InfoName       VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_MATERIALINFO
    (
        MATERIAL,
        INFOSHORT_NM,
        INFO_NM
    )
    VALUES
    (
        @Material,
        @ShortName,
        @InfoName
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
    SELECT @MaterialInfoId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_MATERIALINFOLOG
    (
        MATERIALINFOID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        MATERIAL,
        INFOSHORT_NM,
        INFO_NM
    )    
    VALUES
    (
        @MaterialInfoId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Material,
        @ShortName,
        @InfoName);
/*Section="End"*/
END;
