-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_ATTRIBUTE_SP
    @RequestAttributeId INT,
    @AttributeName      VARCHAR(100),
    @RequestGroup       INT,
    @RequestDefinition  INT,
    @AttributeType      INT,
    @EditableFlag       VARCHAR(1),
    @RequiredFlag       VARCHAR(1),
    @DisplayOrder       INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_ATTRIBUTELOG
    (
        ATTRIBUTEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ATTRIBUTE_NM,
        REQUESTGROUP,
        REQUESTDEFINITION,
        ATTRIBUTETYPE,
        EDITABLE_FL,
        REQUIRED_FL,
        DISPLAYORDER_NO
    )
    SELECT
        ATTRIBUTEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ATTRIBUTE_NM,
        REQUESTGROUP,
        REQUESTDEFINITION,
        ATTRIBUTETYPE,
        EDITABLE_FL,
        REQUIRED_FL,
        DISPLAYORDER_NO
      FROM
        HDK_ATTRIBUTE A (NOLOCK)
     WHERE
        A.ATTRIBUTEID = @RequestAttributeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_ATTRIBUTE
       SET
           ATTRIBUTE_NM = @AttributeName,
           REQUESTGROUP = @RequestGroup,
           REQUESTDEFINITION = @RequestDefinition,
           ATTRIBUTETYPE = @AttributeType,
           EDITABLE_FL = @EditableFlag,
           REQUIRED_FL = @RequiredFlag,
           DISPLAYORDER_NO = @DisplayOrder
     WHERE ATTRIBUTEID = @RequestAttributeId;

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
