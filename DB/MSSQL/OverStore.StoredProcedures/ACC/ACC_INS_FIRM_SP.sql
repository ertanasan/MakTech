﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_FIRM_SP
    @FirmId   INT OUT,
    @Name     VARCHAR(100),
    @FirmType INT,
    @Comment  VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_FIRM
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        FIRM_NM,
        FIRMTYPE,
        COMMENT_DSC
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Name,
        @FirmType,
        @Comment
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
    SELECT @FirmId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO ACC_FIRMLOG
    (
        FIRMID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIRM_NM,
        FIRMTYPE,
        COMMENT_DSC
    )    
    VALUES
    (
        @FirmId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name,
        @FirmType,
        @Comment);
/*Section="End"*/
END;
