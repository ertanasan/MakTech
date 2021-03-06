﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_FIRMCONTACT_SP
    @Firm        INT,
    @Contact     INT,
    @IsDefault   VARCHAR(1),
    @IsActive    VARCHAR(1),
    @IsPreferred VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    -- Insert record
    SET NOCOUNT OFF
    INSERT INTO ACC_FIRMCONTACT
    (
        FIRM,
        CONTACT,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        ISDEFAULT_FL,
        ISACTIVE_FL,
        ISPREFERRED_FL
    )
    VALUES
    (
        @Firm,
        @Contact,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @IsDefault,
        @IsActive,
        @IsPreferred
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
