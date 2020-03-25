-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_ATTRIBUTECHOICE_SP
    @AttributeChoiceId INT OUT,
    @Attribute         INT,
    @ChoiceName        VARCHAR(100),
    @DisplayOrder      INT,
    @PriorityPoint     INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_ATTRIBUTECHOICE
    (
        ATTRIBUTE,
        CHOICE_NM,
        DISPLAYORDER_NO,
        PRIORITYPOINT_NO
    )
    VALUES
    (
        @Attribute,
        @ChoiceName,
        @DisplayOrder,
        @PriorityPoint
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
    SELECT @AttributeChoiceId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO HDK_ATTRIBUTECHOICELOG
    (
        ATTRIBUTECHOICEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ATTRIBUTE,
        CHOICE_NM,
        DISPLAYORDER_NO,
        PRIORITYPOINT_NO
    )
    VALUES
    (
        @AttributeChoiceId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Attribute,
        @ChoiceName,
        @DisplayOrder,
        @PriorityPoint);
/*Section="End"*/
END;
