-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REQUESTDEF_SP
    @RequestDefinitionId   INT OUT,
    @RequestDefinitionName VARCHAR(100),
    @RequestGroup          INT,
    @Process               INT,
    @MicroCode             VARCHAR(100),
    @DisplayOrder          INT,
    @ActiveFlag            VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REQUESTDEF
    (
        REQUESTDEF_NM,
        REQUESTGROUP,
        PROCESS,
        MICROCODE_TXT,
        DISPLAYORDER_NO,
        ACTIVE_FL
    )
    VALUES
    (
        @RequestDefinitionName,
        @RequestGroup,
        @Process,
        @MicroCode,
        @DisplayOrder,
        @ActiveFlag
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
    SELECT @RequestDefinitionId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO HDK_REQUESTDEFLOG
    (
        REQUESTDEFID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        REQUESTDEF_NM,
        REQUESTGROUP,
        PROCESS,
        MICROCODE_TXT,
        DISPLAYORDER_NO,
        ACTIVE_FL
    )
    VALUES
    (
        @RequestDefinitionId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @RequestDefinitionName,
        @RequestGroup,
        @Process,
        @MicroCode,
        @DisplayOrder,
        @ActiveFlag);
/*Section="End"*/
END;
