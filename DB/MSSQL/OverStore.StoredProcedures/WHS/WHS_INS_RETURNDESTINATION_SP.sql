﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_RETURNDESTINATION_SP
    @ReturnDestinationId INT OUT,
    @DestinationName     VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_RETURNDESTINATION
    (
        DESTINATION_NM
    )
    VALUES
    (
        @DestinationName
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
    SELECT @ReturnDestinationId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_RETURNDESTINATIONLOG
    (
        RETURNDESTINATIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        DESTINATION_NM
    )    
    VALUES
    (
        @ReturnDestinationId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @DestinationName);
/*Section="End"*/
END;
