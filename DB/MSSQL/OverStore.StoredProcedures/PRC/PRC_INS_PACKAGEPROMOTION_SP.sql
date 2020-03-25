-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_PACKAGEPROMOTION_SP
    @Package       INT,
    @PromotionType INT
AS
BEGIN
    /*Section="Insert"*/
    -- Insert record
    SET NOCOUNT OFF
    INSERT INTO PRC_PACKAGEPROMOTION
    (
        PACKAGE,
        PROMOTIONTYPE,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN
    )
    VALUES
    (
        @Package,
        @PromotionType,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN()
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
END;
