-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_ATTRIBUTECHOICE_SP
    @AttributeChoiceId INT,
    @Attribute         INT,
    @ChoiceName        VARCHAR(100),
    @DisplayOrder      INT,
    @PriorityPoint     INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        ATTRIBUTECHOICEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ATTRIBUTE,
        CHOICE_NM,
        DISPLAYORDER_NO,
        PRIORITYPOINT_NO
      FROM
        HDK_ATTRIBUTECHOICE A (NOLOCK)
     WHERE
        A.ATTRIBUTECHOICEID = @AttributeChoiceId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_ATTRIBUTECHOICE
       SET
           ATTRIBUTE = @Attribute,
           CHOICE_NM = @ChoiceName,
           DISPLAYORDER_NO = @DisplayOrder,
           PRIORITYPOINT_NO = @PriorityPoint
     WHERE ATTRIBUTECHOICEID = @AttributeChoiceId;

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
