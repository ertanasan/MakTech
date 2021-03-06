﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_INS_LABEL_SP
    @PriceLabelId BIGINT OUT,
    @Event        INT,
    @Organization INT,
    @Product      INT,
    @Package      INT,
    @PackageID    INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRC_LABEL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        PRODUCT,
        PACKAGE,
        PACKAGEVERSION_NO
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
        @Product,
        @Package,
        @PackageID
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
    SELECT @PriceLabelId = SCOPE_IDENTITY();
/*Section="End"*/
END;
