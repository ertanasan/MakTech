-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_REQUESTDEF_SP
    @RequestDefinitionId   INT,
    @RequestDefinitionName VARCHAR(100),
    @RequestGroup          INT,
    @Process               INT,
    @MicroCode             VARCHAR(100),
    @DisplayOrder          INT,
    @ActiveFlag            VARCHAR(1)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        REQUESTDEFID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REQUESTDEF_NM,
        REQUESTGROUP,
        PROCESS,
        MICROCODE_TXT,
        DISPLAYORDER_NO,
        ACTIVE_FL
      FROM
        HDK_REQUESTDEF R (NOLOCK)
     WHERE
        R.REQUESTDEFID = @RequestDefinitionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_REQUESTDEF
       SET
           REQUESTDEF_NM = @RequestDefinitionName,
           REQUESTGROUP = @RequestGroup,
           PROCESS = @Process,
           MICROCODE_TXT = @MicroCode,
           DISPLAYORDER_NO = @DisplayOrder,
           ACTIVE_FL = @ActiveFlag
     WHERE REQUESTDEFID = @RequestDefinitionId;

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
