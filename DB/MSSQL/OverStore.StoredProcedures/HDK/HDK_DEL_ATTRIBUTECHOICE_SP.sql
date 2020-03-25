-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_ATTRIBUTECHOICE_SP
    @AttributeChoiceId INT
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
        PRIORITYPOINT_NO    )
    SELECT
        ATTRIBUTECHOICEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_ATTRIBUTECHOICE
     WHERE ATTRIBUTECHOICEID = @AttributeChoiceId;

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
