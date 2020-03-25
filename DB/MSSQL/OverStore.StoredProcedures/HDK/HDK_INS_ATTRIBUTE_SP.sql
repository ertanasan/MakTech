-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_ATTRIBUTE_SP
    @RequestAttributeId INT OUT,
    @AttributeName      VARCHAR(100),
    @RequestGroup       INT,
    @RequestDefinition  INT,
    @AttributeType      INT,
    @EditableFlag       VARCHAR(1),
    @RequiredFlag       VARCHAR(1),
    @DisplayOrder       INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_ATTRIBUTE
    (
        ATTRIBUTE_NM,
        REQUESTGROUP,
        REQUESTDEFINITION,
        ATTRIBUTETYPE,
        EDITABLE_FL,
        REQUIRED_FL,
        DISPLAYORDER_NO
    )
    VALUES
    (
        @AttributeName,
        @RequestGroup,
        @RequestDefinition,
        @AttributeType,
        @EditableFlag,
        @RequiredFlag,
        @DisplayOrder
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
    SELECT @RequestAttributeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @RequestAttributeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @AttributeName,
        @RequestGroup,
        @RequestDefinition,
        @AttributeType,
        @EditableFlag,
        @RequiredFlag,
        @DisplayOrder);
/*Section="End"*/
END;
