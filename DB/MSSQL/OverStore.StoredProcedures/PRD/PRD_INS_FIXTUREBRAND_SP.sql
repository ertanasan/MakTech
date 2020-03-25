﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_FIXTUREBRAND_SP
    @FixtureBrandId INT OUT,
    @Fixture        INT,
    @BrandName      VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_FIXTUREBRAND
    (
        FIXTURE,
        BRAND_NM
    )
    VALUES
    (
        @Fixture,
        @BrandName
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
    SELECT @FixtureBrandId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO PRD_FIXTUREBRANDLOG
    (
        FIXTUREBRANDID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIXTURE,
        BRAND_NM
    )    
    VALUES
    (
        @FixtureBrandId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Fixture,
        @BrandName);
/*Section="End"*/
END;
