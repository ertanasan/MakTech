-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REQUESTDETAIL_SP
    @RequestDetailId BIGINT OUT,
    @Event           INT,
    @Organization    INT,
    @Request         BIGINT,
    @Attribute       INT,
    @AttributeValue  VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REQUESTDETAIL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        REQUEST,
        ATTRIBUTE,
        ATTRIBUTEVALUE_TXT
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Request,
        @Attribute,
        @AttributeValue
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
    SELECT @RequestDetailId = SCOPE_IDENTITY();
/*Section="End"*/
END;
