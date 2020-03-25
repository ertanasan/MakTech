-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_CARDDIST_SP
    @CardDistributionId BIGINT OUT,
    @Event              INT,
    @Organization       INT,
    @CardGroupCode      INT,
    @CardZetAmount      NUMERIC(22,6),
    @StoreRec           BIGINT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_CARDDIST
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        CARDGROUP_CD,
        CARDZET_AMT,
        STOREREC
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
        @CardGroupCode,
        @CardZetAmount,
        @StoreRec
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
    SELECT @CardDistributionId = SCOPE_IDENTITY();
/*Section="End"*/
END;
