-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_ATTRIBUTETYPE_SP
    @AttributeTypeId   INT OUT,
    @AttributeTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_ATTRIBUTETYPE
    (
        ATTRIBUTETYPE_NM
    )
    VALUES
    (
        @AttributeTypeName
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
    SELECT @AttributeTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO HDK_ATTRIBUTETYPELOG
    (
        ATTRIBUTETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ATTRIBUTETYPE_NM
    )    
    VALUES
    (
        @AttributeTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @AttributeTypeName);
/*Section="End"*/
END;
